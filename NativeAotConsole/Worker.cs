using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace NativeAotConsole
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                StringBuilder sb = new();
                _ = sb.Append("Worker running at: ").Append(DateTimeOffset.Now).AppendLine()
                    .Append("Environment.CommandLine: ").AppendLine(Environment.CommandLine)
                    .Append("Environment.CurrentDirectory: ").AppendLine(Environment.CurrentDirectory)
                    .Append("Environment.CurrentManagedThreadId: ").AppendLine(Environment.CurrentManagedThreadId.ToString())
                    .Append("Environment.MachineName: ").AppendLine(Environment.MachineName)
                    .Append("Environment.OSVersion: ").AppendLine(Environment.OSVersion.ToString())
                    .Append("Environment.ProcessId: ").AppendLine(Environment.ProcessId.ToString())
                    .Append("Environment.UserName: ").AppendLine(Environment.UserName)
                    .Append("Environment.Version: ").AppendLine(Environment.Version.ToString())
                    .Append("IsDynamicCodeCompiled: ").Append(RuntimeFeature.IsDynamicCodeCompiled).AppendLine()
                    .Append("IsDynamicCodeSupported: ").Append(RuntimeFeature.IsDynamicCodeSupported).AppendLine();

                _logger.LogInformation(sb.ToString());

                Type type = Type.GetType("NativeAotConsole.Dummy");
                object instance = Activator.CreateInstance(type);
                string json = JsonSerializer.Serialize(instance, type, new JsonSerializerOptions() { });
                Console.WriteLine(json);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }

    public class Dummy
    {
        public string Value { get; set; }
    }
}