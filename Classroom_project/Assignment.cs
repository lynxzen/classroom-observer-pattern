public class Assignment {
    public string FromClass { get; set; }
    public string StudentName { get; set; }
    public string Name { get; set; }
    public List<IQuestion> Questions { get; set; }
    public List<string> StudentAnswers { get; set; }

    public int pointsEarned = 0;
    public double score = 0.0;
    public bool isCompleted = false;

    public Assignment(string fromClass, string name, List<IQuestion> questionsAndAnswers) {
        FromClass = fromClass;
        Name = name;
        Questions = questionsAndAnswers;
    }
}
