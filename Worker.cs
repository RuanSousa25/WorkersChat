using WorkerTest.Services.WordsService;

namespace WorkerTest;

public class Worker(ILogger<Worker> logger, IWordsService wordsService) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly IWordsService _wordsService = wordsService;


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            var words = await _wordsService.GetWordsAsync();

            foreach (var word in words)
            {
                Console.WriteLine($"Palavra: {word.Word}");
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
