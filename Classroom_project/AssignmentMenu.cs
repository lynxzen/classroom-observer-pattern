public class AssignmentMenu : IMenu {
    private Assignment assignment;

    public AssignmentMenu(Assignment assignment) {
        this.assignment = assignment;
    }

    public void DisplayMenu() {
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("|             Assignment            |");
        Console.WriteLine("+-----------------------------------+");
    }

    public IMenu HandleMenuInput(string option) {
        if (assignment == null) {
            Console.WriteLine("No assignment data!");
        }
        return this;
    }
}
