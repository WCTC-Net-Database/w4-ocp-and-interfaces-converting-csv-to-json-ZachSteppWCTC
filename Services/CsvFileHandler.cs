using System.Text;
using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;

namespace W4_assignment_template.Services;

public class CsvFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath)
    {
        // CSV reading logic

        string[] lines = File.ReadAllLines(filePath);
        Character[] result = new Character[lines.Length - 1];
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string name;
            string fields;

            if (line.StartsWith('"'))
            {

                var firstQuotePos = lines[i].IndexOf('"');
                name = lines[i].Substring(firstQuotePos + 1);
                var lastQuotePos = name.IndexOf('"');

                name = name.Substring(firstQuotePos, lastQuotePos - firstQuotePos);
                fields = line.Substring(lastQuotePos + 1);
            }
            else
            {
                name = lines[i].Split(",")[0];
                int firstComma = line.IndexOf(",");
                fields = line.Substring(firstComma);
            }
            string Class = fields.Split(",")[1];
            int level = Int32.Parse(fields.Split(",")[2]);
            int hp = Int32.Parse(fields.Split(",")[3]);
            string equipmentLine = fields.Split(",")[4];
            string[] equipment = equipmentLine.Split('|');

            result[i - 1] = new Character { Name = name, Class = Class, Level = level, HP = hp, Equipment = equipment.ToList() };
        }
        return result.ToList();
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        // CSV writing logic

        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            writer.WriteLine("Name, Class, Level, HP, Equipment");
            for (int i = 0; i < characters.Count; i++)
            {
                Character character = characters[i];
                StringBuilder sb = new StringBuilder();
                if (character.Name.Contains(','))
                {
                    sb.Append('"' + character.Name + '"');
                }
                else
                {
                    sb.Append(character.Name);
                }
                sb.Append($",{character.Class},{character.Level.ToString()},{character.HP.ToString()},{String.Join("|", character.Equipment)}");
                writer.WriteLine(sb.ToString());

            }
            writer.Close();
        }
    }
}