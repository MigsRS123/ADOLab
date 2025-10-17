
using System.Text;
using System.Threading;

public class FileLogger
{
    private readonly string _filePath;
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    public FileLogger(string filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public async Task LogAsync(string message) => await LogToFileAsync("INFO", message);
    public async Task LogWarningAsync(string message) => await LogToFileAsync("WARNING", message);
    public async Task LogErrorAsync(string message) => await LogToFileAsync("ERROR", message);

    private async Task LogToFileAsync(string logType, string message)
    {
        try
        {
            // Se existir um diretório (ex: "logs/app.log") cria, se for somente "log.txt" Path.GetDirectoryName retorna null/"" -> ignora
            var dir = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrWhiteSpace(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{logType}] {message}{Environment.NewLine}";

            await _semaphore.WaitAsync();
            try
            {
                await File.AppendAllTextAsync(_filePath, logMessage, Encoding.UTF8);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        catch (Exception ex)
        {
            // Falha no logger não deve derrubar a aplicação; exibimos no console
            Console.WriteLine($"[LOG ERROR] {ex.Message}");
        }
    }
}
