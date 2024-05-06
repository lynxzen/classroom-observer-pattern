using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        School school = new School();
        Teacher teacher = new Teacher() { Name = "Josh" };
        school.AddTeacher(teacher);

        Classroom mathClass = new Classroom() { ClassroomName = "Algebra 101" };
        Classroom scienceClass = new Classroom() { ClassroomName = "Biology 201" };

        teacher.AddClass(mathClass);
        teacher.AddClass(scienceClass);

        // Optionally add some students and assignments to see detailed output
        Student student1 = new Student() { Name = "John Doe" };
        Student student2 = new Student() { Name = "Jane Smith" };
        mathClass.Subscribe(student1);
        scienceClass.Subscribe(student2);

        Assignment assignment1 = new Assignment("Homework", "Math Homework 1", "Solve equations", "Answers");
        Assignment assignment2 = new Assignment("Lab", "Biology Lab 1", "Dissect a frog", "Diagram");
        mathClass.AddAssignment(assignment1);
        scienceClass.AddAssignment(assignment2);

        teacher.ListClasses(); // Display the list of classes
        school.ListClasses();
    }
}
