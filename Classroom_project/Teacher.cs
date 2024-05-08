public class Teacher : ISchoolAdmin {
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
        List<IQuestion> AssignmentQuestions = new List<IQuestion>();
        ListClasses();
        Console.WriteLine("\nWhat class is this assignment for?:");
        if (!int.TryParse(Console.ReadLine(), out int classSelection) || classSelection < 1 || classSelection > Classes.Count) {
            Console.WriteLine("Invalid selection. Please try again.");
            Utilities.PressToContinue();
        }
        classSelection -= 1;

        Console.WriteLine("What's the name of this assignment?");
        string assignmentName = Console.ReadLine();

        bool creatingQuestions = true;
        while (creatingQuestions) {
            Console.WriteLine("What type of question?:");
            Console.WriteLine("1. Multiple Choice Question");
            Console.WriteLine("2. True/False Question");
            Console.WriteLine("3. Set Question");
            Console.WriteLine("4. Done adding questions");
            string option = Console.ReadLine();
            switch (option) {
                case "1":
                    IQuestion question = CreateMultipleChoiceQuestion();
                    AssignmentQuestions.Add(question);
                    break;
                case "2":
                    Console.WriteLine("True/False Question");
                    break;
                case "3":
                    Console.WriteLine("Set Question");
                    break;
                case "4":
                    Console.WriteLine("Done adding questions");
                    creatingQuestions = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
        
        Assignment newAssignment = new Assignment(Classes[classSelection].ClassroomName, assignmentName, AssignmentQuestions);
        Classes[classSelection].AddAssignment(newAssignment);

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
            Console.WriteLine($"{Name} is not teaching any classes currently.");
            return;
        }
        for (int i = 0; i < classes.Count; i++) {
            Console.WriteLine($"{i+1}. Class Title: {classes[i].ClassroomName}\tTaught by: {Name}");
        }
    }

    public void GradeHomework() {
        foreach (Classroom classroom in Classes) {
            classroom.ListStudents();
        }
    }

    public IQuestion CreateMultipleChoiceQuestion() {
        Console.WriteLine("What is the question?");
        string question = Console.ReadLine();
        int correctAnswerChoice = 0;
        List<string> choices = new List<string>();

        Console.WriteLine("What are the answer choices? (five choices!):");
        for (int i = 0; i < 5; i++) {
            Console.WriteLine($"Option {i+1}.");
            string choice = Console.ReadLine();
            choices.Add(choice);
        }

        Console.WriteLine("\nWhich choice is the correct answer?:");
        correctAnswerChoice = Convert.ToInt32(Console.ReadLine());        

        correctAnswerChoice -= 1;

        return new MultipleChoiceQuestion(question, choices, correctAnswerChoice);
    }

    public Classroom FindClassByName(string className) {
        return classes.FirstOrDefault(c => c.ClassroomName.Equals(className, StringComparison.OrdinalIgnoreCase));
    }
}
