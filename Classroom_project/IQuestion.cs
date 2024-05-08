public interface IQuestion {
    string Question { get; set; }
    string Answer { get; set; }
    List<string> Options { get; set; }
    void Display();
}
