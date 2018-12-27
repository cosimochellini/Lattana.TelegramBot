using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Lattana.Bot.Generatore
{
    public static class GeneratoreSofferenza
    {
        private static string GeneratoreSoffro(int casuale)
        {
            var offesa = new string[20];
            offesa[0] = "Che palle anche stasera sono tutta sola";
            offesa[1] = "Ollioi ma non venite mai?";
            offesa[2] = "Anche stasera sola?, impicco time";
            offesa[3] = "Maiala anche stasera mi tocca sentire Giulio soffrire, che palle";
            offesa[4] = "Basta, non vi fo più entrare, mi do al cinema, a Holli en huds";
            offesa[5] = "Basta, non vi fo più entrare, mi do al cinema, voglio solo fighetti da discoteca";
            offesa[6] = "Via andrò a sbucciarmi di ditalini, tanto non ho un cazzo da fare, come Giulio, d'altronde";
            offesa[7] = "Siete delle merde, vado a fare cinema, a Holli en huds";
            offesa[8] = "Maiala, siete peggio di tocchino";
            offesa[9] = "Ma porca merda, è 40 anni che non si fa nulla";
            offesa[10] = "Anche oggi calcetto?, che palle";
            offesa[10] = "Verrà il giorno, il giorno in cui si compirà la settimana perfetta";
            return offesa[casuale];
        }


        public static void Sofferenza(Message messaggio, TelegramBotClient bot, int contSofferenza)
        {
            bot.SendTextMessageAsync(messaggio.Chat.Id, GeneratoreSoffro(new Random().Next(0, contSofferenza)));

        }

    }
}
