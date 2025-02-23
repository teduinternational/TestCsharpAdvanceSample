FileReader resource = null;
try
{
    resource = new FileReader("file.txt");
    resource.ReadFile();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
finally
{
    if (resource != null)
    {
        resource.Dispose();
    }
}
// Dispose sẽ được gọi tự động ở đây, kể cả khi xảy ra lỗi

public class FileReader : IDisposable
{
    private FileStream _fileStream;

    public FileReader(string filePath)
    {
        _fileStream = new FileStream(filePath, FileMode.Open);
    }

    public void ReadFile()
    {
        // Logic đọc tệp
    }

    public void Dispose()
    {
        // Giải phóng tài nguyên khi không còn sử dụng
        _fileStream?.Dispose();
    }
}