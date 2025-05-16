using StrategyLab.Service;
using StrategyLab.Service.Read;
using StrategyLab.Service.Write;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var downloader = new HttpReader();
        var url = "https://data.cityofnewyork.us/Health/New-York-City-Leading-Causes-of-Death/jb7j-dtam/about_data";
        var filePath = "data.txt";
        await downloader.DownloadToFileAsync(url, filePath);
        Console.WriteLine("✅ Дані успішно збережено у data.txt");

        var factory = new DataWriterFactory(config);
        var writer = factory.CreateWriter();

        var reader = new FileReader();
        var lines = reader.ReadLines("data.txt");

        var processor = new DataProcessor(writer);
        processor.ProcessData(lines);

        if (writer is KafkaWriter kafkaWriter)
        {
            kafkaWriter.Flush();
        }
    }
}
