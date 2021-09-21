namespace Avito.Client
{
    class Program
    {
        public static void Main()
        {
            using Game game = new();
            game.Start();
            //using Client client = new();
            //Thread.Sleep(1000);
            //Console.WriteLine(client.SendMessage("test"));
            //Thread.Sleep(1000);
        }
    }
}
