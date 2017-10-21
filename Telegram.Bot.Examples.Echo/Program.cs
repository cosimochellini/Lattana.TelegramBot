using System;
using System.Configuration;
using System.Diagnostics;
using Telegram.Bot.Args;
using Telegram.Bot.Examples.Echo.Generatore;
using Telegram.Bot.Examples.Echo.Manager;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Examples.Echo
{
    public static class Program
    {
        private static readonly string AccessToken = ConfigurationManager.AppSettings["AccessToken"];
        private static readonly StatManager StatManager = new StatManager();
        private static readonly TelegramBotClient Bot = new TelegramBotClient(AccessToken);
        private static void Main()
        {

            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnMessageEdited += BotOnMessageReceived;
            Bot.OnReceiveError += BotOnReceiveError; 
            try
            {
                var me = Bot.GetMeAsync().Result;
                Console.Title = me.Username;
            }
            catch (Exception)
            {
                IftttManager.SendException("problemi connessiones");
                throw;
            }

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Debugger.Break();
        }

        private static void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs chosenInlineResultEventArgs)
        {
            Console.WriteLine($"Received choosen inline result: {chosenInlineResultEventArgs.ChosenInlineResult.ResultId}");
        }

        private static void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            if (message == null || message.Type != MessageType.TextMessage) return;
            if (message.Text != null && message.Text == "statcarica")
            {
                var listaUser = StatManager.CaricaStistiche();
                StatManager.SetListaUser(listaUser);
            }

            if (!StatManager.CheckUpdate(message))
            {
                IftttManager.SendException("L'update non è andato a buon fine");
                Console.WriteLine("Update satatistiche non andato a buon fine");
            }

            if (message.NewChatMembers != null) //Controllo nuovo utente nuovo utente
            {
                if (message.NewChatMembers[0].Username == "LattanaBot")
                {
                    Bot.SendTextMessageAsync(message.Chat.Id, "Ho deciso di scendere in terra, così mi sono mostrato a voi, sciocchi umani");
                }
                else
                {
                    Bot.SendTextMessageAsync(message.Chat.Id, "Lattana da il benvenuto a " + message.NewChatMembers[0].FirstName + " poichè accoglie, ma gli ricorda che sa anche punnire");
                }
            }

            if (!GeneratoreSwitch.SwitchFunzioni(message, Bot, StatManager))
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
        }

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            await Bot.AnswerCallbackQueryAsync(callbackQueryEventArgs.CallbackQuery.Id,
                $"Received {callbackQueryEventArgs.CallbackQuery.Data}");
        }

        private static void MessaggiGiulio(Message messaggio)
        {
            Bot.SendTextMessageAsync(messaggio.Chat.Id, "Scusate Giulio, gli fa fatica fare qualsiasi cosa");
            Bot.SendTextMessageAsync(messaggio.Chat.Id, "Voleva dire: Va Bene");
        }

        private static void PaioGiulio(Message messaggio)
        {
            Bot.SendTextMessageAsync(messaggio.Chat.Id, "Scusate Giulio, gli fa fatica fare qualsiasi cosa");
            Bot.SendTextMessageAsync(messaggio.Chat.Id, "Voleva dire: paioled");
        }
    }
}
