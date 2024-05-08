public class TrueFalseQuestion : IQuestion {
    public string Question { get; set; }
    private int correctAnswerChoice;
    public List<string> Options { get; set; }

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

    public TrueFalseQuestion(string question, List<string> options, int correctAnswerChoice) {
        Question = question;
        Options = options;
        this.correctAnswerChoice = correctAnswerChoice;
    }

    public void Display() {
        Console.WriteLine(Question);
        for (int i = 0; i < Options.Count; i++) {
            Console.WriteLine($"{i+1}. {Options[i]}");
        }
    }
}
