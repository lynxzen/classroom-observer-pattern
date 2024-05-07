public class CanvasMenu : IMenu {
    private List<School> schools;
    public CanvasMenu(List<School> schools) {
        this.schools = schools;
    }

    public void DisplayMenu() {
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("|            Canvas Menu            |");
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("| 1. Manage Schools                 |");
        Console.WriteLine("| 2. Add School                     |");
        Console.WriteLine("| 3. Exit                           |");
        Console.WriteLine("+-----------------------------------+");
    }

    public IMenu HandleMenuInput(string option) {
        switch (option) {
            case "1":
                return SelectSchool();
            case "2":
                return CreateSchool();
            case "3":
                return null;
        }
        return this;
    }

    public void ListSchools() {
        for (int i = 0; i < schools.Count; i++) {
            Console.WriteLine($"{i + 1}. {schools[i].Name}");
        }
    }

    public IMenu SelectSchool() {
        if (schools.Count == 0) {
            Console.WriteLine("No schools available.");
            Utilities.PressToContinue();
            return this;
        }

        ListSchools();
        Console.WriteLine("Select a school by number:");
        //TODO rewrite this
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > schools.Count) {
            Console.WriteLine("Invalid selection. Please try again.");
            Utilities.PressToContinue();
            return this;
        }
        return new SchoolMenu(schools[index - 1]);
    }

    public IMenu CreateSchool() {
        Console.WriteLine("Enter the name of the school you wish to create:");
        string schoolName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(schoolName)) {
            Console.WriteLine("Invalid school name. Please try again.");
            return this;
        }

        School newSchool = new School() { Name = schoolName };
        schools.Add(newSchool);
        Console.WriteLine($"School '{schoolName}' added successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return this;
    }

    public School FindSchoolByName(string SchoolName) {
        return schools.FirstOrDefault(c => c.Name.Equals(SchoolName, StringComparison.OrdinalIgnoreCase));
    }

}


