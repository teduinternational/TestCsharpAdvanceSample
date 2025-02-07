using System.Dynamic;
using System.Text.Json;

dynamic variable = "Hello, world!";
Console.WriteLine(variable); // In ra: Hello, world!

variable = 42;
Console.WriteLine(variable); // In ra: 42

variable = true;
Console.WriteLine(variable); // In ra: True

dynamic obj = new ExpandoObject();
obj.Name = "John Doe"; // Gán động một thuộc tính
//obj.SayHello = new Action(() => Console.WriteLine("Hello!")); // Gán động một phương thức

Console.WriteLine(obj.Name); // In ra: John Doe
//obj.SayHello(); // In ra: Hello!

string json = JsonSerializer.Serialize(obj);
Console.WriteLine(json); // In ra: {"Name":"John Doe"}

string json2 = @"{
            ""Name"": ""Alice"",
            ""Age"": 25,
            ""Email"": ""alice@example.com"",
            ""Address"": {
                ""City"": ""Los Angeles"",
                ""ZipCode"": ""90001""
            }
        }";
// Chuyển JSON thành ExpandoObject
var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

dynamic person = JsonSerializer.Deserialize<ExpandoObject>(json2, options);

var address = JsonSerializer.Deserialize<ExpandoObject>(person.Address, options);

Console.WriteLine($"Name: {person.Name}");
Console.WriteLine($"Age: {person.Age}");
Console.WriteLine($"Email: {person.Email}");
Console.WriteLine($"City: {address.City}");
Console.WriteLine($"ZipCode: {address.ZipCode}");