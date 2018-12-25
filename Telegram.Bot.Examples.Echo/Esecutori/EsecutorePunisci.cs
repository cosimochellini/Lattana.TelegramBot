using System;
using System.Collections.Generic;
using Telegram.Bot.Examples.Echo.Generatore;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Esecutori
{
    public static class EsecutorePunisci
    {
        public static void ComandoPunnisci(Message messaggio, string[] comando)
        {
            var user = -1;

            switch (comando.Length)
            {
                case 0:
                case 1:
                case 2:
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "mi dispiace ma devi inserire la corretta sintassi per un adeguato funzionamento del comando punnisci \n \r " +
                                                      "Sintassi corretta: punnisci [nome/cognome/usrname/nomecognome] [nome/cognome/username/nomecognome da punnire]  " +
                                                      "Esempio: punnisci username giulioguidotti");
                    return;

                case 3:
                    user = GetUser(comando, messaggio);
                    if (user.Equals(-1))
                    {
                        Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "oops qualcosa è andato storto");
                        return;
                    }
                    return;

                case 4:
                    Models.Bot.StatManager.GetUserIdByNameSurname(comando[2], comando[3]);
                    return;
            }

            try
            {
                if (GeneratoreSwitch.FraseContiene(comando, new[] { "cosimo", "chellini" }, 1))
                {
                    user = messaggio.From.Id;
                }
                Models.Bot.Istance.KickChatMemberAsync(messaggio.Chat.Id, user);
            }
            catch (Exception)
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Mi dispiace ma non sono riuscito a punnirlo");
            }
        }

        private static int GetUser(IReadOnlyList<string> comando, Message messaggio)
        {
            int user;

            switch (comando[1])
            {
                case "nome":
                    user = Models.Bot.StatManager.GetUserIdByName(comando[2]);
                    return user;
                case "cognome":
                    user = Models.Bot.StatManager.GetUserIdBySurname(comando[2]);
                    return user;
                case "username":
                    user = Models.Bot.StatManager.GetUserIdByUsername(comando[2]);
                    return user;
                case "nomecognome":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "con nomecognome devi inserire sia il nome che il cognome da cercare");
                    return -1;
            }
            return -1;
        }

    }
}
