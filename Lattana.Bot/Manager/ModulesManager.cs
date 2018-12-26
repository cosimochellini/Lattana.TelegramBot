using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot.Examples.Echo.Models;

namespace Telegram.Bot.Examples.Echo.Manager
{
    public static class ModulesManager
    {
        public static List<Module> Modules = new List<Module>();

        private static readonly string CurrentDirectory = Directory.GetCurrentDirectory();

        private static readonly string FolderPath = Path.Combine(CurrentDirectory, "Modules");

        public static void LoadModules()
        {
            Directory.CreateDirectory(FolderPath);

            var modules = JsonManager.GetAllJson(FolderPath);

            foreach (var path in modules)
            {
                try
                {
                    Modules.AddRange(JsonManager.ReadFromJsonFile<List<Module>>(path) ?? new List<Module>());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"File {path} non formattato correttamente, provvedere a fixxxxarlo , ${ex}");
                }
            }
        }

        public static bool CheckModules(string[] comando)
        {
            foreach (var module in Modules)
            {
                if (!module.Check(comando)) continue;

                module.Execute();
                return true;
            }

            return false;
        }
    }
}