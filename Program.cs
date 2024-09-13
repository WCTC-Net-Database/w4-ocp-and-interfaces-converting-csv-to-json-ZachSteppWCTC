using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;
using W4_assignment_template.Services;

namespace W4_assignment_template;

class Program
{
    static IFileHandler fileHandler;
    static List<Character> characters;

    static void Main()
    {
        string filePath = "Files/input.json"; // Default to CSV file
        fileHandler = new JsonFileHandler(); // Default to CSV handler
        characters = fileHandler.ReadCharacters(filePath);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllCharacters();
                    break;
                case "2":
                    AddCharacter();
                    break;
                case "3":
                    LevelUpCharacter();
                    break;
                case "4":
                    fileHandler.WriteCharacters(filePath, characters);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayAllCharacters()
    {
        foreach (var character in characters)
        {
            Console.WriteLine($"Name: {character.Name}, Class: {character.Class}, Level: {character.Level}, HP: {character.HP}, Equipment: {string.Join(", ", character.Equipment)}");
        }
    }

    static void AddCharacter()
    {
        // logic to add a new character
        characters.Add(Character.CreateCharacter());
    }

    static void LevelUpCharacter()
    {
        Console.Write("Enter the name of the character to level up: ");
        string nameToLevelUp = Console.ReadLine();

        var character = characters.Find(c => c.Name.Equals(nameToLevelUp, StringComparison.OrdinalIgnoreCase));
        if (character != null)
        {
            // logic to level up the character
            character.LevelUp();
        }
        else
        {
            Console.WriteLine("Character not found.");
        }
    }
}