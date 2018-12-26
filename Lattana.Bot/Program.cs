using System;

namespace Telegram.Bot.Examples.Echo
{
    public static class Program
    {
        private static void Main()
        {

            Models.Bot.LoadHook();

            Models.Bot.Istance.StartReceiving();

            Console.ReadLine();

            Models.Bot.Istance.StopReceiving();
        }
       
    }
}
