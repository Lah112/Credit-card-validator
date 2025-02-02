using Microsoft.AspNetCore.Mvc;
using CreditCardValidation.Models;
using CreditCardValidation.Services;

namespace CreditCardValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        [HttpPost("validate")]
        public IActionResult ValidateCard([FromBody] CreditCard card)
        {
            if (card == null || string.IsNullOrWhiteSpace(card.CardNumber))
                return BadRequest("Invalid card number.");

            bool isValid = CreditCardValidator.Validate(card.CardNumber);
            string provider = CreditCardValidator.GetCardProvider(card.CardNumber);

            return Ok(new { valid = isValid, provider });
        }
    }
}
