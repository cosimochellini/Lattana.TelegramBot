using System;
using System.Configuration;
using System.Speech.Recognition;
using System.Threading.Tasks;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;
using TelegramBotDemo.Generatori;


namespace TelegramBotDemo
{
    public static class Program
    {
        private static readonly string AccessToken = ConfigurationManager.AppSettings["AccessToken"];
        private static readonly string Versione = ConfigurationManager.AppSettings["Versione"];
        private static readonly TelegramBot Bot = new TelegramBot(AccessToken);

        private static bool _offese = true;
        private static bool _giano = true;

        private static readonly GeneratoreSwitch ManagerSwtich = new GeneratoreSwitch();

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting your bot...");
            Console.WriteLine("Versione:" + Versione);
            Console.WriteLine();
            var t = Task.Run(() => RunBot(AccessToken));
            Console.ReadLine();

        }

        private static void RunBot(string accessToken)
        {
            var bot = new TelegramBot(accessToken);

            var me = bot.MakeRequestAsync(new GetMe()).Result;

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
                                " poichè accoglie, ma gli ricorda che sa anche punnire")).Wait();
                        }

                    }


                    if (update.Message?.LeftChatMember != null)
                    {
                        if (update.Message.LeftChatMember.FirstName == "Lattana")
                            break;
                        Bot.MakeRequestAsync(new SendMessage(
                            update.Message.Chat.Id,
                            "Lattana punnisce " + update.Message.LeftChatMember.FirstName + " per mano di " +
                            update.Message.From.FirstName)).Wait();
                    }
                    else
                    {
                        ManagerSwtich.SwitchFunzioni(update.Message, bot, _offese, _giano);

                        if (update.Message != null)
                        {

                            var from = update.Message.From;
                            Console.WriteLine("Msg from {0} {1} @ {2}", @from.FirstName, @from.LastName,
                                @update.Message.Date);

                            //if (@from.FirstName == "Federico" || @from.FirstName == "federico")
                            //{
                            //    MessaggioFederico(update.Message);
                            //    break;
                            //}

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


                                if ((@from.FirstName == "Giulio" || @from.FirstName == "giulio") &&
                                   (update.Message.Text == "p" || update.Message.Text == "P" ))
                                {
                                    PaioGiulio(update.Message);
                                    break;
                                }

                                if (update.Message.From.FirstName == "Cosimo" && update.Message.Text == "Admin")
                                {
                                    _offese = !_offese;
                                }


                                if (update.Message.From.FirstName != "Cosimo" && update.Message.Text == "admin")
                                {
                                    Bot.MakeRequestAsync(new SendMessage(
                                         update.Message.Chat.Id,
                                                "Tranquillo " + update.Message.From.FirstName + ", ora tutti possono offendere di nuovo")).Wait();

                                    Bot.MakeRequestAsync(new SendMessage(
                                    update.Message.Chat.Id,
                               "Aspetta, no scherzavo ahahahaah, coglione -.-")).Wait();
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

        private static void PaioGiulio(Message messaggio)
        {
            Bot.MakeRequestAsync(new SendMessage(
                messaggio.Chat.Id,
                "Scusate Giulio, gli fa fatica fare qualsiasi cosa")).Wait();

            Bot.MakeRequestAsync(new SendMessage(
                messaggio.Chat.Id,
                "Voleva dire: paioled")).Wait();
        }

        //private static void MessaggioFederico(Message messaggio)
        //{

        //    if (messaggio.Voice != null)
        //    {
        //        Bot.MakeRequestAsync(new SendMessage(
        //            messaggio.Chat.Id,
        //            "Maiala federico, i tuoi audio dimmerda hanno rotto telegram")).Wait();

        //    }


        //    if (messaggio.Sticker != null)
        //    {
        //        Bot.MakeRequestAsync(new SendMessage(
        //            messaggio.Chat.Id,
        //            "Maiala federico, i tuoi sticker brutti schifosi dimmerda hanno rotto telegram")).Wait();
        //    }

        //    if (messaggio.Video != null)
        //    {
        //        Bot.MakeRequestAsync(new SendMessage(
        //            messaggio.Chat.Id,
        //            "Maiala federico, i tuoi video dimmerda hanno rotto telegram")).Wait();
        //    }
        //    if (messaggio.LeftChatMember != null)
        //    {
        //        Bot.MakeRequestAsync(new SendMessage(
        //            messaggio.Chat.Id,
        //            "Maiala federico permaloso, che cazzo esci ogni 3 secondi da questo gruppo")).Wait();
        //    }

        //    if (messaggio.Photo != null)
        //    {
        //        Bot.MakeRequestAsync(new SendMessage(
        //            messaggio.Chat.Id,
        //            "Maiala federico, le tue foto dimmerda hanno rotto telegram")).Wait();
        //    }

        //    if (messaggio.Text != null)
        //    {
        //        Bot.MakeRequestAsync(new SendMessage(
        //            messaggio.Chat.Id,
        //            "Maiala federico, i tuoi messaggi dimmerda hanno rotto telegram")).Wait();
        //    }
        //}
    }
}