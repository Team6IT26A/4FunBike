namespace _4FunBike;

using System;
using System.IO;
using System.Text.Json;

public class TestClass
{
    public static void Test()
    {
        string filePath = "C:\\Users\\mail\\OneDrive\\Dokumente\\GitHub\\4FunBike\\data\\data.json";
        string jsonContent = File.ReadAllText(filePath);

        using (JsonDocument doc = JsonDocument.Parse(jsonContent))
        {
            PrintElement(doc.RootElement);
        }
    }

    static void PrintElement(JsonElement element, string indent = "")
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (JsonProperty property in element.EnumerateObject())
                {
                    Console.WriteLine($"{indent}{property.Name}:");
                    PrintElement(property.Value, indent + "  ");
                }
                break;

            case JsonValueKind.Array:
                foreach (JsonElement arrayElement in element.EnumerateArray())
                {
                    PrintElement(arrayElement, indent + "  ");
                }
                break;

            default:
                Console.WriteLine($"{indent}{element}");
                break;
        }
    }
}