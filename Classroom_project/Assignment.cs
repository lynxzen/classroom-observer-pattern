public class Assignment {
    public string FromClass { get; set; }
    public string Name { get; set; }
    public string Questions { get; set; }
    public string Answers { get; set; }

    public Assignment(string fromClass, string name, string questions, string answers) {
        FromClass = fromClass;
        Name = name;
        Questions = questions;
        Answers = answers;
    }
}
