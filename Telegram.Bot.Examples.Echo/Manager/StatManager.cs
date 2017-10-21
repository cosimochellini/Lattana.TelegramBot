using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telegram.Bot.Examples.Echo.Models;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Manager
{
    public class StatManager
    {
        private List<UserStat> _listaUser = CaricaStistiche();

        public bool CheckUpdate(Message message)
        {
            if (message.From.Username == "Lattana")
                return true;

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

        private void IncrementaSticker(Message message)
        {
            ControllaUser(message);
            _listaUser.Single(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals(message.From.LastName.ToLower())).ContSticker++;
        }

        public IEnumerable<UserStat> GetListaUser()
        {
            return _listaUser;
        }

        public void SetListaUser(List<UserStat> listaUserStats)
        {
            _listaUser = listaUserStats;
        }

        private void IncrementaTesto(Message message)
        {
            ControllaUser(message);
            try
            {
                _listaUser.Single(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals((message.From.LastName ?? "").ToLower())).ContText += 1;
            }
            catch (Exception)
            {

                IftttManager.SendException($"L'utente {message.From.FirstName} ha la mamma molto maiala, non ha il cognome");
            }
        }

        private void IncrementaImmagini(Message message)
        {
            ControllaUser(message);
            _listaUser.Single(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals((message.From.LastName ?? "").ToLower())).ContImg += 1;

        }

        private void IncrementaAudio(Message message)
        {
            ControllaUser(message);
            _listaUser.Single(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals((message.From.LastName ?? "").ToLower())).ContAudio += 1;

        }

        private void ControllaUser(Message message)
        {
            if (!_listaUser.Any(x => x.Nome.Equals(message.From.FirstName.ToLower()) && x.Cognome.Equals((message.From.LastName ?? "").ToLower())))
            {
                _listaUser.Add(new UserStat
                {
                    Nome = message.From.FirstName?.ToLower() ?? "",
                    Cognome = message.From.LastName?.ToLower() ?? "",
                    Id = message.From.Id,
                    Username = message.From.Username?.ToLower() ?? ""
                });

            }

        }

        public int GetUserIdByName(string name)
        {
            try
            {

                var user = _listaUser.Single(x => x.Nome.Equals(name));
                return Convert.ToInt32(user.Id);

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int GetUserIdBySurname(string surname)
        {
            try
            {
                var user = _listaUser.Single(x => x.Cognome.Equals(surname));
                return Convert.ToInt32(user.Id);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int GetUserIdByNameSurname(string name, string surname)
        {
            try
            {

                var user = _listaUser.Single(x => x.Nome.Equals(name) && x.Cognome.Equals(surname));
                return Convert.ToInt32(user.Id);

            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int GetUserIdByUsername(string username)
        {
            try
            {
                var user = _listaUser.Single(x => x.Username.Equals(username));
                return Convert.ToInt32(user.Id);

            }
            catch (Exception)
            {

                return -1;
            }

        }

        public bool SalvaStatistiche()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            JsonManager.WriteToJsonFile(Path.Combine(currentDirectory, "Data", "statInfo.json"), _listaUser);
            return true;
        }

        public static List<UserStat> CaricaStistiche()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            return JsonManager.ReadFromJsonFile(Path.Combine(currentDirectory, "Data", "statInfo.json"));
        }


    }
}


