public interface IMenuState {
    void DisplayMenu();
    IMenuState HandleMenuInput(string option);
}
