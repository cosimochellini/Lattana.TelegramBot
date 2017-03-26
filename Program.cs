using System;
using System.Configuration;
using System.Threading.Tasks;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace TelegramBotDemo
{
    public static class Program
    {
        private static readonly string AccessToken = ConfigurationManager.AppSettings["AccessToken"];
        private static readonly TelegramBot Bot = new TelegramBot(AccessToken);
        private static readonly int ContOffese = 17;
        private static readonly int ContPerle = 20;
        private static readonly int ContPaolo = 23;
        private static readonly int ContSofferenza = 10;
        private static bool _offese = true;

        private static readonly GeneratoreSwitch ManagerSwtich = new GeneratoreSwitch();


        public static void Main(string[] args)
        {
            Console.WriteLine("Starting your bot...");
            Console.WriteLine();
            var t = Task.Run(() => RunBot(AccessToken));
            Console.ReadLine();
        }

        private static void RunBot(string accessToken)
        {
            var bot = new TelegramBot(accessToken);

            var me = bot.MakeRequestAsync(new GetMe()).Result;
            Console.WriteLine("{0} (@{1}) connected!", me.FirstName, me.Username);

            Console.WriteLine();
            Console.WriteLine("(Press ENTER to stop listening and quit)");
            Console.WriteLine(
                "ATENTION! This project uses nuget package, not 'live' project in solution (because 'live' project is vNext now)");
            Console.WriteLine();

            long offset = 0;
            while (true)
            {
                Update[] updates;
                try
                {
                    updates = bot.MakeRequestAsync(new GetUpdates() { Offset = offset }).Result;
                }
                catch (Exception)
                {
                    updates = null;
                    Console.WriteLine("Ecceccione, accciderbolina");
                }

                if (updates == null) continue;


                foreach (var update in updates)
                {
                    offset = update.UpdateId + 1;


                    if (update.Message?.NewChatMember != null) //Controllo nuovo utente nuovo utente
                    {
                        if (update.Message.NewChatMember.Username == "LattanaBot")
                        {
                            Bot.MakeRequestAsync(new SendMessage(
                                update.Message.Chat.Id,
                                "Ho deciso di scendere in terra, così mi sono mostrato a voi, sciocchi umani")).Wait();
                        }
                        else
                        {
                            Bot.MakeRequestAsync(new SendMessage(
                                update.Message.Chat.Id,
                                "Lattana da il benvenuto a " + update.Message.NewChatMember.FirstName +
                                " poichè accoglie, ma gli ricorda che sa anche punire")).Wait();
                        }

                    }


                    if (update.Message?.LeftChatMember != null)
                    {
                        Bot.MakeRequestAsync(new SendMessage(
                            update.Message.Chat.Id,
                            "Lattana punisce " + update.Message.LeftChatMember.FirstName + " per mano di " +
                            update.Message.From.FirstName)).Wait();
                    }
                    else
                    {
                        ManagerSwtich.SwitchFunzioni(update.Message, bot, ContSofferenza, _offese, ContOffese, ContPaolo, ContPerle);

                        if (update.Message != null)
                        {
                            var from = update.Message.From;
                            Console.WriteLine("Msg from {0} {1} @ {2}", @from.FirstName, @from.LastName,
                                @update.Message.Date);

                            if (@from.FirstName == "Federico" || @from.FirstName == "federico")
                            {
                                MessaggioFederico(update.Message);
                                break;
                            }

                            if (update.Message.Text != null)
                            {
                                if ((@from.FirstName == "Giulio" || @from.FirstName == "giulio") &&
                                    (update.Message.Text == "b" || update.Message.Text == "B" ||
                                     update.Message?.Text == "bon" || update.Message?.Text == "Bon" || update.Message.
                                         Text.Contains("bon") || update.Message.Text.Contains("Bon")))
                                {
                                    MessaggiGiulio(update.Message);
                                    break;
                                }

                                if (update.Message.From.FirstName == "Cosimo" && update.Message.Text == "Admin")
                                {
                                    _offese = !_offese;
                                }
                                if (update.Message.From.FirstName != "Cosimo" && update.Message.Text == "Admin")
                                {
                                    Bot.MakeRequestAsync(new SendMessage(
                           update.Message.Chat.Id,
                           "Tranquillo " + update.Message.From.FirstName + ", ora tutti possono offendere di nuovo")).Wait();

                                    Bot.MakeRequestAsync(new SendMessage(
                           update.Message.Chat.Id,
                           "Aspetta, no scherzavo ahahahaah, coglione -.-")).Wait();
                                }
                            }
                        }
                    }
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static void MessaggiGiulio(Message messaggio)
        {
            Bot.MakeRequestAsync(new SendMessage(
                messaggio.Chat.Id,
                "Scusate Giulio, gli fa fatica fare qualsiasi cosa")).Wait();

            Bot.MakeRequestAsync(new SendMessage(
                messaggio.Chat.Id,
                "Voleva dire: Va Bene")).Wait();
        }

        private static void MessaggioFederico(Message messaggio)
        {

            if (messaggio.Voice != null)
            {
                Bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                    "Maiala federico, i tuoi audio dimmerda hanno rotto telegram")).Wait();

            }


            if (messaggio.Sticker != null)
            {
                Bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                    "Maiala federico, i tuoi sticker brutti schifosi dimmerda hanno rotto telegram")).Wait();

            }

            if (messaggio.Video != null)
            {
                Bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                    "Maiala federico, i tuoi video dimmerda hanno rotto telegram")).Wait();

            }
            if (messaggio.LeftChatMember != null)
            {
                Bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                    "Maiala federico permaloso, che cazzo esci ogni 3 secondi da questo gruppo")).Wait();
            }

            if (messaggio.Photo != null)
            {
                Bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                    "Maiala federico, le tue foto dimmerda hanno rotto telegram")).Wait();
            }

            if (messaggio.Text != null)
            {
                Bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                    "Maiala federico, i tuoi messaggi dimmerda hanno rotto telegram")).Wait();
            }

        }

    }
}


//if (text == "/help")
//{
//    var keyb = new ReplyKeyboardMarkup()
//    {
//        Keyboard = new[]
//        {
//            new[]
//            {
//                new KeyboardButton("/photo"), new KeyboardButton("/doc"),
//                new KeyboardButton("/docutf8")
//            },
//            new[] {new KeyboardButton("/help")}
//        },
//        OneTimeKeyboard = true,
//        ResizeKeyboard = true
//    };
//    var reqAction = new SendMessage(update.Message.Chat.Id, "Here is all my commands")
//    {
//        ReplyMarkup = keyb
//    };
//    bot.MakeRequestAsync(reqAction).Wait();
//    continue;
//}
//if (update.Message.Text.Length%2 == 0)
//{
//    bot.MakeRequestAsync(new SendMessage(
//        update.Message.Chat.Id,
//        "You wrote *" + update.Message.Text.Length + " characters*")
//    {
//        ParseMode = SendMessage.ParseModeEnum.Markdown
//    }).Wait();
//}
//else
//{
//    bot.MakeRequestAsync(new ForwardMessage(update.Message.Chat.Id, update.Message.Chat.Id,
//        update.Message.MessageId)).Wait();
//}



//if (text == "/photo")
//{
//    if (uploadedPhotoId == null)
//    {
//        var reqAction = new SendChatAction(update.Message.Chat.Id, "upload_photo");
//        bot.MakeRequestAsync(reqAction).Wait();
//        System.Threading.Thread.Sleep(500);
//        using (
//            var photoData =
//                Assembly.GetExecutingAssembly()
//                    .GetManifestResourceStream("TelegramBotDemo.t_logo.png"))
//        {
//            var req = new SendPhoto(update.Message.Chat.Id,
//                new FileToSend(photoData, "Telegram_logo.png"))
//            {
//                Caption = "Telegram_logo.png"
//            };
//            var msg = bot.MakeRequestAsync(req).Result;
//            uploadedPhotoId = msg.Photo.Last().FileId;
//        }
//    }
//    else
//    {
//        var req = new SendPhoto(update.Message.Chat.Id, new FileToSend(uploadedPhotoId))
//        {
//            Caption = "Resending photo id=" + uploadedPhotoId
//        };
//        bot.MakeRequestAsync(req).Wait();
//    }
//    continue;
//}
//if (text == "/doc")
//{
//    if (uploadedDocumentId == null)
//    {
//        var reqAction = new SendChatAction(update.Message.Chat.Id, "upload_document");
//        bot.MakeRequestAsync(reqAction).Wait();
//        System.Threading.Thread.Sleep(500);
//        using (
//            var docData =
//                Assembly.GetExecutingAssembly()
//                    .GetManifestResourceStream("TelegramBotDemo.Telegram_Bot_API.htm"))
//        {
//            var req = new SendDocument(update.Message.Chat.Id,
//                new FileToSend(docData, "Telegram_Bot_API.htm"));
//            var msg = bot.MakeRequestAsync(req).Result;
//            uploadedDocumentId = msg.Document.FileId;
//        }
//    }
//    else
//    {
//        var req = new SendDocument(update.Message.Chat.Id,
//            new FileToSend(uploadedDocumentId));
//        bot.MakeRequestAsync(req).Wait();
//    }
//    continue;
//}



//if (photos != null)
//{
//    var webClient = new WebClient();
//    foreach (var photo in photos)
//    {
//        Console.WriteLine("  New image arrived: size {1}x{2} px, {3} bytes, id: {0}",
//            photo.FileId, photo.Height, photo.Width, photo.FileSize);
//        var file = bot.MakeRequestAsync(new GetFile(photo.FileId)).Result;
//        var tempFileName = System.IO.Path.GetTempFileName();
//        webClient.DownloadFile(file.FileDownloadUrl, tempFileName);
//        Console.WriteLine("    Saved to {0}", tempFileName);
//    }
//}


//     if (false)   //todo qua va passato il file corretto
//                            {

//                                //var f = new StreamContent();
//                                var file = new FileToSend("https://d3uepj124s5rcx.cloudfront.net/items/0W0E031m401A2H0T2w3v/Could%20Be%20Trump!.mp3");
////var reqAction = new SendAudio(update.Message.Chat.Id, new FileToSend());
////bot.MakeRequestAsync(update.Message.Chat.Id, file).Wait();
////System.Threading.Thread.Sleep(500);
////using (
////    var docData =
////        Assembly.GetExecutingAssembly()
////            .GetManifestResourceStream("TelegramBotDemo.Пример UTF8 filename.txt"))
////{
//var req = new SendDocument(update.Message.Chat.Id,
//   file);

//var msg = bot.MakeRequestAsync(req).Result;
//                                //   var  uploadedDocumentId = msg.Document.FileId;
//                                //}
//                                continue;
//                            }