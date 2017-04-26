using System;
using System.Configuration;
using System.Threading.Tasks;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;
using TelegramBotDemo.Generatori;
using TelegramBotDemo.Manager;


namespace TelegramBotDemo
{
    public static class Program
    {
        private static readonly string AccessToken = ConfigurationManager.AppSettings["AccessToken"];
        private static readonly string Versione = ConfigurationManager.AppSettings["Versione"];
        private static readonly TelegramBot Bot = new TelegramBot(AccessToken);

        private static bool _offese = true;

        public static void Main(string[] args)
        {
            Console.WriteLine("Versione:" + Versione);

            var statManager = new StatManager();
            Task.Run(() => RunBot(AccessToken, statManager));
            Console.ReadLine();

        }

        private static void RunBot(string accessToken, StatManager statManager)
        {
            var bot = new TelegramBot(accessToken);

            //var me = bot.MakeRequestAsync(new GetMe()).Result;

            Console.WriteLine("This project uses nuget package, not 'live' project in solution (because 'live' project is vNext now)");
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
                    IftttManager.SendException("Connessione lenta");
                    Console.WriteLine("Ecceccione, accciderbolina");
                }

                if (updates == null) continue;

                foreach (var update in updates)
                {

                    if (!statManager.CheckUpdate(update))
                    {
                        IftttManager.SendException("L'update non è andato a buon fine");
                        Console.WriteLine("Update satatistiche non andato a buon fine");
                    }

                    offset = update.UpdateId + 1;

                    if (update.Message?.NewChatMember != null) //Controllo nuovo utente nuovo utente
                    {
                        if (update.Message.NewChatMember.Username == "LattanaBot")
                        {
                            Bot.MakeRequestAsync(new SendMessage(update.Message.Chat.Id, "Ho deciso di scendere in terra, così mi sono mostrato a voi, sciocchi umani")).Wait();
                        }
                        else
                        {
                            Bot.MakeRequestAsync(new SendMessage(update.Message.Chat.Id, "Lattana da il benvenuto a " + update.Message.NewChatMember.FirstName + " poichè accoglie, ma gli ricorda che sa anche punnire")).Wait();
                        }

                        break;
                    }
                    if (GeneratoreSwitch.SwitchFunzioni(update.Message, bot, _offese, statManager))
                        break;

                    if (update.Message == null) continue;

                    var from = update.Message.From;
                    Console.WriteLine($"Msg from {@from.FirstName} {@from.LastName} @ {@update.Message.Date}");

                    if (update.Message.Text == null) continue;

                    if ((from.FirstName == "Giulio" || from.FirstName == "giulio") && (update.Message.Text == "b" || update.Message.Text == "B" || update.Message.Text == "Bon" || update.Message?.Text == "bon" || update.Message.Text.Contains("bon")))
                    {
                        MessaggiGiulio(update.Message);
                        break;
                    }

                    if ((from.FirstName == "Giulio" || @from.FirstName == "giulio") && (update.Message.Text == "p"))
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
                        Bot.MakeRequestAsync(new SendMessage(update.Message.Chat.Id, "Tranquillo " + update.Message.From.FirstName + ", ora tutti possono offendere di nuovo")).Wait();
                        Bot.MakeRequestAsync(new SendMessage(update.Message.Chat.Id, "Aspetta, no scherzavo ahahahaah, coglione -.-")).Wait();
                    }

                    if (update.Message.From.FirstName == "Cosimo" || update.Message.Text != "Admin") continue;

                    Bot.MakeRequestAsync(new SendMessage(update.Message.Chat.Id, "Tranquillo " + update.Message.From.FirstName + ", ora tutti possono offendere di nuovo")).Wait();
                    Bot.MakeRequestAsync(new SendMessage(update.Message.Chat.Id, "Aspetta, no scherzavo ahahahaah, coglione -.-")).Wait();
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }


        private static void MessaggiGiulio(Message messaggio)
        {
            Bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Scusate Giulio, gli fa fatica fare qualsiasi cosa")).Wait();
            Bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Voleva dire: Va Bene")).Wait();
        }

        private static void PaioGiulio(Message messaggio)
        {
            Bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Scusate Giulio, gli fa fatica fare qualsiasi cosa")).Wait();
            Bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Voleva dire: paioled")).Wait();
        }
    }
}