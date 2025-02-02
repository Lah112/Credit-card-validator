namespace CreditCardValidation.Models
{
    public class CreditCard
    {
        public required string CardNumber { get; set; }

        
        public CreditCard(string cardNumber)
        {
            CardNumber = cardNumber;
        }
    }
}
