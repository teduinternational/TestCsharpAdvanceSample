//int[] numbers = { 1, 2, 3, 4, 5 };
//Parallel.For(0, numbers.Length, i =>
//{
//    int squared = numbers[i] * numbers[i];
//    Console.WriteLine($"Số {numbers[i]} có bình phương: {squared} - Thread: {Task.CurrentId}");
//});
//Console.WriteLine("Tất cả số đã được tính toán.");


List<string> urls = new List<string>
        {
            "https://example.com",
            "https://dotnet.microsoft.com",
            "https://learn.microsoft.com"
        };
HttpClient client = new HttpClient();
await Task.Run(() =>
{
    Parallel.ForEach(urls, async url =>
    {
        string content = await client.GetStringAsync(url);
        Console.WriteLine($"Tải xong: {url} - Kích thước: {content.Length}");
    });
});
Console.WriteLine("Tất cả trang web đã tải xong.");
