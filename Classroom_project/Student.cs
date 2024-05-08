public class Student : IObserver<Assignment> {
    private School schoolAttending;
    public School SchoolAttending {
        get { return schoolAttending; }
    }

    public Student(School school) {
        this.schoolAttending = school;
    }

    private string name;
    public string Name {
        get { return name; }
        set { name = value; }
    }

    private List<Assignment> assignments = new List<Assignment>();
    public List<Assignment> Assignments {
        get { return assignments; }
    }

    private List<Assignment> completedAssignments = new List<Assignment>();
    public List<Assignment> CompletedAssignments {
        get { return completedAssignments; }
    }


    public void ListAssignments() {
        if (Assignments.Count == 0) {
            Console.WriteLine("You have no assignments! :)");
            return;
        }

        Console.WriteLine("You currently have the following assignments:");
        for (int i = 0; i < Assignments.Count; i++) {
            Console.WriteLine($"{i+1}. {Assignments[i].Name}\t from your {Assignments[i].FromClass} class");
        }
    }

    public void OnNext(Assignment value) {
        Console.WriteLine($"{Name} received assignment: {value.Name}");
        assignments.Add(value);
    }

    public void OnError(Exception error) {
        Console.WriteLine($"Error for {Name}: {error.Message}");
    }

    public void OnComplete() {
        Console.WriteLine($"{Name} has completed receiving assignments.");
    }

    public void TextInterface() {
        Console.WriteLine("Student");
    }
}

