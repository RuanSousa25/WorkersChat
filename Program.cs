using WorkerTest;
using WorkerTest.Factory;
using WorkerTest.Repositories.ChatRepository;
using WorkerTest.Services.ChatService;
using WorkerTest.Services.WordsService;

var builder = Host.CreateApplicationBuilder(args);
var connStr = builder.Configuration.GetConnectionString("PostgresqlConnection");
// DI
builder.Services.AddSingleton<IDbConnectionFactory>(new NpgsqlConnectionFactory(connStr!));
builder.Services.AddTransient<IChatRepository, ChatRepository>();
builder.Services.AddTransient<IWordsRepository, WordsRepository>();
builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddTransient<IWordsService, WordsService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
