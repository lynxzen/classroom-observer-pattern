class School : ISchoolAdmin {
    private List<Teacher> teachers = new List<Teacher>();
    public List<Teacher> Teachers {
        get { return teachers; }
    }

    public void AddTeacher(Teacher teacher) {
        teachers.Add(teacher);
    }

    public void ListClasses() {
        foreach (Teacher teacher in teachers) {
            Console.WriteLine("All classes in the school:");
            teacher.ListClasses();
        }
    }
}
