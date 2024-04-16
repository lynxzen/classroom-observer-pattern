using System;
using System.Collections.Generic;

class Assignment {
    public string? ID { get; set; }
}

class Teacher {
    public string? Name { get; set; }
}

class Student {
    public string? Name { get; set; }
}

class Classroom : IObservable<Student> {
    private List<IObserver<Student>> students;
    private List<Assignment> assignments;

    public Classroom() {
        students = new List<IObserver<Student>>();
        assignments = new List<Assignment>();
    }

    public IDisposable Subscribe(IObserver<Student> student) {
        if (!students.Contains(student)) {
            students.Add(student);
        }
        return new Unsubscriber<Student>(students, student);
    }
}

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");

        Classroom classroom = new Classroom();
        Teacher teacher = new Teacher();
        teacher.Name = "Josh";
        Console.WriteLine(teacher.Name);
    }
}
