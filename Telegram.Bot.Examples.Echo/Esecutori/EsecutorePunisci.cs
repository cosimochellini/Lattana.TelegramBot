using System;
using System.Collections.Generic;
using Telegram.Bot.Examples.Echo.Generatore;
using Telegram.Bot.Examples.Echo.Manager;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Esecutori
{
    public static class EsecutorePunisci
    {
        public static void ComandoPunnisci(Message messaggio, TelegramBotClient bot, string[] comando, StatManager statManager)
        {
            var user = -1;

            switch (comando.Length)
            {
                case 0:
                case 1:
                case 2:
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "mi dispiace ma devi inserire la corretta sintassi per un adeguato funzionamento del comando punnisci \n \r " +
                                                      "Sintassi corretta: punnisci [nome/cognome/usrname/nomecognome] [nome/cognome/username/nomecognome da punnire]  " +
                                                      "Esempio: punnisci username giulioguidotti");
                    return;

                case 3:
                    user = GetUser(comando, statManager, bot, messaggio);
                    if (user.Equals(-1))
                    {
                        bot.SendTextMessageAsync(messaggio.Chat.Id, "oops qualcosa è andato storto");
                        return;
                    }
                    return;

                case 4:
                    statManager.GetUserIdByNameSurname(comando[2], comando[3]);
                    return;
            }

            try
            {
                if (GeneratoreSwitch.FraseContiene(comando, new[] { "cosimo", "chellini" }, 1))
                {
                    user = messaggio.From.Id;
                }
                bot.KickChatMemberAsync(messaggio.Chat.Id, user);
            }
            catch (Exception)
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Mi dispiace ma non sono riuscito a punnirlo");
            }
        }

        private static int GetUser(IReadOnlyList<string> comando, StatManager statManager, ITelegramBotClient bot, Message messaggio)
        {
            int user;

            switch (comando[1])
            {
                case "nome":
                    user = statManager.GetUserIdByName(comando[2]);
                    return user;
                case "cognome":
                    user = statManager.GetUserIdBySurname(comando[2]);
                    return user;
                case "username":
                    user = statManager.GetUserIdByUsername(comando[2]);
                    return user;
                case "nomecognome":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "con nomecognome devi inserire sia il nome che il cognome da cercare");
                    return -1;
            }
            return -1;
        }

    }
}
