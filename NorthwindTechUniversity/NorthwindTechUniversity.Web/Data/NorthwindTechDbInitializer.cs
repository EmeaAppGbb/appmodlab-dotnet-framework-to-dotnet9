using NorthwindTechUniversity.Web.Models;

namespace NorthwindTechUniversity.Web.Data
{
    public static class NorthwindTechDbInitializer
    {
        public static void Seed(NorthwindTechContext context)
        {
            context.Database.EnsureCreated();

            if (context.Departments.Any())
                return; // Already seeded

            // Seed Departments
            var departments = new List<Department>
            {
                new Department { DepartmentId = 1, Name = "Computer Science", Budget = 500000m },
                new Department { DepartmentId = 2, Name = "Engineering", Budget = 750000m },
                new Department { DepartmentId = 3, Name = "Business Administration", Budget = 400000m },
                new Department { DepartmentId = 4, Name = "Mathematics", Budget = 350000m },
                new Department { DepartmentId = 5, Name = "Liberal Arts", Budget = 300000m }
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();

            // Seed Faculty
            var faculty = new List<Faculty>
            {
                new Faculty { FacultyId = 1, FirstName = "Robert", LastName = "Martin", Email = "rmartin@ntu.edu", DepartmentId = 1, HireDate = new DateTime(2010, 8, 15) },
                new Faculty { FacultyId = 2, FirstName = "Barbara", LastName = "Liskov", Email = "bliskov@ntu.edu", DepartmentId = 1, HireDate = new DateTime(2012, 9, 1) },
                new Faculty { FacultyId = 3, FirstName = "Donald", LastName = "Knuth", Email = "dknuth@ntu.edu", DepartmentId = 1, HireDate = new DateTime(2008, 1, 10) },
                new Faculty { FacultyId = 4, FirstName = "Grace", LastName = "Hopper", Email = "ghopper@ntu.edu", DepartmentId = 1, HireDate = new DateTime(2011, 3, 20) },
                new Faculty { FacultyId = 5, FirstName = "James", LastName = "Gosling", Email = "jgosling@ntu.edu", DepartmentId = 2, HireDate = new DateTime(2013, 7, 1) },
                new Faculty { FacultyId = 6, FirstName = "Ada", LastName = "Lovelace", Email = "alovelace@ntu.edu", DepartmentId = 4, HireDate = new DateTime(2009, 5, 15) },
                new Faculty { FacultyId = 7, FirstName = "Alan", LastName = "Turing", Email = "aturing@ntu.edu", DepartmentId = 4, HireDate = new DateTime(2010, 6, 23) },
                new Faculty { FacultyId = 8, FirstName = "Margaret", LastName = "Hamilton", Email = "mhamilton@ntu.edu", DepartmentId = 2, HireDate = new DateTime(2014, 2, 10) },
                new Faculty { FacultyId = 9, FirstName = "Dennis", LastName = "Ritchie", Email = "dritchie@ntu.edu", DepartmentId = 1, HireDate = new DateTime(2007, 11, 5) },
                new Faculty { FacultyId = 10, FirstName = "Ken", LastName = "Thompson", Email = "kthompson@ntu.edu", DepartmentId = 1, HireDate = new DateTime(2015, 1, 12) }
            };
            context.Faculties.AddRange(faculty);
            context.SaveChanges();

            // Update department heads
            departments[0].HeadFacultyId = 1;
            departments[1].HeadFacultyId = 5;
            departments[2].HeadFacultyId = null;
            departments[3].HeadFacultyId = 6;
            departments[4].HeadFacultyId = null;
            context.SaveChanges();

            // Seed Programs
            var programs = new List<AcademicProgram>
            {
                new AcademicProgram { ProgramId = 1, Name = "Bachelor of Science in Computer Science", DepartmentId = 1, RequiredCredits = 120, Description = "Comprehensive CS program" },
                new AcademicProgram { ProgramId = 2, Name = "Bachelor of Engineering", DepartmentId = 2, RequiredCredits = 128, Description = "General engineering program" },
                new AcademicProgram { ProgramId = 3, Name = "Master of Business Administration", DepartmentId = 3, RequiredCredits = 60, Description = "MBA program" }
            };
            context.Programs.AddRange(programs);
            context.SaveChanges();

            // Seed Courses
            var courses = new List<Course>
            {
                new Course { CourseId = 1, Title = "Introduction to Programming", Credits = 4, DepartmentId = 1, MaxCapacity = 30, Description = "Fundamentals of programming" },
                new Course { CourseId = 2, Title = "Data Structures and Algorithms", Credits = 4, DepartmentId = 1, MaxCapacity = 25, Description = "Core CS concepts" },
                new Course { CourseId = 3, Title = "Database Systems", Credits = 3, DepartmentId = 1, MaxCapacity = 30, Description = "Relational databases" },
                new Course { CourseId = 4, Title = "Web Development", Credits = 3, DepartmentId = 1, MaxCapacity = 28, Description = "Full-stack web dev" },
                new Course { CourseId = 5, Title = "Software Engineering", Credits = 4, DepartmentId = 1, MaxCapacity = 25, Description = "SDLC and best practices" },
                new Course { CourseId = 6, Title = "Operating Systems", Credits = 4, DepartmentId = 1, MaxCapacity = 20, Description = "OS internals" },
                new Course { CourseId = 7, Title = "Computer Networks", Credits = 3, DepartmentId = 1, MaxCapacity = 25, Description = "Networking fundamentals" },
                new Course { CourseId = 8, Title = "Machine Learning", Credits = 4, DepartmentId = 1, MaxCapacity = 20, Description = "ML algorithms and applications" },
                new Course { CourseId = 9, Title = "Calculus I", Credits = 4, DepartmentId = 4, MaxCapacity = 35, Description = "Differential calculus" },
                new Course { CourseId = 10, Title = "Linear Algebra", Credits = 3, DepartmentId = 4, MaxCapacity = 30, Description = "Matrices and vectors" },
                new Course { CourseId = 11, Title = "Engineering Mechanics", Credits = 4, DepartmentId = 2, MaxCapacity = 30, Description = "Statics and dynamics" },
                new Course { CourseId = 12, Title = "Thermodynamics", Credits = 3, DepartmentId = 2, MaxCapacity = 25, Description = "Heat and energy" },
                new Course { CourseId = 13, Title = "Marketing Fundamentals", Credits = 3, DepartmentId = 3, MaxCapacity = 40, Description = "Marketing basics" },
                new Course { CourseId = 14, Title = "Financial Accounting", Credits = 3, DepartmentId = 3, MaxCapacity = 35, Description = "Accounting principles" },
                new Course { CourseId = 15, Title = "Organizational Behavior", Credits = 3, DepartmentId = 3, MaxCapacity = 30, Description = "Management and leadership" },
                new Course { CourseId = 16, Title = "Statistics", Credits = 3, DepartmentId = 4, MaxCapacity = 35, Description = "Statistical analysis" },
                new Course { CourseId = 17, Title = "Ethics in Technology", Credits = 2, DepartmentId = 5, MaxCapacity = 40, Description = "Technology and society" },
                new Course { CourseId = 18, Title = "Technical Writing", Credits = 2, DepartmentId = 5, MaxCapacity = 25, Description = "Professional communication" },
                new Course { CourseId = 19, Title = "Cloud Computing", Credits = 3, DepartmentId = 1, MaxCapacity = 22, Description = "Cloud platforms and services" },
                new Course { CourseId = 20, Title = "Mobile App Development", Credits = 3, DepartmentId = 1, MaxCapacity = 24, Description = "iOS and Android development" }
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            // Seed Students
            var students = new List<Student>();
            var firstNames = new[] { "Emma", "Liam", "Olivia", "Noah", "Ava", "Ethan", "Sophia", "Mason", "Isabella", "William",
                                    "Mia", "James", "Charlotte", "Benjamin", "Amelia", "Lucas", "Harper", "Henry", "Evelyn", "Alexander",
                                    "Abigail", "Michael", "Emily", "Daniel", "Elizabeth", "Matthew", "Sofia", "Jackson", "Avery", "Sebastian",
                                    "Ella", "David", "Madison", "Joseph", "Scarlett", "Carter", "Victoria", "Owen", "Aria", "Wyatt",
                                    "Grace", "John", "Chloe", "Jack", "Camila", "Luke", "Penelope", "Jayden", "Riley", "Dylan" };
            var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
                                   "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
                                   "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
                                   "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
                                   "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts" };

            for (int i = 0; i < 50; i++)
            {
                students.Add(new Student
                {
                    StudentId = i + 1,
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Email = $"{firstNames[i].ToLower()}.{lastNames[i].ToLower()}@students.ntu.edu",
                    DateOfBirth = new DateTime(1998 + (i % 5), 1 + (i % 12), 1 + (i % 28)),
                    EnrollmentDate = new DateTime(2019 + (i % 4), 8 + (i % 2) * 4, 15),
                    ProgramId = (i % 3) + 1
                });
            }
            context.Students.AddRange(students);
            context.SaveChanges();

            // Seed Enrollments
            var enrollments = new List<Enrollment>();
            var semesters = new[] { "Fall 2023", "Spring 2024", "Fall 2024" };
            var grades = new[] { "A", "A-", "B+", "B", "B-", "C+", "C", null as string };
            var random = new Random(42);

            for (int i = 0; i < 100; i++)
            {
                enrollments.Add(new Enrollment
                {
                    EnrollmentId = i + 1,
                    StudentId = (i % 50) + 1,
                    CourseId = (i % 20) + 1,
                    Semester = semesters[i % 3],
                    Grade = grades[random.Next(grades.Length)],
                    EnrollmentDate = new DateTime(2023, 8 + (i % 3) * 4, 15)
                });
            }
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
