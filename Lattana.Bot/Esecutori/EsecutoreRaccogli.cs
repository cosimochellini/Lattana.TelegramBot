using Telegram.Bot.Types;

namespace Lattana.Bot.Esecutori
{
    public static class EsecutoreRaccogli
    {

        public static void ComandoRaccogli(string[] comanando, Message messaggio)
        {
            if (comanando.Length == 1 && messaggio.From.FirstName != "Cosimmo")
                return;

            if (comanando[1] == "il" || comanando[1] == "la" || comanando[1] == "lo" || comanando[1] == "gli" || comanando[1] == "le")
                comanando[1] = comanando[2];

            if (comanando[1].Equals("federico") || comanando[1].Equals("Federico") || comanando[1].Equals("ruocchino") ||
                comanando[1].Equals("rocchino") || comanando[1].Equals("tocchino") || comanando[1].Equals("ruocco"))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "No, ruocchino non lo raccatto");
                return;
            }

            if (comanando[0].Equals("raccogli") || comanando[1].Equals("Raccogli"))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, comanando[1] + ", te la vuoi raccattare??");
            }
            else
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, comanando[1] + ", te la vuoi raccogliere??");
            }
        }

    }
}
