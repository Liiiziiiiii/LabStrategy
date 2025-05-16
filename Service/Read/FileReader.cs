namespace StrategyLab.Service.Read
{
    public class FileReader
    {
        public IEnumerable<string> ReadLines(string filePath)
        {
            return File.ReadLines(filePath);
        }
    }

}
