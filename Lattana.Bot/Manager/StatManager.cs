using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telegram.Bot.Examples.Echo.Models;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace Telegram.Bot.Examples.Echo.Manager
{
    public static class StatManager
    {
        private static readonly string CurrentDirectory = Directory.GetCurrentDirectory();

        private static readonly string FolderPath = Path.Combine(CurrentDirectory, "Data");

        private static readonly string JsonPath = Path.Combine(FolderPath, "statInfo.json");

        public static List<UserStat> Items = CaricaStistiche();
        
        public static bool CheckUpdate(Message message)
        {
            if (message.From.Username == "Lattana")
                return true;

            SalvaStatistiche();

            if (message.Audio != null || message.Voice != null)
            {
                IncrementaAudio(message);
                return true;
            }

            if (message.Text != null)
            {
                IncrementaTesto(message);
                return true;
            }

            if (message.Photo != null)
            {
                IncrementaImmagini(message);
                return true;
            }

            if (message.Sticker != null)
            {
                IncrementaSticker(message);
                return true;

            }

            return false;
        }

        private static void IncrementaSticker(Message message)
        {
            ControllaUser(message);
            Items.Single(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals(message.From.LastName.ToLower())).ContSticker++;
        }

    
        private static void IncrementaTesto(Message message)
        {
            ControllaUser(message);
            try
            {
                Items.Single(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals((message.From.LastName ?? "").ToLower())).ContText += 1;
            }
            catch (Exception)
            {

                IftttManager.SendException($"L'utente {message.From.FirstName} ha la mamma molto maiala, non ha il cognome");
            }
        }

        private static void IncrementaImmagini(Message message)
        {
            ControllaUser(message);
            Items.Single(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals((message.From.LastName ?? "").ToLower())).ContImg += 1;

        }

        private static void IncrementaAudio(Message message)
        {
            ControllaUser(message);
            Items.Single(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals((message.From.LastName ?? "").ToLower())).ContAudio += 1;

        }

        private static void ControllaUser(Message message)
        {
            if (!Items.Any(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals((message.From.LastName ?? "").ToLower())))
            {
                Items.Add(new UserStat
                {
                    Nome = message.From.FirstName?.ToLower() ?? "",
                    Cognome = message.From.LastName?.ToLower() ?? "",
                    Id = message.From.Id,
                    Username = message.From.Username?.ToLower() ?? ""
                });

            }

        }

        public static int GetUserIdByName(string name)
        {
            try
            {
                var user = Items.Single(x => x.Nome.Equals(name));
                return Convert.ToInt32(user.Id);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int GetUserIdBySurname(string surname)
        {
            try
            {
                var user = Items.Single(x => x.Cognome.Equals(surname));
                return Convert.ToInt32(user.Id);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int GetUserIdByNameSurname(string name, string surname)
        {
            try
            {

                var user = Items.Single(x => x.Nome.Equals(name) && x.Cognome.Equals(surname));
                return Convert.ToInt32(user.Id);

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int GetUserIdByUsername(string username)
        {
            try
            {
                var user = Items.Single(x => x.Username.Equals(username));
                return Convert.ToInt32(user.Id);

            }
            catch (Exception)
            {

                return -1;
            }

        }

        public static bool SalvaStatistiche()
        {
            Directory.CreateDirectory(FolderPath);
            if (!File.Exists(JsonPath)) File.Create(JsonPath).Dispose();

            JsonManager.WriteToJsonFile(JsonPath, Items);
            return true;
        }

        public static List<UserStat> CaricaStistiche()
        {

            Directory.CreateDirectory(FolderPath);
            if (!File.Exists(JsonPath)) File.Create(JsonPath).Dispose();

            var userList = JsonManager.ReadFromJsonFile(JsonPath);
            return userList ?? new List<UserStat>();
        }

    }
}


