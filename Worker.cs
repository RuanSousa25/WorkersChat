using WorkerTest.Services.ChatService;
using WorkerTest.Services.WordsService;
using WorkerTest.Services.WorkerEntityService;

namespace WorkerTest;

public class Worker(ILogger<Worker> logger, IChatService chatService, IWorkerEntityService workerEntityService) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly IChatService _chatService = chatService;
    private readonly IWorkerEntityService _workerEntityService = workerEntityService;


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        }
        while (!stoppingToken.IsCancellationRequested)
        {
            var worker = await _workerEntityService.CreateNewWorkerAsync();
            var message = await _chatService.GenerateMessageAsync();
            worker.MessageId = message.Id;
            worker.DeathDate = DateTime.UtcNow.ToLocalTime();
            await _workerEntityService.UpdateWorkerAsync(worker);
            Console.WriteLine($"Worker {worker.Id} (nascido em {worker.BornDate}) diz '{message.Message}' ás {DateTime.UtcNow.ToLocalTime()}");
            

            await Task.Delay(1000, stoppingToken);
        }
    }
}
