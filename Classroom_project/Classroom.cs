public class Classroom : IObservable<Assignment> {
    private string classroomName;
    public string ClassroomName {
        get { return classroomName; }
        set { classroomName = value; }
    }

    private List<Assignment> assignments = new List<Assignment>();
    public List<Assignment> Assignments {
        get { return assignments; }
    }

    private List<Student> students = new List<Student>();
    public List<Student> Students {
        get { return students; }
    }

    private List<IObserver<Assignment>> studentsObservers = new List<IObserver<Assignment>>();
    public List<IObserver<Assignment>> StudentsObservers {
        get { return studentsObservers; }
    }

    // When an assignment is created, tell all the students
    public void AddAssignment(Assignment assignment) {
        assignments.Add(assignment);
        foreach (var student in studentsObservers) {
            student.OnNext(assignment);
        }
    }

    public void ListStudents() {
        Console.WriteLine($"Students in the {ClassroomName} class:");
        for (int i = 0; i < Students.Count; i++) {
            Console.WriteLine($"{i+1}. {Students[i].Name}");
        }
    }

    // Subscribe student to the class and tell them about all the stuff they gotta do :(
    public IDisposable Subscribe(IObserver<Assignment> student) {
        if (!studentsObservers.Contains(student)) {
            studentsObservers.Add(student);
            foreach (Assignment assignment in assignments) {
                student.OnNext(assignment);
            }
        }
        return new Unsubscriber(studentsObservers, student);
    } 

    private class Unsubscriber : IDisposable {
        private List<IObserver<Assignment>> _observers;
        private IObserver<Assignment> _observer;

        public Unsubscriber(List<IObserver<Assignment>> observers, IObserver<Assignment> observer) {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose() {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}

