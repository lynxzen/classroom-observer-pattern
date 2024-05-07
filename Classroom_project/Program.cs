using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<School> schools = new List<School>(); // Assuming this is initialized correctly
        Stack<IMenu> menuStack = new Stack<IMenu>();
        IMenu currentMenu = new CanvasMenu(schools);
        menuStack.Push(currentMenu);

        while (menuStack.Any()) {
            Console.Clear();
            currentMenu.DisplayMenu();
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();
            IMenu nextMenu = currentMenu.HandleMenuInput(option);

            if (nextMenu == null) {
                menuStack.Pop();
                if (menuStack.Any()) {
                    currentMenu = menuStack.Peek();
                } 
                else {
                    break; 
                }
            } 
            else if (nextMenu != currentMenu) {
                currentMenu = nextMenu;
                menuStack.Push(currentMenu);
            }
        }
    }
}
