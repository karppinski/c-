using System.Text.Json;
using System.Text.Json.Nodes;

namespace otherXMLnJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] data = File.ReadAllBytes("people.json");
            Utf8JsonReader reader = new Utf8JsonReader(data);

            while(reader.Read())
            {
                switch(reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        Console.WriteLine($"Start of object");
                        break;
                    case JsonTokenType.EndObject:
                        Console.WriteLine($"End of object");
                        break;
                    case JsonTokenType.StartArray:
                        Console.WriteLine();
                        Console.WriteLine($"Start of array");
                        break;
                    case JsonTokenType.EndArray:
                        Console.WriteLine($"End of array");
                        break;
                    case JsonTokenType.PropertyName:
                        Console.WriteLine($"Property: {reader.GetString()}");
                        break;
                    case JsonTokenType.String:
                        Console.WriteLine($" Value: {reader.GetString()}");
                        break;
                    case JsonTokenType.Number:
                        Console.WriteLine($" Value: {reader.GetInt32()}");
                        break;
                    default:
                        Console.WriteLine($"No support for {reader.TokenType}");
                        break;

                }

 
            }

            var node = JsonNode.Parse(@"{""Name"":""Alice"", ""Age"": 32}");
            string name = (string)node["Name"];
            int age = (int)node["Age"];

            Console.WriteLine(name + " " + age);

            var node1 = new JsonArray
            {
                new JsonObject
                {
                    ["Name"] = "Tracy",
                    ["Age"] = 30,
                    ["Friends"] = new JsonArray ("Lisa","Joe")
                },
                new JsonObject
                {
                    ["Name"] = "Jordyn",
                    ["Age"] = 25,
                    ["Friends"] = new JsonArray ("Tracy","Lee")
                }
            };

            Console.WriteLine(node1.Count);
        }
    }
}
