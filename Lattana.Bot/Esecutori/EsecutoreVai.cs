using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Esecutori
{
    public static class EsecutoreVai
    {

        public static void ComandoVai(string[] comanando, Message messaggio)
        {
            if (comanando.Length <= 2)
                return;

            if (comanando[1] == "a")
                comanando[1] = comanando[2];

            switch (comanando[1])
            {
                case "fanculo":
                case "Fanculo":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?");
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te con tre tappi in culo (con amore <3) ");
                    break;

                case "Dormire":
                case "dormire":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "idiota, non sono mica spacobot");
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Io non dormo mai, al massimo riposo gli occhi");
                    break;
            }
        }

    }
}
