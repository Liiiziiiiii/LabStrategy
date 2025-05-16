namespace StrategyLab.Service
{
    public class DataProcessor
    {
        private readonly IDataWriter _dataWriter;

        public DataProcessor(IDataWriter dataWriter)
        {
            _dataWriter = dataWriter;
        }

        public void ProcessData(IEnumerable<string> data)
        {
            foreach (var line in data)
            {
                _dataWriter.Write(line);
            }
        }
    }

}
