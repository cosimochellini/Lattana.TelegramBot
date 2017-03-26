using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace TelegramBotDemo
{
    internal class GeneratoreAudio
    {
        public void SwitchAudio(string[] comanando, Message messaggio, TelegramBot bot)
        {
            switch (comanando[1])
            {
                case "info":
                case "Info":
                    bot.MakeRequestAsync(new SendMessage(
              messaggio.Chat.Id,
              "Qua verrà mandata la lista degli audio che potrai scrivere")).Wait();
                    break;


                    
            }

        }
    }
}