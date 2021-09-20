using System;
using System.Threading;

namespace Avito.Client
{
    class Program
    {
        static void Main()
        {
            using Client client = new();
            Thread.Sleep(1000);
            Console.WriteLine(client.SendMessage("test"));
            Thread.Sleep(1000);
        }
    }
}
