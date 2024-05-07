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
        Console.WriteLine("| 4. Back                           |");
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
                return this;
            case "2":
                //TODO ViewTeachers();
                school.ListTeachers(); 
                Utilities.PressToContinue();
                return this;
            case "3":
                //TODO AddTeacher();
                school.CreateTeacher(); 
                Utilities.PressToContinue();
                return this;
            case "4":
                return null; 
            default:
                Console.WriteLine("\nInvalid option!");
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
        Console.WriteLine("Select a teacher by number:");
        //TODO rewrite this
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > school.Teachers.Count) {
            Console.WriteLine("Invalid selection. Please try again.");
            Utilities.PressToContinue();
            return this;
        }
        return new TeacherMenu(school.Teachers[index - 1]);
    }
}
