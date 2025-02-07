using System.Reflection;

Type type = typeof(SampleClass);

//Kiểm tra thông tin kiểu
Console.WriteLine("Tên lớp: " + type.Name);
Console.WriteLine("Namespace: " + type.Namespace);

Console.WriteLine("Các thuộc tính:");
foreach (PropertyInfo prop in type.GetProperties())
{
    Console.WriteLine($"- {prop.Name} ({prop.PropertyType.Name})");
}
Console.WriteLine("Các phương thức:");
foreach (MethodInfo method in type.GetMethods())
{
    Console.WriteLine($"- {method.Name}");
}

//Tạo đối tượng và gọi phương thức tại runtime
var instance = Activator.CreateInstance(type);
PropertyInfo nameProperty = type.GetProperty("Name");
nameProperty?.SetValue(instance, "Reflection Example");
Console.WriteLine("Name: " + nameProperty?.GetValue(instance));

// Gọi phương thức "Display"
MethodInfo displayMethod = type.GetMethod("Display");
displayMethod?.Invoke(instance, null);

//Thay đổi trường hoặc thuộc tính không công khai (private)

// Lấy thông tin field private
FieldInfo privateField = type.GetField("_secret", BindingFlags.NonPublic | BindingFlags.Instance);
// Thay đổi giá trị field private
privateField?.SetValue(instance, "Updated Secret Value");

// Gọi phương thức để kiểm tra
MethodInfo revealMethod = type.GetMethod("RevealSecret");
revealMethod?.Invoke(instance, null);



class SampleClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Display() => Console.WriteLine("Display method called.");

    private string _secret = "Original Secret Value";
    public void RevealSecret() => Console.WriteLine($"Secret: {_secret}");

}
