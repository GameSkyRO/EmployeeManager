# Employee Manager (AtestatV2)

A Windows Forms application built with C# designed to manage employees, teams, and internal applications. The project features a modern user interface powered by `Krypton.Toolkit` and relies on a MySQL database backend.

## Features

- **Role-Based Authentication**: Secure login system that checks credentials against the database and assigns appropriate access levels to users.
- **Application Directory**: Categorizes and displays internal software applications by their operational state:
  - Published
  - Beta
  - Alpha
- **Team & Employee Management**: Hierarchical view showing Teams that have access to applications, and the Employees belonging to those teams.
- **Administrative Capabilities**: Users with administrative privileges (Access Level = 1) can:
  - Add new Applications
  - Add new Employees
- **Detailed Employee Profiles**: Click on any employee to view their detailed profile, including their Role, Department, Email, Hiring Year, and Profile Picture.

## Technical Details

- **Language**: C#
- **UI Framework**: Windows Forms with [Krypton Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit) for enhanced styling.
- **Database**: MySQL (`MySql.Data` library)
  - Configured to connect to `localhost:3306`
  - Database Name: `atestat`
  - Default Credentials: User `root`, Password `root`

## Prerequisites

1. **.NET Environment**: Ensure your system supports compiling and running .NET Framework WinForms applications (Visual Studio recommended).
2. **MySQL Server**: You must have a local MySQL server running with a database named `atestat`. Ensure the following tables are correctly configured according to the DAO data structure:
   - `conectare` (Authentication): `Username`, `Password`, Access Level (`Acces`).
   - `apps` (Applications): `Nume` (Name), `Stare` (State), `Pagina` (URL/Description), `Acces` (Access Level).
   - `echipe` (Teams): `Nume` (Name), `prioritateAcc` (Access Priority).
   - `angajati` (Employees): `Nume`, `Email`, `An angajare` (Hiring Year), `Departament`, `Echipa` (Team), `Functie` (Role), `Imagine` (Image URL/Path).

## Getting Started

1. Set up your local MySQL database (`atestat`) to hold the project data.
2. Open the solution `AtestatV2.sln` in Visual Studio.
3. Restore any necessary NuGet packages (`MySql.Data`, `Krypton.Toolkit`).
4. Build and start the project from Visual Studio.