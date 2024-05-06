class School : ISchoolAdmin {
    private List<Teacher> teachers = new List<Teacher>();
    public List<Teacher> Teachers {
        get { return teachers; }
    }

    public void AddTeacher(Teacher teacher) {
        teachers.Add(teacher);
    }

    public void ListTeachers() {
        foreach (Teacher teacher in teachers) {
            Console.WriteLine("All teachers in the school:");
            Console.WriteLine(teacher.Name);
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
