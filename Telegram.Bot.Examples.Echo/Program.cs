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

            //Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnMessageEdited += BotOnMessageReceived;
            //Bot.OnInlineQuery += BotOnInlineQueryReceived;
            //Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
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

        //private static async void BotOnInlineQueryReceived(object sender, InlineQueryEventArgs inlineQueryEventArgs)
        //{
        //    InlineQueryResult[] results = {
        //        new InlineQueryResultLocation
        //        {
        //            Id = "1",
        //            Latitude = 40.7058316f, // displayed result
        //            Longitude = -74.2581888f,
        //            Title = "New York",
        //            InputMessageContent = new InputLocationMessageContent // message if result is selected
        //            {
        //                Latitude = 40.7058316f,
        //                Longitude = -74.2581888f,
        //            }
        //        },

        //        new InlineQueryResultLocation
        //        {
        //            Id = "2",
        //            Longitude = 52.507629f, // displayed result
        //            Latitude = 13.1449577f,
        //            Title = "Berlin",
        //            InputMessageContent = new InputLocationMessageContent // message if result is selected
        //            {
        //                Longitude = 52.507629f,
        //                Latitude = 13.1449577f
        //            }
        //        }
        //    };

        //    await Bot.AnswerInlineQueryAsync(inlineQueryEventArgs.InlineQuery.Id, results, isPersonal: true, cacheTime: 0);
        //}

        private static void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;


            //if (message.Voice != null)
            //{
            //    //VoiceManager.FileIdToByteArray(message.Voice.FileId, Bot, message.Voice.FileId);
            // var directory = Directory.GetCurrentDirectory();
            //   //var daje= SpeechManager.Rec(Path.Combine(directory, "prova.ogg") , int.MaxValue, RecognitionConfig.Types.AudioEncoding.Flac);
            //   //var daje= SpeechManager.SyncRecognize(Path.Combine(directory, "prova.ogg"));
            //    SpeechManager.Roar(new string[2]);

            //}

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
