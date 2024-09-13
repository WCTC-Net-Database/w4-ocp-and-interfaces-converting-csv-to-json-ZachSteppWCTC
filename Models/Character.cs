namespace W4_assignment_template.Models;

public class Character
{
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public List<string> Equipment { get; set; }

    public void LevelUp()
    {
        Level++;
        Console.WriteLine($"Character {Name} leveled up to level {Level}!");
    }

    public static Character CreateCharacter( )
    {
        Console.Write("\nEnter your character's name: ");
        string name = Console.ReadLine();

        Console.Write("\nEnter your character's class: ");
        string characterClass = Console.ReadLine();

        int level;
        while (true)
        {
            try
            {
                Console.Write("\nEnter your character's level: ");
                level = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter an integer.");
            }
        }

        int health;
        while (true)
        {
            try
            {
                Console.Write("\nEnter your character's HP: ");
                health = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter an integer.");
            }
        }

        var equipment = new List<String>();
        while (true)
        {
            Console.WriteLine("Enter new equipment name. Type 0 to end: ");
            Console.Write("> ");
            string equipmentText = Console.ReadLine();
            if (equipmentText == "0")
            {
                break;
            }
            else
            {
                equipment.Add(equipmentText);
            }
        }

        Console.WriteLine($"\nWelcome, {name} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", equipment)}.");

        Character character = new Character { Name = name, Class = characterClass, Level = level, HP = health, Equipment = equipment };
        return character;
    }
}