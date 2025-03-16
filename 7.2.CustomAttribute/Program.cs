using _7._2.CustomAttribute;

var type = typeof(ExampleClass);
var attributes = type.GetCustomAttributes(typeof(MyCustomAttribute), false);
foreach (var attribute in attributes)
{
    if (attribute is MyCustomAttribute myCustom)
    {
        Console.WriteLine(myCustom.Description);
    }
}

[MyCustom("This is a custom attribute example.")]
public class ExampleClass
{
   
    public string Name { get; set; }
    public int Age { get; set; }

    public void Display()
    {
        Console.WriteLine("Example method with custom attribute.");
    }
}
