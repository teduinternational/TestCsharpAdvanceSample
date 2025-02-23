using System;
using System.Threading;
class BankAccount
{
    private int balance = 1000; // Số dư ban đầu
    private object lockObject = new object();
    public void Withdraw(int amount)
    {
        lock (lockObject) // Đảm bảo chỉ một luồng có thể thực hiện giao dịch tại một thời điểm
        {
            if (balance >= amount)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} đang rút {amount}...");
                Thread.Sleep(100); // Giả lập độ trễ xử lý
                balance -= amount;
                Console.WriteLine($"{Thread.CurrentThread.Name} đã rút thành công! Số dư còn lại: {balance}");
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} không thể rút {amount}. Số dư không đủ!");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();
        Thread t1 = new Thread(() => account.Withdraw(700)) { Name = "Luồng 1" };
        Thread t2 = new Thread(() => account.Withdraw(500)) { Name = "Luồng 2" };
        Thread t3 = new Thread(() => account.Withdraw(300)) { Name = "Luồng 3" };
        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();
        Console.WriteLine("Giao dịch hoàn tất.");
    }
}
