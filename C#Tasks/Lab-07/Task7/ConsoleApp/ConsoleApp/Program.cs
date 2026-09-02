namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>
                {
                    new Student { Name = "Ahmed",  Age = 20, Grade = 88.5, Department = "CS" },
                    new Student { Name = "Sara",   Age = 21, Grade = 76.0, Department = "IT" },
                    new Student { Name = "Omar",   Age = 22, Grade = 92.3, Department = "CS" },
                    new Student { Name = "Laila",  Age = 20, Grade = 65.4, Department = "IS" },
                    new Student { Name = "Youssef",Age = 23, Grade = 81.0, Department = "IT" },
                    new Student { Name = "Mona",   Age = 21, Grade = 95.7, Department = "CS" },
                    new Student { Name = "Kareem", Age = 22, Grade = 58.9, Department = "IS" },
                    new Student { Name = "Nour",   Age = 20, Grade = 87.2, Department = "IT" },
                    new Student { Name = "Hassan", Age = 24, Grade = 90.1, Department = "CS" },
                    new Student { Name = "Dina",   Age = 21, Grade = 72.6, Department = "IS" },
                };

            var highGradeStudents = students.Where(s => s.Grade > 85).ToList();// Where 
            Console.WriteLine("Students with Grade > 85:");
            for (int i = 0; i < highGradeStudents.Count(); i++)
            {
                Console.WriteLine($"{highGradeStudents[i].Name} : {highGradeStudents[i].Grade}");
            }

            var SortByGrade = students.OrderByDescending(s => s.Grade).ToList(); //OrderByDescending
            Console.WriteLine("\nStudents sorted by Grade (descending):");
            for (int i = 0; i < SortByGrade.Count(); i++)
            {
                Console.WriteLine($"{SortByGrade[i].Name} : {SortByGrade[i].Grade}");
            }

            var StudentsNames = students.Select(s => s.Name).ToList();// Select 
            Console.WriteLine("\nName of Students");
            for (int i = 0; i < StudentsNames.Count; i++)
            {
                Console.WriteLine($"Name : {StudentsNames[i]}");
            }

            Console.WriteLine($"\nAverage Grade of all Students is : {students.Average(s => s.Grade)}");

            Console.WriteLine($"\nHighest Grade of all Students : {students.Max(s => s.Grade)}");
            Console.WriteLine($"\nLowest Grade of all Students : {students.Min(s => s.Grade)}");

            Console.WriteLine($"\nNumber of Student in each Departments");
            var CountByDepartment = students
                                    .GroupBy(s => s.Department)
                                    .Select(g => new { Department = g.Key, Count = g.Count()}); // we used this to make it with labeled with names
                                     ////.ToDictionary(g =>g.Key , g =>g.Count()); 
            
            foreach (var c in CountByDepartment)
            {
                Console.WriteLine($"{c}");
            }

            Console.WriteLine("\n Top 3 Students");
            var Top3Students = students
                               .OrderByDescending(s => s.Grade)
                               .Take(3);
            foreach(var top in Top3Students)
            {
                Console.WriteLine($"{top.Name} : {top.Grade}");
            }
                               





        }
    }
}
