# SafeVault — Secure Web Application

SafeVault is a web application built with **ASP.NET Core MVC and .NET 8**. The project focuses on secure coding practices, cookie-based authentication, Role-Based Access Control (RBAC), server-side input validation, and security vulnerability remediation, with development assistance from **Microsoft Copilot**.

---

## 🛠️ Project Structure and Architecture

The application follows the Model-View-Controller (MVC) architectural pattern.

- **`Controllers/`** — Handles application logic, authentication workflows, authorization policies, and route protection, including `HomeController.cs` and `AdminController.cs`.
- **`Models/`** — Defines application data structures, including `UserModel.cs` and `LoginModel.cs`, with C# Data Annotations for server-side validation.
- **`Views/`** — Contains Razor view templates for user registration, login, and restricted administrative pages.

---

## 📋 Core Features

### Input Validation and Data Integrity

- Uses C# Data Annotations, including `[Required]` and `[EmailAddress]`, to validate submitted data and reject invalid input.

### Form State Preservation

- Preserves submitted model data when validation fails, allowing users to correct errors without re-entering all their information.
- Returns the submitted model to the Razor view together with validation errors.

### Cookie-Based Authentication

- Uses ASP.NET Core Cookie Authentication middleware to manage authenticated user sessions.

### Role-Based Access Control (RBAC)

- Supports `Admin` and `User` roles through identity claims assigned during authentication.
- Restricts administrative functionality to users with the `Admin` role.

### Protected Routes and Navigation

- Uses `[Authorize(Roles = "Admin")]` to protect administrative controllers.
- Configures authentication redirection for unauthenticated requests, including a `ReturnUrl` parameter where applicable.

### Session Termination (Logout)

- Implements a logout POST action using `HttpContext.SignOutAsync()` to sign users out of the configured authentication scheme.

---

## 🔒 Security Summary and Vulnerability Resolution

| Category | Identified Issue or Requirement | Applied Fix or Countermeasure |
|---|---|---|
| **Authentication** | Users needed a way to terminate their authenticated sessions. | Added a logout action using `HttpContext.SignOutAsync()` to sign out of the configured cookie authentication scheme. |
| **Authorization** | Administrative routes needed protection against unauthorized access. | Applied `[Authorize(Roles = "Admin")]` to restrict access to users with the `Admin` role. |
| **Validation** | Submitted registration data was lost when validation errors occurred. | Updated the POST action to return the submitted model to the Razor view so validation errors could be displayed alongside the entered data. |

These changes address specific application behaviors. They should not be interpreted as a guarantee that the application is free of all security vulnerabilities.

---

## 🤖 Role of Microsoft Copilot

Microsoft Copilot was used as an AI-assisted development tool throughout the project.

1. **Implementation Assistance** — Helped with structuring MVC controllers, models, Razor views, and authentication-related code.
2. **Debugging and Security Analysis** — Assisted in investigating authentication, role-based authorization, `ReturnUrl` redirection, and logout behavior.
3. **Code Refinement and Documentation** — Helped improve code readability, formatting consistency, and English-language documentation.

---

## 🚀 How to Run and Test the Application

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- The project's source code

### 1. Build the Application

Open a terminal in the directory containing the project file (`.csproj`) and run:

```bash
dotnet build
```

A successful build should complete without compilation errors.

### 2. Run the Application

Run the following command:

```bash
dotnet run
```

Open the local HTTP or HTTPS address displayed in the terminal.

### 3. Test Authentication and Authorization

Use the following test cases if the listed credentials are configured in the application.

**Administrator Access**

- Username: `admin`
- Password: `password123`
- Expected result: Successful login and redirection to `/Admin/Dashboard`.

**Standard User Access**

- Username: `user`
- Password: `password123`
- Expected result: Successful login and redirection to `/Home/Index`.

**Registration Validation**

- Username: `user`
- Email: `user@user.com`
- Expected result: The application validates the submitted input and displays the appropriate success message if the input is accepted.

*Note: Test credentials and expected results must match the application's actual authentication and registration logic. Use these credentials only in a local test environment.*

---

## 🧪 Testing Focus

The project focuses on verifying the following behaviors:

- Authentication through the login form.
- Role-based access restrictions for administrative routes.
- Redirection of unauthenticated users to the login page.
- Logout behavior and authentication cookie sign-out.
- Server-side input validation and registration form error handling.

Testing claims should reflect the checks actually performed during development.

