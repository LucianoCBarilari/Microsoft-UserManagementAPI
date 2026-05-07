# User Management API

A RESTful API built with ASP.NET Core for managing users. Developed as part of a Microsoft-guided learning path using GitHub Copilot.

## Features

- CRUD endpoints for user management
- Input validation using Data Annotations
- Logging, authentication, and error handling middleware

## Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get user by ID |
| POST | `/api/users` | Create a new user |
| PUT | `/api/users/{id}` | Update an existing user |
| DELETE | `/api/users/{id}` | Delete a user |

## Authentication

All requests require a Bearer token in the `Authorization` header:

```
Authorization: Bearer techhive-secret-token
```

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Run the API

```bash
dotnet run --project UserManagementAPI
```

The API will be available at `https://localhost:7xxx` (see console output for the exact port).

## Tech Stack

- ASP.NET Core 10
- C#
- GitHub Copilot (used for code generation, enhancement, and debugging)
