public class TeacherMenu : IMenu {
    private Teacher teacher;

    public TeacherMenu(Teacher teacher) {
        this.teacher = teacher;
    }

    public void DisplayMenu() {
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("|            Teacher Menu           |");
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("| 1. Create Assignment              |");
        Console.WriteLine("| 2. Create Class                   |");
        Console.WriteLine("| 3. List Classes                   |");
        Console.WriteLine("| 4. Grade Homework                 |");
        Console.WriteLine("| 5. Back                           |");
        Console.WriteLine("+-----------------------------------+");
    }

    public IMenu HandleMenuInput(string option) {
        if (teacher == null) {
            Console.WriteLine("No teacher data!");
            return this;
        }
        switch (option) {
            case "1":
                teacher.CreateAssignment();
                return this;
            case "2":
                teacher.CreateClass();
                return this;
            case "3":
                teacher.ListClasses();
                return this;
            case "4":
                //TODO implement this
                GradeHomework();
                return this;
            case "5":
                return null;
            default:
                Console.WriteLine("\nInvalid option!");
                return this;
        }
        return this;
    }

    public void GradeHomework() {
        teacher.GradeHomework();
        Utilities.PressToContinue();
    }
}
