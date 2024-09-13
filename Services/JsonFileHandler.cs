using Newtonsoft.Json;
using W4_assignment_template.Interfaces;
using W4_assignment_template.Models;

namespace W4_assignment_template.Services;

public class JsonFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath)
    {
        // JSON reading logic

        string json = File.ReadAllText(filePath);
        List<Character> c = JsonConvert.DeserializeObject<List<Character>>(json);
        return c;

    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        // JSON writing logic

        string json = JsonConvert.SerializeObject(characters);
        using (StreamWriter writer = new StreamWriter(filePath, false)) 
        {
            writer.Write(json); 
        }
    }
}