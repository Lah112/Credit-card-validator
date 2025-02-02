# Credit-card-validator

Features

🔹 Validate credit card numbers via API

🔹 Uses Minimal API for lightweight performance

🔹 Supports CORS for cross-origin requests

🔹 Includes Swagger UI for API documentation

🔹 Built with Dependency Injection for modularity

Technologies Used

ASP.NET Core 6

C#

Minimal APIs

Swagger UI

Dependency Injection



1️⃣ Clone the repository

git clone https://github.com/yourusername/CreditCardValidation.git
cd CreditCardValidation

2️⃣ Install dependencies

Make sure you have the .NET 6 SDK installed, then restore dependencies:

dotnet restore

3️⃣ Run the application

dotnet run

The API will start on https://localhost:5082.

API Documentation

Once the application is running, open Swagger UI at:

http://localhost:5082/swagger

Validate a Credit Card

Endpoint:POST /api/creditcard/validate

Request Body:

{
  "cardNumber": "4111111111111111"
}

Response:

{
  "isValid": true
}



Environment Configuration

Modify appsettings.json if needed for environment settings.



Fork the repository

Create a new branch (git checkout -b feature-branch)

Commit your changes (git commit -m "Add new feature")

Push to your branch (git push origin feature-branch)

Create a Pull Request 




