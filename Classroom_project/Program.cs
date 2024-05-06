using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        School school = new School();
        bool continueRunning = true;

        while (continueRunning) {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add a Teacher");
            Console.WriteLine("2. Add a Class");
            Console.WriteLine("3. Add a Student to a Class");
            Console.WriteLine("4. Create an Assignment");
            Console.WriteLine("5. List All Classes");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    AddTeacher(school);
                    break;
                case "2":
                    AddClass(school);
                    break;
                case "3":
                    AddStudent(school);
                    break;
                case "4":
                    CreateAssignmentForClass(school);
                    break;
                case "5":
                    school.ListClasses();
                    break;
                case "6":
                    continueRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
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
