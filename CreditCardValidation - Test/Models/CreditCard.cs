namespace CreditCardValidation.Models
{
    public class CreditCard
    {
        public required string CardNumber { get; set; }

        // Constructor ensures the property is initialized
        public CreditCard(string cardNumber)
        {
            CardNumber = cardNumber;
        }
    }
}
