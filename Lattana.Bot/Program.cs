using System;
using Lattana.Bot.Manager;

namespace Lattana.Bot
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
