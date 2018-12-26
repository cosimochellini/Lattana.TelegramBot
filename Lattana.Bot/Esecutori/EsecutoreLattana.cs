using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Esecutori
{
    public static class EsecutoreLattana
    {
        public static void ComandoLattana(string[] comanando, Message messaggio)
        {

            if (comanando.Length <= 2)
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, messaggio.From.FirstName + " perchè nomini il mio nome invano?");
                return;

            }

            if (comanando[1] == "il" || comanando[1] == "la" || comanando[1] == "lo" || comanando[1] == "gli" || comanando[1] == "le")
                comanando[1] = comanando[2];


            switch (comanando[1])
            {
                case "Accogli":
                case "accogli":
                    if (comanando.Length < 3)
                    {
                        Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Da sempre, lattana accoglie chiunque");
                    }
                    else
                    {
                        Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Benvenuto " + comanando[2] + " in lattana, io so accogliere, ma so anche punire");
                    }
                    return;
                case "Mostra":
                case "mostra":
                    if (comanando.Length < 3)
                    {
                        Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Molto interessante, però, hai visto la vastità del cazzo che me ne frega?");
                    }
                    else
                    {
                        Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Ok " + comanando[2] + " ma almeno hai visto l'immensità del cazzo che me ne frega?");
                    }
                    return;

                case "punisci":
                case "Punisci":
                    break;

                case "vaffanculo":
                case "Vaffanculo":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?");
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te con tre tappi in culo (con amore <3) ");
                    break;
            }

        }

    }
}
