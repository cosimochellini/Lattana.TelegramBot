using System;
using System.Collections.Generic;
using Lattana.Bot.Istance;
using Lattana.Bot.Manager;
using Telegram.Bot.Types;

namespace Lattana.Bot.Esecutori
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
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "mi dispiace ma devi inserire la corretta sintassi per un adeguato funzionamento del comando punnisci \n \r " +
                                                      "Sintassi corretta: punnisci [nome/cognome/usrname/nomecognome] [nome/cognome/username/nomecognome da punnire]  " +
                                                      "Esempio: punnisci username giulioguidotti");
                    return;

                case 3:
                    user = GetUser(comando, messaggio);
                    if (user.Equals(-1))
                    {
                        Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "oops qualcosa è andato storto");
                        return;
                    }
                    return;

                case 4:
                    StatManager.GetUserIdByNameSurname(comando[2], comando[3]);
                    return;
            }

            try
            {
                if (StringOperator.Contains(comando, new[] { "cosimo", "chellini" }, 1))
                {
                    user = messaggio.From.Id;
                }
                Istance.Bot.Istance.KickChatMemberAsync(messaggio.Chat.Id, user);
            }
            catch (Exception)
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Mi dispiace ma non sono riuscito a punnirlo");
            }
        }

        private static int GetUser(IReadOnlyList<string> comando, Message messaggio)
        {
            int user;

            switch (comando[1])
            {
                case "nome":
                    user = StatManager.GetUserIdByName(comando[2]);
                    return user;
                case "cognome":
                    user = StatManager.GetUserIdBySurname(comando[2]);
                    return user;
                case "username":
                    user = StatManager.GetUserIdByUsername(comando[2]);
                    return user;
                case "nomecognome":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "con nomecognome devi inserire sia il nome che il cognome da cercare");
                    return -1;
            }
            return -1;
        }

    }
}
