namespace StrategyLab.Service.Write
{
    public class ConsoleWriter : IDataWriter
    {
        public void Write(string data)
        {
            Console.WriteLine(data);
        }
    }

}
