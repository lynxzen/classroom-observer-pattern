public class School : ISchoolAdmin {
    private string name;
    public string Name {
        get { return name; }
        set { name = value; }
    }

    private List<Teacher> teachers = new List<Teacher>();
    public List<Teacher> Teachers {
        get { return teachers; }
    }

    private List<Student> students = new List<Student>();
    public List<Student> Students {
        get { return students; }
    }

    public void AddTeacher(Teacher teacher) {
        teachers.Add(teacher);
    }

    public void CreateTeacher() {
        Console.WriteLine("\nEnter the teacher's name:");
        string name = Console.ReadLine();
        Teacher newTeacher = new Teacher() { Name = name };
        teachers.Add(newTeacher);
        Console.WriteLine($"\nTeacher {name} added successfully!");
    }

    public void CreateStudent(School school) {
        Console.WriteLine("\nEnter the student's name:");
        string name = Console.ReadLine();
        Student newStudent = new Student(school) { Name = name };
        students.Add(newStudent);
        Console.WriteLine($"\nStudent {name} added successfully!");
    }

    public void ListTeachers() {
        if (teachers.Count == 0) {
            Console.WriteLine("No teachers in school.");
        }
        else {
            Console.WriteLine("\nAll teachers in the school:");
            for (int i = 0; i < teachers.Count; i++) {
                Console.WriteLine($"{i + 1}. {teachers[i].Name}");
            }
        }
    }

    public void ListStudents() {
        if (students.Count == 0) {
            Console.WriteLine("No students in school!");
        }
        else {
            Console.WriteLine("\nAll students in the school:");
            for (int i = 0; i < students.Count; i++) {
                Console.WriteLine($"{i + 1}. {students[i].Name}");
            }
        }
    }

    public void ListClasses() {
        //TODO error check
        Console.WriteLine("\nAll classes in the school:");
        for (int i = 0; i < teachers.Count; i++) {
            if (teachers[i].Classes.Count == 0) continue;  

            for (int j = 0; j < teachers[i].Classes.Count; j++) {
                Console.WriteLine($"{i+1}-{j+1}. Class Title: {teachers[i].Classes[j].ClassroomName}\tTaught by: {teachers[i].Name}");
            }
        }
    }

    public Teacher FindTeacherByName(string teacherName) {
        foreach (Teacher teacher in teachers) {
            if (teacher.Name == teacherName) {
                return teacher;
            }    
        }
        Console.WriteLine("Class not found");
        return null; 
    }

    public Student FindStudentByName(string studentName) {
        foreach (Student student in students ) {
            if (student.Name == studentName) {
                return student;
            }    
        }
        Console.WriteLine("Student not found");
        return null; 
    }

    public Classroom FindClassByName(string className) {
        foreach (Teacher teacher in teachers) {
            Classroom classFound = teacher.FindClassByName(className);
            if (classFound != null) {
                Console.WriteLine("Class found in teacher: " + teacher.Name);
                return classFound; 
            }
        }
        Console.WriteLine("Class not found");
        return null; 
    }
}
