---
title: ".NET Framework to .NET 9"
description: "Modernize ASP.NET MVC 5 apps to .NET 9 with EF Core and cloud-native architecture"
authors: ["marconsilva"]
category: "Code Modernization"
industry: "Education"
services: ["Azure App Service", "Azure SQL Database", "Application Insights"]
languages: [".NET", "C#"]
frameworks: ["ASP.NET Core", "Entity Framework Core"]
modernizationTools: [".NET Upgrade Assistant"]
agenticTools: []
tags: ["migration", "entity-framework", "identity", "dependency-injection"]
extensions: ["github.copilot"]
thumbnail: ""
video: ""
version: "1.0.0"
---

## Build & Application Screenshots

> These screenshots document the **pre-migration** state of the Northwind Tech University application — a .NET Framework 4.8 / ASP.NET MVC 5 project targeting migration to .NET 9.

### ✅ Successful Build

Built with MSBuild v17.14 (VS 2022 Build Tools) targeting .NET Framework 4.8 — 0 errors, 1 warning (Unity.Abstractions binding redirect):

![Build Success](assets/screenshots/00-build-success.png)

### Application UI — Dashboard

Home page with Bootstrap 3 jumbotron, stat panels (Students, Courses, Enrollments, Faculty), and quick-action buttons:

![Dashboard](assets/screenshots/08-app-dashboard.png)

### Application UI — Student List

CRUD table with Edit/Details/Delete actions per row, striped Bootstrap table styling:

![Students](assets/screenshots/09-app-students.png)

### Application UI — Course List

Course catalog with department, credits, and instructor columns:

![Courses](assets/screenshots/10-app-courses.png)

> **Note:** The app requires IIS/IIS Express + SQL Server LocalDB for full runtime (System.Web pipeline). The UI screenshots above are rendered from the app's actual Razor view markup, CSS, and Bootstrap 3 theme served statically. Data values are representative samples.

---

### Code Structure (Reference)

#### Project Structure & Technology Stack

![Project Structure](assets/screenshots/01-project-structure.png)

#### Domain Models

Entity classes: `Student`, `Course`, `Enrollment` — with data annotations and navigation properties:

![Domain Models](assets/screenshots/02-models.png)

#### Data Access Layer

EF6 `DbContext` with fluent API configuration and the repository interface:

![Data Layer](assets/screenshots/03-data-layer.png)

#### Controllers

`HomeController` (dashboard with synchronous DB calls) and `StudentController` (full CRUD with mixed patterns):

![Controllers](assets/screenshots/04-controllers.png)

#### Razor Views

Shared layout (Bootstrap 3 navbar) and the Home/Index dashboard view:

![Razor Views](assets/screenshots/05-views.png)

#### Configuration Files

`Web.config` (connection strings, assembly bindings, OWIN) and `packages.config` (NuGet dependencies):

![Configuration](assets/screenshots/06-configuration.png)

#### Project File

Legacy `.csproj` format targeting .NET Framework 4.8 with `System.Web` references:

![Project File](assets/screenshots/07-csproj.png)
