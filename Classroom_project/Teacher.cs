public class Teacher : ISchoolAdmin, ITextInterface {
    private string name;
    public string Name {
        get { return name; }
        set { name = value; }
    }

    private List<Classroom> classes = new List<Classroom>();
    public List<Classroom> Classes {
        get { return classes; }
    }

    public void CreateAssignment() {
        Console.WriteLine("Enter the class name for the assignment:");
        string fromClass = Console.ReadLine();
        Classroom classToAddAssignment = FindClassByName(fromClass);
        if (classToAddAssignment != null) {
            Console.WriteLine("Enter the name of the assignment:");
            string assignmentName = Console.ReadLine();
            Console.WriteLine("Enter the questions:");
            string questions = Console.ReadLine();
            Console.WriteLine("Enter the answers:");
            string answers = Console.ReadLine();
            Assignment newAssignment = new Assignment(fromClass, assignmentName, questions, answers);
            classToAddAssignment.AddAssignment(newAssignment);
            Console.WriteLine("Assignment added successfully.");
            Utilities.PressToContinue();
        } 
        else {
            Console.WriteLine($"No class found with the name {fromClass}. Assignment not created.");
            Utilities.PressToContinue();
        }
    }

    public void CreateClass() {
        Console.WriteLine("\nEnter a class title:");
        string NewClassroomName = Console.ReadLine();
        Classroom NewClass = new Classroom() { ClassroomName = NewClassroomName };
        classes.Add(NewClass);
        Console.WriteLine($"{Name} started a new class: {NewClassroomName}");
        Utilities.PressToContinue();
    }

    public void AddClass(Classroom classroom) {
        classes.Add(classroom);
    }

    public void ListClasses() {
        if (classes.Count == 0) {
            Console.WriteLine($"\n{Name} is not teaching any classes currently.");
            Utilities.PressToContinue();
            return;
        }

        Console.WriteLine($"\n{Name} is teaching the following classes:");
        foreach (Classroom classroom in classes) {
            Console.WriteLine($"\nClassroom Name: {classroom.ClassroomName}");
            Console.WriteLine($"  Number of Assignments: {classroom.Assignments.Count}");
            Console.WriteLine($"  Number of Students: {classroom.Students.Count}");
        }
        Utilities.PressToContinue();
    }


    public void TextInterface() {
        bool keepRunning = true;
        while (keepRunning) {
            Console.Clear(); // Clears the console for a cleaner interface
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine("|            Teacher Menu           |");
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine("| 1. Create an Assignment           |");
            Console.WriteLine("| 2. Create a Class                 |");
            Console.WriteLine("| 3. List Classes                   |");
            Console.WriteLine("| 4. Exit                           |");
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine("Select an option by entering a number:");

            string option = Console.ReadLine();

            switch (option) {
                case "1":
                    CreateAssignment();
                    break;
                case "2":
                    CreateClass();
                    break;
                case "3":
                    ListClasses();
                    break;
                case "4":
                    Console.WriteLine("Exiting menu.");
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            if (keepRunning) {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }

    public Classroom FindClassByName(string className) {
        return classes.FirstOrDefault(c => c.ClassroomName.Equals(className, StringComparison.OrdinalIgnoreCase));
    }
}
