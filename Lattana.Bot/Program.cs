using System;
using Telegram.Bot.Examples.Echo.Manager;

namespace Telegram.Bot.Examples.Echo
{
    public static class Program
    {
        private static void Main()
        {

            Models.Bot.LoadHook();

            ModulesManager.LoadModules();

            Models.Bot.Istance.StartReceiving();

            Console.ReadLine();

            Models.Bot.Istance.StopReceiving();
        }
       
    }
}
