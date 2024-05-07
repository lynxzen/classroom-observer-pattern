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

    static void PressToContinue() {
        Console.WriteLine("Press any key to continue!");
        Console.ReadKey();
    }

    static void AddTeacher(School school) {
        Console.WriteLine("Enter the teacher's name:");
        string name = Console.ReadLine();
        Teacher newTeacher = new Teacher() { Name = name };
        school.AddTeacher(newTeacher);
        Console.WriteLine("Teacher added successfully.");
    }

    static void AddClass(School school) {
        Console.WriteLine("Who is teaching this class?");
        school.ListTeachers();
        string teacherName = Console.ReadLine();
        Teacher selectedTeacher = school.FindTeacherByName(teacherName);
        selectedTeacher.CreateClass();
    }

    static void AddStudent(School school) {
        Console.WriteLine("Enter the student's name:");
        string studentName = Console.ReadLine();
        Console.WriteLine("Enter the class name to add the student to:");
        school.ListClasses();
        string className = Console.ReadLine();

        Classroom classroom = school.FindClassByName(className);
        if (classroom != null) {
            Student newStudent = new Student() { Name = studentName };
            classroom.Subscribe(newStudent);
            Console.WriteLine("Student added successfully.");
        } else {
            Console.WriteLine("Class not found.");
        }
    }

    static void CreateAssignmentForClass(School school) {
        Console.WriteLine("Who is creating this assignment?");
        school.ListTeachers();

        string teacherName = Console.ReadLine();
        Teacher selectedTeacher = school.FindTeacherByName(teacherName); 

        selectedTeacher.CreateAssignment();
    }
}
