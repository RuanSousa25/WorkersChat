using WorkerTest;
using WorkerTest.Factory;
using WorkerTest.Models;
using WorkerTest.Repositories.ChatRepository;
using WorkerTest.Repositories.WordsRepository;
using WorkerTest.Repositories.WorkerEntityRepository;
using WorkerTest.Services.ChatService;
using WorkerTest.Services.WordsService;
using WorkerTest.Services.WorkerEntityService;

var builder = Host.CreateApplicationBuilder(args);
var connStr = builder.Configuration.GetConnectionString("PostgresqlConnection");
// DI
builder.Services.AddSingleton<IDbConnectionFactory>(new NpgsqlConnectionFactory(connStr!));
builder.Services.AddTransient<IChatRepository, ChatRepository>();
builder.Services.AddTransient<IWordsRepository, WordsRepository>();
builder.Services.AddTransient<IWorkerEntityRepository, WorkerEntityRepository>();

builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddTransient<IWordsService, WordsService>();
builder.Services.AddTransient<IWorkerEntityService, WorkerEntityService>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
