internal class Program
{
    static int counter = 0;
    static object lockObject = new object();
    private static async Task Main(string[] args)
    {
        Thread thread = new Thread(DoWork);
        thread.Start();

        Console.WriteLine("Main thread is running...");

        thread.Join();

        Console.WriteLine("Main thread is done.");

        // Tạo và chạy một task đồng thời
        Task task = Task.Run(() => DoWork());

        // Công việc trong luồng chính
        Console.WriteLine("Main task is running...");

        // Chờ task hoàn thành
        await task;

        Console.WriteLine("Main task finished.");


        Task task1 = Task.Run(() => DoWorkWithId(1));
        Task task2 = Task.Run(() => DoWorkWithId(2));

        await Task.WhenAll(task1, task2);

        Console.WriteLine("Both tasks completed.");

        Thread t1 = new Thread(IncrementCounter);
        Thread t2 = new Thread(IncrementCounter);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine($"Final counter value: {counter}");


        static void DoWork()
        {
            Console.WriteLine("Worker thread is running...");
            Thread.Sleep(2000);
            Console.WriteLine("Worker thread is done.");
        }

        static void DoWorkWithId(int id)
        {
            Console.WriteLine($"Worker thread {id} is running...");
            Thread.Sleep(2000);
            Console.WriteLine($"Worker thread {id} is done.");
        }

        static void IncrementCounter()
        {
            for (int i = 0; i < 10000; i++)
            {
                lock (lockObject)
                {
                    counter++;
                }
            }
        }
    }
}