public class MultipleChoiceQuestion : IQuestion {
    public string Question { get; set; }
    private int correctAnswerIndex;  
    public List<string> Options { get; set; }  

    public string Answer {
        get => Options[correctAnswerIndex]; 
        set {  
            if (Options.Contains(value)) {
                correctAnswerIndex = Options.IndexOf(value);
            } else {
                throw new ArgumentException("The answer must be one of the predefined options.");
            }
        }
    }

    public MultipleChoiceQuestion(string question, List<string> options, int correctAnswerIndex) {
        Question = question;
        Options = options;
        this.correctAnswerIndex = correctAnswerIndex;
    }

    public void Display() {
        Console.WriteLine($"{Question}");
        for (int i = 0; i < Options.Count; i++) {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
    }
}
