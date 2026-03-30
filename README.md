# Task Management System (TMS)

This is a full-stack Task Management System built with a .NET Core 10 Web API backend and an Angular 18 frontend. The application allows users to manage tasks, including creating, reading, updating (such as changing status between Pending/Completed), and deleting tasks.

## Project Structure

The repository contains three main components:
- **`TMS.Api`**: The backend RESTful API built with ASP.NET Core 10.
- **`TMS.Mvc`**: An ASP.NET Core MVC application (optional UI/backend component).
- **`tms-frontend`**: The frontend Single Page Application (SPA) built with Angular 18.

## Technologies Used

### Backend (.NET)
- .NET 10.0
- ASP.NET Core Web API
- Entity Framework Core (In-Memory Database for development)
- OpenAPI / Swagger for API documentation

### Frontend (Angular)
- Angular CLI & Core 18.2
- TypeScript 5.5
- RxJS
- Jasmine & Karma (Testing)

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) (latest LTS recommended)
- [Angular CLI](https://angular.dev/tools/cli) (`npm install -g @angular/cli`)

### Running the Backend (API)

1. Open a terminal and navigate to the backend project directory:
   ```bash
   cd TMS.Api
   ```
2. Run the .NET application:
   ```bash
   dotnet watch run
   ```
   The API will typically start on `https://localhost:5001` or `http://localhost:5000` (check the console output for the exact URL). Swagger documentation will be available at `/swagger` or `/openapi`.

### Running the Frontend (Angular)

1. Open a new terminal and navigate to the frontend project directory:
   ```bash
   cd tms-frontend
   ```
2. Install the necessary NPM packages:
   ```bash
   npm install
   ```
3. Start the Angular development server:
   ```bash
   ng serve
   ```
   The application will be available at `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Features (Planned/Implemented)
- Layered Architecture on the backend.
- Full CRUD operations for Tasks.
- Task status management (Pending vs. Completed).
- Model validation on backend and frontend.
- Responsive User Interface.

## Testing
- To run frontend unit tests, execute `ng test` in the `tms-frontend` directory.
- To run backend tests (if any exists), execute `dotnet test` within the root or specific test project directory.
