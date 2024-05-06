class Teacher : ISchoolAdmin {
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
        } 
        else {
            Console.WriteLine($"No class found with the name {fromClass}. Assignment not created.");
        }
    }

    public void CreateClass() {
        Console.WriteLine("Enter a class title:");
        string NewClassroomName = Console.ReadLine();
        Classroom NewClass = new Classroom() { ClassroomName = NewClassroomName };
        classes.Add(NewClass);
    }

    public void AddClass(Classroom classroom) {
        classes.Add(classroom);
    }

    public void ListClasses() {
        if (classes.Count == 0) {
            Console.WriteLine($"{Name} is not teaching any classes currently.");
            return;
        }

        Console.WriteLine($"{Name} is teaching the following classes:");
        foreach (Classroom classroom in classes) {
            Console.WriteLine($"Classroom Name: {classroom.ClassroomName}");
            Console.WriteLine($"  Number of Assignments: {classroom.Assignments.Count}");
            Console.WriteLine($"  Number of Students: {classroom.Students.Count}");
        }
    }

    public Classroom FindClassByName(string className) {
        return classes.FirstOrDefault(c => c.ClassroomName.Equals(className, StringComparison.OrdinalIgnoreCase));
    }
}
