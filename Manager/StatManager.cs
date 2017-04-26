using System.Collections.Generic;
using System.Linq;
using NetTelegramBotApi.Types;
using TelegramBotDemo.Models;

namespace TelegramBotDemo.Manager
{
    public class StatManager
    {
        private readonly List<UserStat> _listaUser = new List<UserStat>();


        public bool CheckUpdate(Update update)
        {
            if (update.Message.From.Username == "Lattana")
                return true;

            if (update.Message.Audio != null || update.Message.Voice != null)
            {
                IncrementaAudio(update);
                return true;
            }

            if (update.Message.Text != null)
            {
                IncrementaTesto(update);
                return true;
            }

            if (update.Message.Photo != null)
            {
                IncrementaImmagini(update);
                return true;
            }

            if (update.Message.Sticker != null)
            {
                IncrementaSticker(update);
                return true;

            }
            return false;
        }

        private void IncrementaSticker(Update update)
        {
            ControllaUser(update);
            _listaUser.Single(x => x.Nome.Equals(update.Message.From.FirstName.ToLower()) && x.Cognome.Equals(update.Message.From.LastName.ToLower())).ContSticker++;
        }

        public List<UserStat> GetListaUser()
        {
            return _listaUser;
        }

        private void IncrementaTesto(Update update)
        {
            ControllaUser(update);
            _listaUser.Single(x => x.Nome.Equals(update.Message.From.FirstName.ToLower()) && x.Cognome.Equals(update.Message.From.LastName.ToLower())).ContText++;
        }

        private void IncrementaImmagini(Update update)
        {
            ControllaUser(update);
            _listaUser.Single(x => x.Nome.Equals(update.Message.From.FirstName.ToLower()) && x.Cognome.Equals(update.Message.From.LastName.ToLower())).ContImg++;
        }

        private void IncrementaAudio(Update update)
        {
            ControllaUser(update);
            _listaUser.Single(x => x.Nome.Equals(update.Message.From.FirstName.ToLower()) && x.Cognome.Equals(update.Message.From.LastName.ToLower())).ContAudio++;
        }

        private void ControllaUser(Update update)
        {
            if (!_listaUser.Any(x => x.Nome.Equals(update.Message.From.FirstName.ToLower()) && x.Cognome.Equals(update.Message.From.LastName.ToLower())))
            {
                _listaUser.Add(new UserStat
                {
                    Nome = update.Message.From.FirstName.ToLower(),
                    Cognome = update.Message.From.LastName.ToLower(),
                    Id = update.Message.From.Id
                });
            }

        }

    }
}


