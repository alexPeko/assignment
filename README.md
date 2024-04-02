## Prerequisites

1. Before you begin, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://cli.angular.io/)

2. Clone this repository:
 
## Setting up the Backend

1. Navigate to the backend directory:

   ```bash
   cd Server
   ```

   ```bash
   cd WebApplication
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Run the backend:

   ```bash
   dotnet run
   ```

   This will start the .NET backend server.

## Setting up the Frontend

1. Navigate to the frontend directory:

   ```bash
   cd Client
   ```

   ```bash
   cd WebApplication
   ```

2. Install dependencies:

   ```bash
   npm install
   ```

3. Start the Angular development server:

   ```bash
   ng serve
   ```

   This will compile the Angular application and start the development server.

## Accessing the Application

Once both the backend and frontend are running, you can access the application at `http://localhost:4200`.
