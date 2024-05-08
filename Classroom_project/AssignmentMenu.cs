public class AssignmentMenu : IMenu {
    private Assignment assignment;
    public List<string> studentAnswers = new List<string>();

    public AssignmentMenu(Assignment assignment) {
        this.assignment = assignment;
    }

    public void DisplayMenu() {
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("|             Assignment            |");
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine();
        foreach (var question in assignment.Questions) {
            question.Display();
            Console.WriteLine("\n1) Answer Question 2) Submit");
        }
    }

    public IMenu HandleMenuInput(string option) {
        switch (option) {
            case "1":
                AnswerQuestion();
                return this;
            case "2":
                return SubmitHomework();
            default:
                Console.WriteLine("Invalid option!");
                return this;
        }
    }

    private void AnswerQuestion() {
        for (int i = 0; i < assignment.Questions.Count; i++) {
            Console.WriteLine("\nWhat answer do you select?:");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice) || choice < 1 || choice > assignment.Questions[i].Options.Count) {
                Console.WriteLine("Invalid selection. Please try again.");
                i--; // Decrement to repeat the question
                continue;
            }
            studentAnswers.Add(input);
        }
        Console.WriteLine("All answers collected, select '2' to submit homework.");
        Utilities.PressToContinue();
    }

    public IMenu SubmitHomework() {
        if (studentAnswers.Count != assignment.Questions.Count) {
            Console.WriteLine("Not all answers collected. Please complete all answers first.");
            return this;
        }
        assignment.StudentAnswers = studentAnswers;
        assignment.isCompleted = true;
        Console.WriteLine("Homework submitted successfully.");
        Utilities.PressToContinue();
        return null; 
    }

   }
