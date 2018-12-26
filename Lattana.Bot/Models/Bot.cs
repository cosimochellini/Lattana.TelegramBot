using System;
using System.Configuration;
using System.Diagnostics;
using Telegram.Bot.Args;
using Telegram.Bot.Examples.Echo.Generatore;
using Telegram.Bot.Examples.Echo.Manager;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Examples.Echo.Models
{
    public static class Bot
    {
        private static readonly string AccessToken = ConfigurationManager.AppSettings["AccessToken"];

        public static readonly TelegramBotClient Istance = new TelegramBotClient(AccessToken);

        public static void LoadHook()
        {
            Istance.OnMessage += BotOnMessageReceived;
            Istance.OnMessageEdited += BotOnMessageReceived;
            Istance.OnReceiveError += BotOnReceiveError;

            try
            {
                var me = Istance.GetMeAsync().Result;
                Console.Title = me.Username;
            }
            catch (Exception)
            {
                IftttManager.SendException("problemi connessiones");
                throw;
            }
        }

        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Debugger.Break();
        }

        private static void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;

            if (message.NewChatMembers != null) //Controllo nuovo utente nuovo utente
            {
                if (message.NewChatMembers[0].Username == "LattanaBot")
                {
                    Istance.SendTextMessageAsync(message.Chat.Id, "Ho deciso di scendere in terra, così mi sono mostrato a voi, sciocchi umani");
                }
                else
                {
                    Istance.SendTextMessageAsync(message.Chat.Id, "Lattana da il benvenuto a " + message.NewChatMembers[0].FirstName + " poichè accoglie, ma gli ricorda che sa anche punnire");
                }
            }

            if (!GeneratoreSwitch.SwitchFunzioni(message))
                return;

            var from = message.From;
            Console.WriteLine($"Msg from {from.FirstName} {from.LastName} @ {message.Date}  chat : {message.Chat.Title}");

            if (message.Text != null)
            {
                if ((from.FirstName == "Giulio" || from.FirstName == "giulio") &&
                    (message.Text == "b" || message.Text == "B" ||
                     message.Text == "Bon" || message.Text == "bon" ||
                     message.Text.Contains("bon")))
                {
                    MessaggiGiulio(message);
                    return;
                }

                if ((from.FirstName == "Giulio" || from.FirstName == "giulio") &&
                    (message.Text == "p"))
                {
                    PaioGiulio(message);
                }
            }

            if (!StatManager.CheckUpdate(message))
            {
                IftttManager.SendException("L'update non è andato a buon fine");
                Console.WriteLine("Update satatistiche non andato a buon fine");
            }
        }

        private static void MessaggiGiulio(Message messaggio)
        {
            Istance.SendTextMessageAsync(messaggio.Chat.Id, "Scusate Giulio, gli fa fatica fare qualsiasi cosa");
            Istance.SendTextMessageAsync(messaggio.Chat.Id, "Voleva dire: Va Bene");
        }

        private static void PaioGiulio(Message messaggio)
        {
            Istance.SendTextMessageAsync(messaggio.Chat.Id, "Scusate Giulio, gli fa fatica fare qualsiasi cosa");
            Istance.SendTextMessageAsync(messaggio.Chat.Id, "Voleva dire: paioled");
        }
    }
}
