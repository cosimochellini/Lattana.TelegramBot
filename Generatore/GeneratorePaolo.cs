using System;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Generatore
{
    public static class GeneratorePaolo
    {
        private static string CreaPaolo(int casuale)
        {
            var offesa = new string[25];
            offesa[0] = "Chi fa da se... fa da se!";
            offesa[1] = "Occhio per occhio... occhio per occhio!";
            offesa[2] = "Chi trova un amico... trova un amico!";
            offesa[3] = "Chi va con lo zoppo... va con lo zoppo!";
            offesa[4] = "Donna al volante... donna al volante!";
            offesa[5] = "Chi la fa... la fa!";
            offesa[6] = "Occhio non vede... occhio non vede!";
            offesa[7] = "Meglio una gallina oggi... che una gallina oggi!";
            offesa[8] = "Patti chiari... patti chiari!";
            offesa[9] = "Donna barbuta... donna barbuta!";
            offesa[10] = "Pane al pane... pane al pane!";
            offesa[11] = "A mali estremi... a mali estremi!";
            offesa[12] = "Uomo avvisato... uomo avvisato!";
            offesa[13] = "Chi troppo vuole... troppo vuole!";
            offesa[14] = "Chi va piano... non ha un'Alfa!";
            offesa[15] = "Chi è senza peccato... è senza peccato!";
            offesa[16] = "Chi non beve in compagnia... non beve in compagnia!";
            offesa[17] = "Paese che vai... paese che vai!";
            offesa[18] = "Ogni promessa è... ogni promessa!";
            offesa[19] = "Una ne penso... una ne penso!";
            offesa[20] = "Can che abbia... can che abbaia!";
            offesa[21] = "Non dire gatto... non dire gatto!";
            offesa[22] = "Chi la fa, la fa";

            return offesa[casuale];
        }

        public static void ComandoBitta(Message messaggio, TelegramBotClient bot, int contatorePaolo)
        {
            bot.SendTextMessageAsync(messaggio.Chat.Id, CreaPaolo(new Random().Next(0, contatorePaolo + 1)));
        }
    }
}
