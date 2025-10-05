using WorkerTest.Services.ChatService;
using WorkerTest.Services.WordsService;

namespace WorkerTest;

public class Worker(ILogger<Worker> logger, IChatService chatService) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly IChatService _chatService = chatService;


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        }
        while (!stoppingToken.IsCancellationRequested)
        {


            Console.WriteLine(await _chatService.GenerateMessageAsync());

            await Task.Delay(1000, stoppingToken);
        }
    }
}
