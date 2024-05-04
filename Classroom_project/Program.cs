using System;
using System.Collections.Generic;

public interface IObservable<T> {
    IDisposable Subscribe(IObserver<T> observer);
}

public interface IObserver<T> {
    void OnNext(T value);
    void onError(Exception error);
    void onComplete();
}

class Teacher {
    public string name;
    public List<Classroom> classrooms = new List<Classroom>();
}

class Classroom {
    public string classroomName;
    public List<Assignment> assignments = new List<Assignment>();
    public List<Student> students = new List<Student>();
}

class Student {
    public string name;
}

class Assignment {
    public string assignmentOrigin;
    public string name;
}

class Program {
    static void Main(string[] args) {

    }
}
