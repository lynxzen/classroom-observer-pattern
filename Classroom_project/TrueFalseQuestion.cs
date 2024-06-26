public class TrueFalseQuestion : IQuestion {
    public string Question { get; set; }
    private int correctAnswerChoice;
    public List<string> Options { get; set; } = new List<string> { "True", "False" };

    public string Answer {
        get => Options[correctAnswerChoice];
        set {
            if (Options.Contains(value)) {
                correctAnswerChoice = Options.IndexOf(value);
            }
            else {
                Console.WriteLine("Not a valid choice!");
            }
        }
    }

    public TrueFalseQuestion(string question, int correctAnswerChoice) {
        Question = question;
        this.correctAnswerChoice = correctAnswerChoice;
    }

    public void Display() {
        Console.WriteLine(Question);
        for (int i = 0; i < Options.Count; i++) {
            Console.WriteLine($"{i+1}. {Options[i]}");
        }
    }
}
