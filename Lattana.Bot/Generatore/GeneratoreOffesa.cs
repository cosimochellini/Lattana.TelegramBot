using System;
using Lattana.Bot.Manager;
using Telegram.Bot.Types;

namespace Lattana.Bot.Generatore
{
    public static class GeneratoreOffesa
    {
        private static string CreaOffesa(string nomeDaOffendere, int casuale)
        {
            var offesa = new string[20];
            offesa[0] = nomeDaOffendere + " sei talmente stupido che assomigli a federico";
            offesa[1] = nomeDaOffendere + " sei talmente ebreo che non so come ettore non ti abbia ancora bruciato vivo";
            offesa[2] = nomeDaOffendere + " sei come la minchia: sempre tra le palle";
            offesa[3] = nomeDaOffendere + " sei cosi scemo che guardi pure peppa pig";
            offesa[4] = nomeDaOffendere + " abbraccia la tazza del cesso e cantagli: non son degno di te";
            offesa[5] = $"Dio sparse l'intelligenza attraverso la pioggia...peccato che quel giorno {nomeDaOffendere} aveva l'ombrello!!";
            offesa[6] = nomeDaOffendere + " ha un cervello così piccolo che quando due pensieri si incontrano devono fare manovra";
            offesa[7] = nomeDaOffendere + $" {nomeDaOffendere},  {nomeDaOffendere}, {nomeDaOffendere} .... che nome dimmerda fattelo dire";
            offesa[8] = " Sapete perchè pestano spesso " + nomeDaOffendere + " (e rocchino), perchè porta fortuna";
            offesa[9] = nomeDaOffendere + " sei come il sole, inguardabile";
            offesa[10] = nomeDaOffendere + " sei come ruocchino, il denutrito dei denutriti";
            offesa[11] = nomeDaOffendere + " sei come ruocchino, ebreo";
            offesa[12] = nomeDaOffendere + " sei come ruocchino, ruocchino";
            offesa[13] = nomeDaOffendere + " sei come ruocchino, tocchino";
            offesa[14] = nomeDaOffendere + " sei come ruocchino, stupido";
            offesa[15] = nomeDaOffendere + " sei come ruocchino, deun";
            offesa[16] = nomeDaOffendere + " sei come ruocchino, denutrito";
            offesa[17] = nomeDaOffendere + " sei come ruocchino, boh ruocchino in generale";
            return offesa[casuale];
        }


        public static void ComandoInsulta(string[] comanando, Message messaggio, int contatoreOffese)
        {
            try
            {
                if (comanando[1] == "il" || comanando[1] == "la" || comanando[1] == "lo" || comanando[1] == "gli" || comanando[1] == "le")
                    comanando[1] = comanando[2];

            }
            catch (Exception)
            {
                IftttManager.SendException("Eccezione Gestre Comandi \n \r" + messaggio.From.Username);
                Console.WriteLine("Eccezione il lo la");
                Console.WriteLine("GestoreComandi riga 170");
                return;
            }

            switch (comanando[1])
            {
                case "cosimo":
                case "chello":
                case "kelinic":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Uno con il nome a cazzo tipo " + messaggio.From.FirstName + " farebbe meglio a stare zitto");
                    return;
                case "giulio":
                case "guidotti":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Non mi sembra il caso di offendere giulio, è già messo male per conto suo");
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "E poi lui abita dentro di me, non ho voglia di sentirlo soffrire");
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Come se lui non soffrisse abbastanza");
                    return;

                case "ruocco":
                case "rocchino":
                case "ruocchino":
                case "federico":
                case "tocchino":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Con grande piacere");
                    break;

                case "lattana":
                case "ttana":
                case "tana":
                case "lattanabot":
                case "lattanaBot":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Hahahaha " + messaggio.From.FirstName + " sei veramente un cretino");
                    return;

            }

            Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, CreaOffesa(comanando[1], new Random().Next(0, contatoreOffese)));
        }


    }
}
