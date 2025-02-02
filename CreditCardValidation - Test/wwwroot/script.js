const apiUrl = 'http://localhost:5082/api/creditcard/validate';

async function validateCard(cardNumber) {
    try {
        // Sending the card number to the backend for validation
        const response = await fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ cardNumber }), // Send card number as JSON
        });

        // Check if the response is ok (status code 2xx)
        if (!response.ok) {
            throw new Error('Failed to validate card');
        }

        const data = await response.json(); // Parse JSON response
        const resultElement = document.getElementById('result');
        resultElement.classList.remove('show'); // Reset animation class

        setTimeout(() => {
            resultElement.classList.add('show'); // Trigger the fade-in animation
        }, 50);

        if (data.valid) {  // Corrected from `data.isValid` to `data.valid`
            resultElement.textContent = 'Card is valid!';
            resultElement.classList.add('success');
            resultElement.classList.remove('error');
        } else {
            resultElement.textContent = 'Card is invalid!';
            resultElement.classList.add('error');
            resultElement.classList.remove('success');
        }
    } catch (error) {
        console.error('Error:', error);  // Handle any errors
        const resultElement = document.getElementById('result');
        resultElement.classList.remove('show');
        setTimeout(() => {
            resultElement.classList.add('show');
        }, 50);

        resultElement.textContent = 'Error: Failed to validate card';
        resultElement.classList.add('error');
    }
}

// Example usage:
document.getElementById("validateButton").addEventListener("click", () => {
    const cardNumber = document.getElementById("cardNumber").value;
    validateCard(cardNumber);  // Call the validateCard function with the card number
});
