internal class Program
{
    private static void Main(string[] args)
    {
        //Singleton Pattern
        var config = ConfigManager.Instance;
        Console.WriteLine(config.DatabaseConnectionString);

        //Factory Method Pattern

        User admin = UserFactory.CreateUser("Admin");
        admin.GetRole(); // Output: Admin User - Full Access

        User guest = UserFactory.CreateUser("Guest");
        guest.GetRole(); // Output: Guest User - Limited Access

        //Observer Pattern

        ProductCategory electronics = new ProductCategory();

        Customer customer1 = new Customer("Alice");
        Customer customer2 = new Customer("Bob");

        electronics.AddObserver(customer1);
        electronics.AddObserver(customer2);

        electronics.AddNewProduct("iPhone 15 Pro");
        // Output:
        // Sản phẩm mới: iPhone 15 Pro vừa được thêm!
        // Alice nhận được thông báo: Sản phẩm mới - iPhone 15 Pro
        // Bob nhận được thông báo: Sản phẩm mới - iPhone 15 Pro
    }
}
//Singleton Pattern

public class ConfigManager
{
    private static ConfigManager? _instance;
    private static readonly object _lock = new object();

    public string DatabaseConnectionString { get; private set; }

    private ConfigManager()
    {
        // Giả sử đây là nơi tải cấu hình từ file hoặc biến môi trường
        DatabaseConnectionString = "Server=myServer;Database=myDB;User=myUser;Password=myPassword;";
    }

    public static ConfigManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ConfigManager();
                }
                return _instance;
            }
        }
    }
}

//Factory Method Pattern
public abstract class User
{
    public abstract void GetRole();
}

public class AdminUser : User
{
    public override void GetRole() => Console.WriteLine("Admin User - Full Access");
}

public class GuestUser : User
{
    public override void GetRole() => Console.WriteLine("Guest User - Limited Access");
}

public class CustomerUser : User
{
    public override void GetRole() => Console.WriteLine("Customer User - Standard Access");
}

public class UserFactory
{
    public static User CreateUser(string userType)
    {
        return userType switch
        {
            "Admin" => new AdminUser(),
            "Guest" => new GuestUser(),
            "Customer" => new CustomerUser(),
            _ => throw new ArgumentException("Invalid user type"),
        };
    }
}

//Oberver Pattern

public interface IObserver
{
    void Update(string productName);
}

public class Customer : IObserver
{
    public string Name { get; }

    public Customer(string name)
    {
        Name = name;
    }

    public void Update(string productName)
    {
        Console.WriteLine($"{Name} nhận được thông báo: Sản phẩm mới - {productName}");
    }
}

public class ProductCategory
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer) => observers.Add(observer);
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);

    public void NotifyObservers(string productName)
    {
        foreach (var observer in observers)
        {
            observer.Update(productName);
        }
    }

    public void AddNewProduct(string productName)
    {
        Console.WriteLine($"Sản phẩm mới: {productName} vừa được thêm!");
        NotifyObservers(productName);
    }
}