using System;
using Telegram.Bot.Examples.Echo.Manager;

namespace Telegram.Bot.Examples.Echo
{
    public static class Program
    {
        private static void Main()
        {

            Istance.Bot.LoadHook();

            ModulesManager.LoadModules();

            Istance.Bot.Istance.StartReceiving();

            Console.ReadLine();

            Istance.Bot.Istance.StopReceiving();
        }
       
    }
}
