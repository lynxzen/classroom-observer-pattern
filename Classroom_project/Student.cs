public class Student : IObserver<Assignment>, ITextInterface {
    private string name;
    public string Name {
        get { return name; }
        set { name = value; }
    }

    public void OnNext(Assignment value) {
        Console.WriteLine($"{Name} received assignment: {value.Name}");
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

