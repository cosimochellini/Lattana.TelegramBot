using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Generatore
{
    public static class GeneratoreSofferenza4Giulio
    {
        public static void CreaSofferenza(Message messaggio, TelegramBotClient bot, int casuale)
        {
            var sofferenza4Giulio = new string[10];
            sofferenza4Giulio[0] = "Silvia, soffro";
            sofferenza4Giulio[1] = "Jessica, soffro";
            sofferenza4Giulio[2] = "Piscina del morandi, soffro";
            sofferenza4Giulio[3] = "Vecchi tempi, soffro";
            sofferenza4Giulio[4] = "Devo fare 3 rampe di scale, soffro";
            sofferenza4Giulio[5] = "Devo fare 4 rampe di scale, soffro troppo";
            sofferenza4Giulio[6] = "Silvia, soffro";
            sofferenza4Giulio[7] = "Patatine nel proprio piatto, soffro";
            sofferenza4Giulio[8] = "Dual core, soffro";
            sofferenza4Giulio[9] = "Silvia, soffro";

            bot.SendTextMessageAsync(messaggio.Chat.Id, sofferenza4Giulio[casuale]);
        }
    }
}