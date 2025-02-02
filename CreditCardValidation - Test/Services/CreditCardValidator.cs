using CreditCardValidation.Models;
using System.Text.RegularExpressions;

namespace CreditCardValidation.Services
{
    public class CreditCardValidator
    {
        // Main Validation Method
        public static bool Validate(string cardNumber)
        {
            return LuhnCheck(cardNumber) && GetCardProvider(cardNumber) != "Unknown";
        }

        // Luhn Algorithm to check the validity of the card number
        private static bool LuhnCheck(string cardNumber)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(cardNumber[i].ToString());
                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                        n -= 9;
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }

        // Card Provider Identification Based on Length and Starting Digits
        public static string GetCardProvider(string cardNumber)
        {
            if (cardNumber.Length == 15 && Regex.IsMatch(cardNumber, @"^3[47][0-9]{13}$"))
                return "AmEx";  // American Express (AmEx)
            
            if (cardNumber.Length == 16 && Regex.IsMatch(cardNumber, @"^4[0-9]{15}$"))
                return "Visa";  // Visa

            if (cardNumber.Length == 16 && Regex.IsMatch(cardNumber, @"^(22[2-9][0-9]{2}|5[1-5][0-9]{2})[0-9]{12}$"))
                return "Mastercard";  // Mastercard
            
            if (cardNumber.Length == 16 && Regex.IsMatch(cardNumber, @"^6011[0-9]{12}$"))
                return "Discover";  // Discover
            
            return "Unknown";  // Unknown provider
        }
    }
}
