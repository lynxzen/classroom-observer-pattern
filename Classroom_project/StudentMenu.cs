public class StudentMenu : IMenu {
    private Student student;

    public StudentMenu(Student student) {
        this.student = student;
    }

    public void DisplayMenu() {
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("|            Student Menu           |");
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("| 1. List Assignments               |");
        Console.WriteLine("| 2. Do Homework                    |");
        Console.WriteLine("| 3. Enroll In Class                |");
        Console.WriteLine("| 4. Back                           |");
        Console.WriteLine("+-----------------------------------+");
    }

    public IMenu HandleMenuInput(string option) {
        if (student == null) {
            Console.WriteLine("No student data!");
        }
        switch (option) {
            case "1":
                ListAssignments();
                return this;
            case "2":
                return DoHomework();
            case "3":
                EnrollInClass();
                Utilities.PressToContinue();
                return this;
            case "4":
                SubmitHomework();
                return null;
            default:
                Console.WriteLine("\nInvalid option!");
                return this;
        }
        return this;
    }

    public void ListAssignments() {
        student.ListAssignments();
        Utilities.PressToContinue();
    }

    public IMenu DoHomework() {
        student.ListAssignments();
        Console.WriteLine("\nSelect an assignment by number:");
        //TODO rewrite this
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > student.Assignments.Count) {
            Console.WriteLine("Invalid selection. Please try again.");
            Utilities.PressToContinue();
            return this;
        }
        return new AssignmentMenu(student.Assignments[index - 1]);

    }

    public void EnrollInClass() {
        student.SchoolAttending.ListClasses();
        //TODO rewrite this
        Console.WriteLine("Enter the class identifier (e.g., '1-1' for the first teacher's first class):");
        string input = Console.ReadLine();
        string[] parts = input.Split('-');

        if (parts.Length != 2) {
            Console.WriteLine("Invalid input format. Please use the format 'TeacherNumber-ClassNumber'.");
            return;
        }

        if (!int.TryParse(parts[0], out int teacherIndex) || !int.TryParse(parts[1], out int classIndex)) {
            Console.WriteLine("Invalid numbers. Please ensure you enter valid integers.");
            return;
        }

        teacherIndex -= 1;
        classIndex -= 1;

        if (teacherIndex < 0 || teacherIndex >= student.SchoolAttending.Teachers.Count) {
            Console.WriteLine("Teacher index is out of range.");
            return;
        }

        if (classIndex < 0 || classIndex >= student.SchoolAttending.Teachers[teacherIndex].Classes.Count) {
            Console.WriteLine("Class index is out of range.");
            return;
        }

        var selectedClass = student.SchoolAttending.Teachers[teacherIndex].Classes[classIndex];
        Console.WriteLine($"You selected: {selectedClass.ClassroomName}, taught by {student.SchoolAttending.Teachers[teacherIndex].Name}"); 

        selectedClass.Subscribe(student);
        selectedClass.Students.Add(student);
    }

    public void SubmitHomework() {
        foreach (Assignment assignment in student.Assignments) {
            if (assignment.isCompleted) {
                assignment.StudentName = student.Name;
                student.CompletedAssignments.Add(assignment);                
            }
        }
    }
}
