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

    public void AddTeacher(Teacher teacher) {
        teachers.Add(teacher);
    }

    public void CreateTeacher() {
        Console.WriteLine("Enter the teacher's name:");
        string name = Console.ReadLine();
        Teacher newTeacher = new Teacher() { Name = name };
        teachers.Add(newTeacher);
        Console.WriteLine("Teacher added successfully.");
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

    public void ListClasses() {
        foreach (Teacher teacher in teachers) {
            Console.WriteLine("All classes in the school:");
            teacher.ListClasses();
        }
    }

    public Teacher FindTeacherByName(string teacherName) {
        foreach (Teacher teacher in teachers) {
            if (teacher.Name == teacherName) {
                return teacher;
            }    
        }
        Console.WriteLine("Class not found");
        return null; // Return null if no class is found after checking all teachers
    }

    public Classroom FindClassByName(string className) {
        foreach (Teacher teacher in teachers) {
            Classroom classFound = teacher.FindClassByName(className);
            if (classFound != null) {
                Console.WriteLine("Class found in teacher: " + teacher.Name);
                return classFound; // Return the found class immediately
            }
        }
        Console.WriteLine("Class not found");
        return null; // Return null if no class is found after checking all teachers
    }
}
