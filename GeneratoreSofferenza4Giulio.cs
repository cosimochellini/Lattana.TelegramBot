using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace TelegramBotDemo
{
    internal class GeneratoreSofferenza4Giulio
    {
        public void creaSofferenza(Message messaggio, TelegramBot bot, int casuale)
        {

            string[] sofferenza4Giulio = new string[5];

            sofferenza4Giulio[0] = "Silvia, soffro";
            sofferenza4Giulio[1] = "Jessica, soffro";
            sofferenza4Giulio[2] = "Piscina del morandi, soffro";
            sofferenza4Giulio[3] = "Vecchi tempi, soffro";
            sofferenza4Giulio[4] = "Devo fare 3 rampe di scale, soffro";


            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id,sofferenza4Giulio[casuale] )).Wait();
        }
    }
}