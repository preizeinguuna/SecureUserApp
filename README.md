# SafeVault - Secure Web Application

SafeVault is a secure web application built with **ASP.NET Core MVC** (.NET 8). The primary goal of this project is to showcase secure coding practices, dynamic authentication, Role-Based Access Control (RBAC), and security debugging techniques developed and refined with the assistance of **Microsoft Copilot**.

---

## 🛠️ Project Structure & Architecture

The application follows the classic ASP.NET Core Model-View-Controller (MVC) design pattern:

* **`Controllers/`**: Manages application logic, authentication workflows, authorization policies, and route protections (`HomeController.cs`, `AdminController.cs`).
* **`Models/`**: Defines data structures (`UserModel.cs`, `LoginModel.cs`) with strict Data Annotations for server-side validation.
* **`Views/`**: Razor view templates providing UI for user registration, user login, and restricted admin dashboard interfaces.

---

## 📋 Features Implemented Across Activities

### 🟢 Activity 1: Writing Secure Code Using Microsoft Copilot
* **Input Validation & Data Integrity**:
  * Integrated C# Data Annotations (`[Required]`, `[EmailAddress]`) into data models to prevent malformed inputs and potential injection attacks.
* **Form State Preservation**:
  * Implemented `[HttpPost] Index` controller logic returning the submitted model state, ensuring user-entered data remains visible alongside error messages during validation failures.
* **Standardized Codebase**:
  * Cleaned up comments and maintained professional code documentation in English using Copilot pair programming.

### 🟡 Activity 2: Implementing Authentication & Authorization Using Microsoft Copilot
* **Cookie-Based Authentication**:
  * Configured native ASP.NET Core Cookie Authentication middleware to create and manage secure encrypted user sessions.
* **Role-Based Access Control (RBAC)**:
  * Established multi-role support assigning dynamic identity claims (`Admin` and `User` roles) upon successful credential verification.
* **Protected Routes & Navigation**:
  * Applied `[Authorize(Roles = "Admin")]` constraints on administrative controllers (`AdminController`), enforcing automated redirection to `/Home/Login` with a `ReturnUrl` parameter for unauthenticated requests.
* **Universal Login Flow**:
  * Built a single, responsive login view (`Login.cshtml`) handling both administrator and standard user authentication seamlessly.

### 🔴 Activity 3: Debugging and Resolving Security Issues Using Microsoft Copilot
* **Security Vulnerability Auditing**:
  * Identified and remediated unauthenticated endpoint leaks and improper session handling mechanisms.
* **Session Termination (Logout)**:
  * Implemented a secure `Logout` POST controller action utilizing `HttpContext.SignOutAsync()` to properly clear authentication cookies and terminate session privileges.
* **UI & Authorization Testing**:
  * Tested cookie isolation and role enforcement across multiple browser environments (Google Chrome and VS Code embedded browser) to verify session security against unauthorized access.

---

## 🔒 Security Summary & Vulnerability Resolution

| Category | Identified Issue / Vulnerability | Applied Fix / Security Countermeasure |
| :--- | :--- | :--- |
| **Authentication** | Missing session sign-out mechanism allowing persistent cookie retention. | Added dedicated `Logout` action clearing authentication cookies via `HttpContext.SignOutAsync()`. |
| **Authorization** | Unprotected administrative routes allowing direct URL navigation. | Applied `[Authorize(Roles = "Admin")]` to restrict access exclusively to authorized users. |
| **Validation** | Data reset on registration form errors, degrading user experience and security checks. | Updated controller `HttpPost` method to return the `UserModel` back to the Razor view. |

---

## 🤖 Role of Microsoft Copilot

Throughout the development lifecycle, **Microsoft Copilot** was utilized as an AI pair programming tool to:
1. **Generate Secure Boilerplate Code**: Assisted in structuring ASP.NET Core MVC controllers, models, and Razor views adhering to best security practices.
2. **Debug & Identify Security Vulnerabilities**: Guided the implementation of dynamic role claim creation, `ReturnUrl` redirection logic, and cookie sign-out routines.
3. **Refactor & Document**: Standardized code formatting and created clean documentation in English.

---

## 🚀 How to Run the Application

1. **Clone the Repository**:
   ```bash
   git clone [https://github.com/preizeinguuna/SafeVault.git](https://github.com/preizeinguuna/SafeVault.git)
   cd SafeVault

   ## Build

```bash
dotnet build
```

Build status:

```text
Build succeeded
```
