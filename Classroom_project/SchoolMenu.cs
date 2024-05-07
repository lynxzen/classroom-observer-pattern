public class SchoolMenu : IMenu {
    private School school;

    public SchoolMenu(School school) {
        this.school = school;
    }

    public void DisplayMenu() {
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("|         School Management         |");
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("| 1. Select Teacher                 |");
        Console.WriteLine("| 2. View Teachers                  |");
        Console.WriteLine("| 3. Add Teacher                    |");
        Console.WriteLine("| 4. Select Student                 |");
        Console.WriteLine("| 5. List Students                  |");
        Console.WriteLine("| 6. Add Student                    |");
        Console.WriteLine("| 7. Back                           |");
        Console.WriteLine("+-----------------------------------+");
    }

    public IMenu HandleMenuInput(string option) {
        if (school == null) {
            Console.WriteLine("No school data!");
            return this;
        }
        switch (option) {
            case "1":
                return SelectTeacher();                    
            case "2":
                ViewTeachers();
                return this;
            case "3":
                AddTeacher();
                return this;
            case "4":
                return SelectStudent();
            case "5":
                ListStudents();
                return this;
            case "6":
                AddStudent();
                return this;
            case "7":
                return null;
            default:
                Console.WriteLine("\nInvalid option!");
                Utilities.PressToContinue();
                return this;
        }
        return this;
    }

    public IMenu SelectTeacher() {
        if (school.Teachers.Count == 0) {
            Console.WriteLine("No teachers in school!");
            Utilities.PressToContinue();
            return this;
        }

        school.ListTeachers();
        Console.WriteLine("\nSelect a teacher by number:");
        //TODO rewrite this
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > school.Teachers.Count) {
            Console.WriteLine("Invalid selection. Please try again.");
            Utilities.PressToContinue();
            return this;
        }
        return new TeacherMenu(school.Teachers[index - 1]);
    }

    public void ViewTeachers() {
        school.ListTeachers();
        Utilities.PressToContinue();
    }

    public void AddTeacher() {
        school.CreateTeacher();
        Utilities.PressToContinue();
    }

    public IMenu SelectStudent() {
        if (school.Teachers.Count == 0) {
            Console.WriteLine("No students in school!");
            Utilities.PressToContinue();
            return this;
        }

        school.ListStudents();
        Console.WriteLine("\nSelect a student by number:");
        //TODO rewrite this
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > school.Teachers.Count) {
            Console.WriteLine("Invalid selection. Please try again.");
            Utilities.PressToContinue();
            return this;
        }
        return new StudentMenu(school.Students[index - 1]);
    }

    public void ListStudents() {
        school.ListStudents();
        Utilities.PressToContinue();
    }

    public void AddStudent() {
        school.CreateStudent(school);
        Utilities.PressToContinue();
    }
}
