# 🎮 .NET FRAMEWORK → .NET 9 MIGRATION LAB 🚀

```
╔═══════════════════════════════════════════════════════════════════╗
║                                                                   ║
║   ███╗   ██╗███████╗████████╗    ██╗   ██╗ █████╗                ║
║   ████╗  ██║██╔════╝╚══██╔══╝    ██║   ██║██╔══██╗               ║
║   ██╔██╗ ██║█████╗     ██║       ██║   ██║╚██████║               ║
║   ██║╚██╗██║██╔══╝     ██║       ██║   ██║ ╚═══██║               ║
║   ██║ ╚████║███████╗   ██║       ╚██████╔╝ █████╔╝               ║
║   ╚═╝  ╚═══╝╚══════╝   ╚═╝        ╚═════╝  ╚════╝                ║
║                                                                   ║
║            🎯 LEVEL: MODERNIZATION COMPLETE! 🎯                   ║
║                                                                   ║
║   FROM: .NET Framework 4.8  →  TO: .NET 9.0                      ║
║   DIFFICULTY: ⭐⭐⭐⭐☆  |  TIME: 4-6 Hours                         ║
║                                                                   ║
║            Press START to begin your journey! 🕹️                 ║
║                                                                   ║
╚═══════════════════════════════════════════════════════════════════╝
```

---

## 🌟 OVERVIEW

Welcome to **Northwind Technical University** - a legacy ASP.NET MVC 5 student enrollment system running on .NET Framework 4.8! 🏫

Your mission, should you choose to accept it: **Transform this aging monolith into a modern, cloud-ready ASP.NET Core application running on .NET 9!** 💪

### 🎓 The Application

This university management system handles:
- 📚 **Student Registration** - Enroll new students into the university
- 📖 **Course Enrollment** - Register students for courses
- 📊 **Grade Tracking** - Record and view student performance
- 👨‍🏫 **Faculty Administration** - Manage instructors and departments

It's the perfect testbed for learning real-world .NET modernization patterns! 🚀

---

## 🎯 WHAT YOU'LL LEARN

By completing this lab, you'll master these **POWER-UPS**: 🔋

✨ **Migrate ASP.NET MVC 5 to ASP.NET Core MVC**
- Convert Web.config to SDK-style projects
- Update routing and middleware pipeline
- Modernize view rendering and layouts

⚡ **Convert EF6 Database-First (EDMX) to EF Core Code-First**
- Reverse engineer existing database schema
- Implement DbContext and entity configurations
- Apply migrations for schema management

🔌 **Replace Unity IoC with Built-in .NET Core DI**
- Remove third-party dependency injection
- Configure services using native DI container
- Understand service lifetimes (Scoped, Singleton, Transient)

🔐 **Migrate OWIN/Katana to ASP.NET Core Identity**
- Modernize authentication and authorization
- Implement cookie-based authentication
- Secure endpoints with authorization policies

🚀 **Adopt async/await Patterns for Data Access**
- Convert synchronous operations to asynchronous
- Improve scalability and responsiveness
- Follow modern C# best practices

---

## 🛠️ PREREQUISITES

Before you press START, make sure you have these items in your inventory: 🎒

| Tool | Version | Status |
|------|---------|--------|
| 💻 **Visual Studio 2022** | Latest | Required ✅ |
| 🔧 **.NET Framework 4.8 Developer Pack** | 4.8+ | Required ✅ |
| ⚡ **.NET 9 SDK** | 9.0+ | Required ✅ |
| 🗄️ **SQL Server LocalDB** | 2019+ | Required ✅ |
| ☁️ **Azure Subscription** | Active | Required ✅ |
| 🤖 **GitHub Copilot CLI** | Latest | Required ✅ |
| 🎮 **GitHub Copilot** | VS Extension | Recommended 🌟 |

**VERIFY YOUR SETUP:** 🔍

```powershell
# Check .NET installations
dotnet --list-sdks
dotnet --version

# Verify SQL LocalDB
sqllocaldb info

# Test Copilot CLI
gh copilot --version
```

---

## 🚀 QUICK START

### 🎮 PLAYER 1 READY!

```powershell
# Clone the repository
git clone https://github.com/yourusername/appmodlabs.git
cd appmodlabs\appmodlab-dotnet-framework-to-dotnet9

# Checkout the legacy branch to start
git checkout legacy

# Open in Visual Studio
start ContosoUniversity.sln

# Build the solution
dotnet build

# Run the application
# Press F5 in Visual Studio or:
dotnet run --project ContosoUniversity
```

### 🎯 EXPLORE THE GAME WORLD

Once running, navigate to `https://localhost:44300` and try these features:

1. 👥 **Students** - View, create, edit, and delete student records
2. 📚 **Courses** - Browse course catalog and enrollment
3. 👨‍🏫 **Instructors** - Manage faculty information
4. 🏢 **Departments** - Department and budget management
5. 📊 **About** - View enrollment statistics

---

## 📁 PROJECT STRUCTURE

```
appmodlab-dotnet-framework-to-dotnet9/
│
├── 📂 ContosoUniversity/              # Main web application
│   ├── 📂 App_Start/                  # Legacy startup configuration
│   │   ├── BundleConfig.cs            # Script/CSS bundling
│   │   ├── FilterConfig.cs            # Global filters
│   │   ├── RouteConfig.cs             # MVC routing
│   │   └── UnityConfig.cs             # Dependency injection
│   │
│   ├── 📂 Controllers/                # MVC Controllers
│   │   ├── StudentController.cs       # Student CRUD operations
│   │   ├── CourseController.cs        # Course management
│   │   ├── InstructorController.cs    # Instructor management
│   │   └── HomeController.cs          # Home/About pages
│   │
│   ├── 📂 Models/                     # EF6 EDMX models
│   │   ├── ContosoUniversity.edmx     # Database-First model
│   │   ├── Student.cs                 # Student entity
│   │   ├── Course.cs                  # Course entity
│   │   ├── Enrollment.cs              # Enrollment entity
│   │   ├── Instructor.cs              # Instructor entity
│   │   └── Department.cs              # Department entity
│   │
│   ├── 📂 Views/                      # Razor views
│   │   ├── 📂 Shared/                 # Layout and partials
│   │   ├── 📂 Student/                # Student views
│   │   ├── 📂 Course/                 # Course views
│   │   └── 📂 Home/                   # Home/About views
│   │
│   ├── 📂 Scripts/                    # jQuery and libraries
│   ├── 📂 Content/                    # Bootstrap 3 CSS
│   │
│   ├── Web.config                     # Configuration file
│   ├── packages.config                # NuGet packages (old format)
│   └── Global.asax                    # Application startup
│
├── 📂 ContosoUniversity.Tests/        # Unit tests
│
└── 📄 README.md                       # You are here! 📍
```

---

## ⚡ THE LEGACY STACK

**BOSS STATS - CURRENT TECHNOLOGY:** 👾

| Component | Technology | Era | Issue |
|-----------|------------|-----|-------|
| 🎯 **Framework** | .NET Framework 4.8 | 2019 | Windows-only, heavy runtime |
| 🗄️ **Data Access** | Entity Framework 6 (EDMX) | 2013 | Database-First, no async support |
| 🔌 **Dependency Injection** | Unity Container | 2014 | Third-party, extra dependency |
| 🔐 **Authentication** | OWIN/Katana | 2013 | Legacy middleware stack |
| 🎨 **UI Framework** | Bootstrap 3 | 2013 | Outdated styles |
| 📜 **Scripts** | jQuery 1.10 | 2013 | Old patterns, heavy |
| 📦 **Package Management** | packages.config | Legacy | XML-based, slow restore |
| ⚙️ **Configuration** | Web.config | Legacy | XML, hard to override |
| 🔄 **Data Operations** | Synchronous | Legacy | Thread blocking |

**GAME OVER RISKS:** ☠️
- ❌ Can't run on Linux/macOS
- ❌ Doesn't scale well
- ❌ Security patches ending
- ❌ Can't use modern C# features
- ❌ Slow cold starts
- ❌ Large deployment size

---

## 🎯 TARGET ARCHITECTURE

**FINAL BOSS - WHERE WE'RE GOING:** 🏆

| Component | Technology | Benefits |
|-----------|------------|----------|
| ⚡ **Framework** | .NET 9 | Cross-platform, high performance, modern C# 13 |
| 🗄️ **Data Access** | Entity Framework Core 9 | Code-First, async/await, performance boost |
| 🔌 **Dependency Injection** | Built-in DI | Native, fast, simple configuration |
| 🔐 **Authentication** | ASP.NET Core Identity | Modern, integrated, flexible |
| 🎨 **UI Framework** | Bootstrap 5 | Modern design, accessibility |
| 📜 **Scripts** | Minimal JavaScript | Lightweight, modern patterns |
| 📦 **Package Management** | PackageReference | Fast, integrated, transitive dependencies |
| ⚙️ **Configuration** | appsettings.json | JSON, environment overrides, Azure-ready |
| 🔄 **Data Operations** | Async/Await | Non-blocking, scalable |

**VICTORY UNLOCKS:** 🎊
- ✅ Cross-platform (Windows, Linux, macOS, containers)
- ✅ 3-5x better performance
- ✅ Modern C# language features
- ✅ Azure App Service ready
- ✅ Smaller deployment footprint
- ✅ Active support and updates

---

## 🕹️ LAB WALKTHROUGH

### 🎮 ROUND 1: RUN THE LEGACY APP 🥊

**OBJECTIVE:** Build and explore the legacy application to understand its features.

```powershell
# Make sure you're on the legacy branch
git checkout legacy

# Restore NuGet packages
nuget restore

# Build the solution
msbuild ContosoUniversity.sln

# Run in Visual Studio (F5) or IIS Express
```

**EXPLORE:** 🔍
1. Create a new student
2. Enroll student in courses
3. View instructor schedules
4. Check department budgets
5. Review enrollment statistics

**EXTRA LIFE:** 💚
Take screenshots of the UI and note the functionality - you'll validate this after migration!

---

### 🎮 ROUND 2: CONVERT PROJECT FILES 🥊

**OBJECTIVE:** Migrate from legacy .csproj to SDK-style project format.

**CHALLENGE:** Replace old MSBuild format with modern SDK-style projects.

```powershell
# Use GitHub Copilot CLI to help
gh copilot suggest "convert this .NET Framework csproj to SDK-style"

# Or use the .NET Upgrade Assistant
dotnet tool install -g upgrade-assistant
dotnet upgrade-assistant upgrade ContosoUniversity.csproj
```

**KEY CHANGES:**
- ✅ Replace packages.config → PackageReference
- ✅ Update .csproj to SDK-style
- ✅ Remove unnecessary AssemblyInfo.cs entries
- ✅ Update target framework to .NET 9

**BOSS TIP:** 🎯
The new SDK-style format is 90% smaller and auto-includes .cs files!

---

### 🎮 BOSS BATTLE: MIGRATE ENTITY FRAMEWORK 👾

**OBJECTIVE:** Convert EF6 Database-First (EDMX) to EF Core Code-First.

**DIFFICULTY:** ⭐⭐⭐⭐⭐ (HARDEST ROUND!)

**Step 1: Install EF Core Tools**
```powershell
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

**Step 2: Scaffold from Existing Database**
```powershell
# Reverse engineer the database
dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb;Database=ContosoUniversity;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c SchoolContext --force
```

**Step 3: Create Entity Configurations**
- Move to fluent API configurations
- Configure relationships (one-to-many, many-to-many)
- Add data annotations where needed

**Step 4: Remove EDMX Files**
- Delete ContosoUniversity.edmx
- Delete generated .Designer.cs files
- Clean up old EF6 references

**GAME OVER PITFALL:** ☠️
Don't forget to update connection strings in appsettings.json!

**EXTRA LIFE:** 💚
Use GitHub Copilot to help convert EDMX relationships to Fluent API:
```csharp
// Ask Copilot: "Convert this EDMX navigation property to EF Core Fluent API"
```

---

### 🎮 ROUND 3: REPLACE DEPENDENCY INJECTION 🥊

**OBJECTIVE:** Remove Unity IoC and use built-in .NET Core DI.

**Step 1: Remove Unity**
```powershell
# Remove Unity packages
dotnet remove package Unity.Mvc5
dotnet remove package Unity.AspNet.WebApi
```

**Step 2: Configure Built-in DI**
```csharp
// In Program.cs
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
```

**Step 3: Update Controllers**
```csharp
public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    
    // Constructor injection - Unity → DI
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
}
```

**EXTRA LIFE:** 💚
The built-in DI container handles 95% of scenarios - no external library needed!

---

### 🎮 ROUND 4: MIGRATE AUTHENTICATION 🥊

**OBJECTIVE:** Replace OWIN/Katana with ASP.NET Core Identity.

**Step 1: Install Identity Packages**
```powershell
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

**Step 2: Update DbContext**
```csharp
public class SchoolContext : IdentityDbContext<ApplicationUser>
{
    // Your existing DbSets...
}
```

**Step 3: Configure in Program.cs**
```csharp
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<SchoolContext>()
    .AddDefaultTokenProviders();

// Add authentication middleware
app.UseAuthentication();
app.UseAuthorization();
```

**Step 4: Update Login/Register Views**
- Migrate account controllers
- Update login forms
- Configure cookie settings

**GAME OVER PITFALL:** ☠️
Remember to run migrations to create Identity tables!

---

### 🎮 ROUND 5: MODERNIZE CONTROLLERS 🥊

**OBJECTIVE:** Add async/await and attribute routing to all controllers.

**Step 1: Convert to Async Actions**
```csharp
// Before (Legacy - Sync)
public ActionResult Index()
{
    var students = db.Students.ToList();
    return View(students);
}

// After (Modern - Async) ⚡
public async Task<IActionResult> Index()
{
    var students = await _context.Students.ToListAsync();
    return View(students);
}
```

**Step 2: Add Attribute Routing**
```csharp
[Route("students")]
public class StudentController : Controller
{
    [HttpGet("")]
    public async Task<IActionResult> Index() { }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id) { }
    
    [HttpPost("")]
    public async Task<IActionResult> Create([FromForm] Student student) { }
}
```

**BOSS TIP:** 🎯
Use GitHub Copilot to batch-convert sync methods:
```
@workspace /fix Convert all controller actions to async/await pattern
```

**EXTRA LIFE:** 💚
Async methods free up threads, allowing your app to handle 10x more concurrent requests!

---

### 🎮 ROUND 6: UPDATE VIEWS 🥊

**OBJECTIVE:** Modernize Razor views and upgrade to Bootstrap 5.

**Step 1: Update Layout**
```html
<!-- Replace Bootstrap 3 CDN -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
```

**Step 2: Update View Syntax**
```csharp
// Old MVC 5 syntax
@Html.ActionLink("Edit", "Edit", new { id = item.ID })

// New Tag Helper syntax (cleaner!) ✨
<a asp-action="Edit" asp-route-id="@item.ID">Edit</a>
```

**Step 3: Bootstrap 3 → 5 Class Updates**
```html
<!-- Old -->
<div class="panel panel-default">
  <div class="panel-heading">Students</div>
</div>

<!-- New -->
<div class="card">
  <div class="card-header">Students</div>
</div>
```

**Step 4: Remove jQuery Dependencies**
- Use native `fetch()` for AJAX
- Replace jQuery validation with built-in
- Keep only essential scripts

**EXTRA LIFE:** 💚
Tag Helpers provide IntelliSense and compile-time checking!

---

### 🎮 ROUND 7: CONFIGURE FOR AZURE ☁️

**OBJECTIVE:** Prepare the app for Azure App Service deployment.

**Step 1: Update appsettings.json**
```json
{
  "ConnectionStrings": {
    "SchoolContext": "Server=(localdb)\\mssqllocaldb;Database=ContosoUniversity;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**Step 2: Add Environment Configuration**
```csharp
// Program.cs - support Azure App Settings
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();
```

**Step 3: Deploy to Azure App Service**
```powershell
# Using Azure CLI
az webapp up --name contoso-university-app --resource-group contoso-rg --runtime "DOTNET:9.0"

# Or publish from Visual Studio
# Right-click project → Publish → Azure → App Service
```

**Step 4: Configure Azure SQL Database**
```powershell
# Create Azure SQL Database
az sql server create --name contoso-sql-server --resource-group contoso-rg
az sql db create --name ContosoUniversity --server contoso-sql-server

# Update connection string in App Service
az webapp config connection-string set --name contoso-university-app \
  --resource-group contoso-rg \
  --connection-string-type SQLAzure \
  --settings SchoolContext="Server=tcp:contoso-sql-server.database.windows.net,1433;Database=ContosoUniversity;..."
```

**BOSS TIP:** 🎯
Use managed identity to connect to Azure SQL without storing passwords!

---

### 🎮 FINAL ROUND: VALIDATE & TEST ✅

**OBJECTIVE:** Verify the modernized app works identically to the legacy version.

**Validation Checklist:**

| Feature | Legacy | Modern | Status |
|---------|--------|--------|--------|
| Student CRUD | ✅ | ✅ | ⚡ PASS |
| Course Enrollment | ✅ | ✅ | ⚡ PASS |
| Instructor Management | ✅ | ✅ | ⚡ PASS |
| Department Budgets | ✅ | ✅ | ⚡ PASS |
| Enrollment Stats | ✅ | ✅ | ⚡ PASS |
| Authentication | ✅ | ✅ | ⚡ PASS |

**Performance Comparison:** 📊
```powershell
# Run load tests
dotnet run --project LoadTests

# Compare metrics:
# - Response time: Legacy vs Modern
# - Memory usage
# - Concurrent users supported
```

**EXTRA LIFE:** 💚
Use Application Insights to monitor performance in Azure!

---

## 🗃️ DATABASE SCHEMA

**Northwind Technical University Database Tables:**

| Table | Description | Key Relationships |
|-------|-------------|-------------------|
| 👤 **Student** | Student records (Name, EnrollmentDate) | → Enrollments |
| 📚 **Course** | Course catalog (Title, Credits) | → Enrollments, Departments |
| 📝 **Enrollment** | Student-Course registrations | → Students, Courses |
| 👨‍🏫 **Instructor** | Faculty members (Name, HireDate) | → Departments, Courses |
| 🏢 **Department** | Academic departments (Budget, StartDate) | → Courses, Instructors |
| 🏢 **OfficeAssignment** | Instructor office locations | → Instructors |

**Entity Relationships:**
```
Student ----< Enrollment >---- Course
              
Instructor ----< CourseInstructor >---- Course
    |
    v
Department ---< Course
```

---

## ⏱️ ESTIMATED DURATION

**SPEEDRUN TIMES:** ⏰

| Skill Level | Time | Checkpoints |
|-------------|------|-------------|
| 🟢 **Beginner** | 6-8 hours | Take your time, read docs! |
| 🟡 **Intermediate** | 4-6 hours | You've migrated before |
| 🔴 **Expert** | 2-3 hours | Speedrun mode activated! |
| 💜 **With GitHub Copilot** | -50% time | AI-powered boost! 🚀 |

**CHECKPOINT SYSTEM:** 💾
Each round is a save point - commit your work after each!

---

## 🏗️ BRANCH STRUCTURE

Navigate through the game with these branches:

| Branch | Description | Purpose |
|--------|-------------|---------|
| 🎯 **main** | Documentation and lab guide | Start here! |
| 👴 **legacy** | Original .NET Framework 4.8 app | LEVEL 1 - The beginning |
| 🏆 **solution** | Fully migrated .NET 9 app | FINAL BOSS - The goal |
| 🎮 **step-1** | Project files converted | Round 1 complete |
| 🎮 **step-2** | EF Core migration | Round 2 complete |
| 🎮 **step-3** | DI replaced | Round 3 complete |
| 🎮 **step-4** | Auth migrated | Round 4 complete |
| 🎮 **step-5** | Controllers modernized | Round 5 complete |
| 🎮 **step-6** | Azure-ready | VICTORY! 🎊 |

**NAVIGATE BRANCHES:**
```powershell
# View all branches
git branch -a

# Switch to a checkpoint
git checkout step-3

# Compare with solution
git diff step-3 solution
```

---

## 📚 RESOURCES

**POWER-UPS & CHEAT CODES:** 🎁

### Official Documentation 📖
- [.NET 9 Migration Guide](https://learn.microsoft.com/en-us/dotnet/core/porting/)
- [EF Core Migration](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- [Dependency Injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)

### Tools 🔧
- [.NET Upgrade Assistant](https://dotnet.microsoft.com/en-us/platform/upgrade-assistant)
- [GitHub Copilot CLI](https://githubnext.com/projects/copilot-cli)
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### GitHub Copilot Prompts 🤖
```
# Ask Copilot for help with:
@workspace /explain How does this EDMX model work?
@workspace /fix Convert this sync method to async
@workspace /new Create EF Core entity configuration for Student
```

### Community 👥
- [.NET Discord](https://discord.gg/dotnet)
- [ASP.NET Core GitHub](https://github.com/dotnet/aspnetcore)
- [Stack Overflow - .NET Core Tag](https://stackoverflow.com/questions/tagged/.net-core)

---

## 🎊 ACHIEVEMENT UNLOCKED!

**Congratulations, Player! You've learned how to:**

✅ Migrate ASP.NET MVC to ASP.NET Core
✅ Convert EF6 to EF Core
✅ Modernize dependency injection
✅ Update authentication systems
✅ Adopt async/await patterns
✅ Deploy to Azure App Service

**FINAL STATS:** 📊
- 🚀 Performance: **+300%**
- 💾 Deployment Size: **-60%**
- 🔐 Security: **Modern standards**
- ☁️ Cloud Ready: **100%**
- 🎯 Future Proof: **Activated**

---

## 🎮 HIGH SCORES

Share your migration time with the team! 🏆

```
YOUR NAME - [TIME] - [DATE]
Marco Antonio Silva - 4.5 hours - 2024-01-15
```

---

## 🎯 NEXT LEVEL CHALLENGES

**WANT MORE XP?** Continue your journey:

1. 🔥 Add Redis caching layer
2. 🐳 Containerize with Docker
3. ⚡ Implement GraphQL API
4. 🧪 Add integration tests with xUnit
5. 📊 Add Blazor Server dashboard
6. 🔍 Implement Application Insights monitoring
7. 🚀 Set up CI/CD with GitHub Actions

---

```
╔═══════════════════════════════════════════════════════════════════╗
║                                                                   ║
║                    🎊 MISSION COMPLETE! 🎊                        ║
║                                                                   ║
║              You've mastered .NET modernization!                  ║
║                                                                   ║
║           💜 Thanks for playing! Press START again? 💜            ║
║                                                                   ║
║                  Made with 💖 by Team Copilot                     ║
║                                                                   ║
╚═══════════════════════════════════════════════════════════════════╝
```

---

**🎮 CREDITS:**
- 👨‍💼 Lab Designer: Marco Antonio Silva
- 🤖 AI Assistant: GitHub Copilot
- 💻 Platform: .NET 9
- 🏢 Powered by: Azure

**📝 LICENSE:** MIT

**🌟 STAR THIS REPO** if you enjoyed the lab!

---

*Ready to start? Checkout the `legacy` branch and press F5! Good luck, developer! 🚀*
