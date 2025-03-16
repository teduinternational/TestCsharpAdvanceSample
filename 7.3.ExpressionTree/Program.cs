using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {
        // Danh sách người dùng
        var users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Age = 25 },
            new User { Id = 2, Name = "Bob", Age = 30 },
            new User { Id = 3, Name = "Charlie", Age = 35 },
            new User { Id = 4, Name = "Andrew", Age = 40 }
        };
        //var userGreaterThan28Age = users.AsQueryable().Where(u => u.Age > 28).ToList();
        var filter = FilterAgeThan28();
        var filteredUsers = users.AsQueryable().Where(filter).ToList();
        foreach(var user in filteredUsers)
        {
            Console.WriteLine($"Id: {user.Id} - Name: {user.Name} - Age: {user.Age}");
        }
    }
    public static Expression<Func<User, bool>> FilterAgeThan28()
    {
        ParameterExpression pe = Expression.Parameter(typeof(User), "user");
        MemberExpression me = Expression.Property(pe, "Age");
        ConstantExpression ce = Expression.Constant(28, typeof(int));
        BinaryExpression be = Expression.GreaterThan(me, ce);
        return Expression.Lambda<Func<User, bool>>(be, pe);
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
//// Tạo parameter x và y
//using System.Linq.Expressions;

//ParameterExpression x = Expression.Parameter(typeof(int), "x");
//ParameterExpression y = Expression.Parameter(typeof(int), "y");

//BinaryExpression body = Expression.Add(x, y);

//// Tạo lambda expression
//Expression<Func<int, int, int>> add = Expression.Lambda<Func<int, int, int>>(body, x, y);

//Console.WriteLine(add);

//// Compile lambda expression
//Func<int, int, int> addFunc = add.Compile();

//Console.WriteLine("Result: " + addFunc(1, 2));
//var visitor = new CustomVisitor();

//visitor.Visit(add);

//class CustomVisitor : ExpressionVisitor
//{
//    protected override Expression VisitBinary(BinaryExpression node)
//    {
//        Console.WriteLine($"Visit operatior: {node.NodeType}");
//        return base.VisitBinary(node);
//    }
//}

