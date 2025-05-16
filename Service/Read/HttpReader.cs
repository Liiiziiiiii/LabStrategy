namespace StrategyLab.Service.Read
{
    public class HttpReader
    {
        private readonly HttpClient _client;

        public HttpReader()
        {
            _client = new HttpClient();
        }

        public async Task DownloadToFileAsync(string url, string filePath)
        {
            var content = await _client.GetStringAsync(url);
            await File.WriteAllTextAsync(filePath, content);
        }
    }
}
