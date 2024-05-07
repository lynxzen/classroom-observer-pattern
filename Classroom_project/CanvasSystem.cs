class CanvasSystem : ITextInterface {
    private List<School> schools = new List<School>();
    public List<School> Schools {
        get { return schools; }
    }

    public void CreateSchool() {
        Console.WriteLine("Enter the school name:");
        string schoolName = Console.ReadLine();
        School newSchool = new School() { Name = schoolName };
        schools.Add(newSchool);

    }

    public void ListSchools() {
        foreach (School school in schools) {
            Console.WriteLine(school.Name);
        }
    }

    public void SelectSchool() {
        ListSchools();
        Console.WriteLine("Enter the school name:");
        string schoolName = Console.ReadLine();
        School newSchool = FindSchoolByName(schoolName); 
    }

    public void TextInterface() {
        bool keepRunning = true;
        while (keepRunning) {
            Console.Clear(); // Clears the console for a cleaner interface
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine("|           Canvas System Menu      |");
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine("| 1. Create a School                |");
            Console.WriteLine("| 2. List Schools                   |");
            Console.WriteLine("| 3. Select School                  |");
            Console.WriteLine("| 4. Exit                           |");
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine("Select an option by entering a number:");

            string option = Console.ReadLine();

            switch (option) {
                case "1":
                    CreateSchool();
                    break;
                case "2":
                    ListSchools();
                    break;
                case "3":
                    SelectSchool();
                    break;
                case "4":
                    Console.WriteLine("Exiting menu.");
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            if (keepRunning) {
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }

    public School FindSchoolByName(string schoolName) {
        return schools.FirstOrDefault(c => c.Name.Equals(schoolName, StringComparison.OrdinalIgnoreCase));
    }

}
