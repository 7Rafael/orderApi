# Support Ticket API
A C# API designed for managing support tickets related to bugs or other issues. The system allows users to create tickets, track their status (fixed or not), and associate them with specific sectors like Infrastructure, Bug Fixing, and more.

## Features
🔹Create and manage support tickets with details like Title, Description, Status, and Creation Date.

🔹Link tickets to sectors (e.g., Infrastructure, Bug Fixing) – a sector must exist before a ticket can be created.

🔹CRUD operations for both Tickets and Sectors.

🔹JWT Authentication for secure access.

🔹Swagger Documentation for easy API exploration.

🔹AutoMapper for object mapping and data transfer.
## Technologies Used
C#
ASP.NET Core
Entity Framework Core
JWT Authentication
Swagger
AutoMapper
Pomelo (for MySQL)
MySQL

## Setup & Installation
### Prerequisites:
🔹.NET SDK 6.0 or later

🔹MySQL Database

🔹Docker (optional, for containerized deployment)

## Steps to Run Locally:

### Clone the repository:

 **` git clone https://github.com/7Rafael/orderApi.git `**
 
 **` cd orderApi `**
### Install dependencies:

**` dotnet tool install --global dotnet-ef `**

**` dotnet restore `**

### Set up the database:

Update your appsettings.json to include the connection string to your MySQL database.
You can also use Pomelo to manage the connection.

**` dotnet ef migrations add InitialMigration `**

**` dotnet ef database update `**

### Run the application:

**` dotnet run `**

The API will be running locally, and you can test it using Swagger UI (default URL: http://localhost:5000/swagger).

## API Documentation
For API documentation, Swagger is integrated into the project. You can explore all available endpoints, test them, and view the response directly from the Swagger interface.

## License
This project is licensed under the MIT License.

## Contact
If you have any questions or suggestions, feel free to reach out:

🔹Email: correiarafael2021@gmail.com
