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

class Assignment {
    public string? ID { get; set; }
}

class Teacher {
    public string? Name { get; set; }
}

class Student {
    public string? Name { get; set; }
}

public class Unsubscriber<Student> : IDisposable {
    private List<IObserver<Student>> _observers;
    private IObserver<Student> _observer;

    public Unsubscriber(List<IObserver<Student>> observers, IObserver<Student> observer) {
        _observers = observers;
        _observer = observer;
    }

    public void Dispose() {
        if (_observers.Contains(_observer)) {
            _observers.Remove(_observer);
        }
    }
}

class Classroom : IObservable<> {

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
