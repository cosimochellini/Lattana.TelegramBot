using System;
using System.Configuration;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace TelegramBotDemo
{


    public class GeneratoreComandi

    {
        private static readonly string Versione = ConfigurationManager.AppSettings["Versione"];

        public void ComandoBitta(Message messaggio, TelegramBot bot, int contatorePaolo)
        {
            var casuale = new Random();


            var paolo = new GeneratorePaolo();
            var offesa = paolo.CreaPaolo(casuale.Next(0, contatorePaolo));
            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, offesa)).Wait();

        }

        public void ComandoProfeta(Message messaggio, TelegramBot bot, int contatoreProfezia, int sceltaNonCasuale = 0)
        {
            var generatoreProfezia = new GeneratoreProfeta();
            int numero;
            if (sceltaNonCasuale == 0)
            {
                var casuale = new Random();
                numero = casuale.Next(0, contatoreProfezia);
            }
            else
            {
                numero = sceltaNonCasuale;
            }

            var profezia = generatoreProfezia.CreaProfezia(numero);
            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, profezia)).Wait();


        }

        public void ComandoRaccogli(string[] comanando, Message messaggio, TelegramBot bot)
        {
            if (comanando[1] == "il" || comanando[1] == "la" || comanando[1] == "lo" || comanando[1] == "gli" || comanando[1] == "le")
                comanando[1] = comanando[2];

            if (comanando[1].Equals("federico") || comanando[1].Equals("Federico") || comanando[1].Equals("ruocchino") ||
                comanando[1].Equals("rocchino") || comanando[1].Equals("tocchino") || comanando[1].Equals("ruocco"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "No, ruocchino non lo raccatto")).Wait();
                return;
            }

            if (comanando[0].Equals("raccogli") || comanando[1].Equals("Raccogli"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, comanando[1] + ", te la vuoi raccattare??")).Wait();

            }
            else
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, comanando[1] + ", te la vuoi raccogliere??")).Wait();

            }
        }

        public void ComandoVai(string[] comanando, Message messaggio, TelegramBot bot)
        {
            if (comanando.Length <= 2)
                return;

            if (comanando[1] == "a")
                comanando[1] = comanando[2];

            switch (comanando[1])
            {
                case "fanculo":
                case "Fanculo":
                    bot.MakeRequestAsync(new SendMessage(
                     messaggio.Chat.Id,
                     "Abbiamo un simpaticone fra di noi, non è vero?")).Wait();
                    bot.MakeRequestAsync(new SendMessage(
                     messaggio.Chat.Id,
                     messaggio.From.FirstName + " vacci te con tre tappi in culo (con amore <3) ")).Wait();

                    break;


                case "Dormire":
                case "dormire":
                    bot.MakeRequestAsync(new SendMessage(
                     messaggio.Chat.Id,
                     "idiota, non sono mica spacobot")).Wait();

                    bot.MakeRequestAsync(new SendMessage(
                     messaggio.Chat.Id,
                     "Io non dormo mai, al massimo riposo gli occhi")).Wait();
                    break;
            }
        }


        public void ComandoLattana(string[] comanando, Message messaggio, TelegramBot bot)
        {

            if (comanando.Length <= 2)
            {
                bot.MakeRequestAsync(new SendMessage(
                         messaggio.Chat.Id,
                        messaggio.From.FirstName + " perchè nomini il mio nome invano?")).Wait();
                return;

            }

            if (comanando[1] == "il" || comanando[1] == "la" || comanando[1] == "lo" || comanando[1] == "gli" || comanando[1] == "le")
                comanando[1] = comanando[2];


            switch (comanando[1])
            {
                case "Accogli":
                case "accogli":
                    if (comanando.Length < 3)
                    {
                        bot.MakeRequestAsync(new SendMessage(
                       messaggio.Chat.Id,
                       "Da sempre, lattana accoglie chiunque")).Wait();
                    }
                    else
                    {
                        bot.MakeRequestAsync(new SendMessage(
                      messaggio.Chat.Id,
                      "Benvenuto " + comanando[2] + " in lattana, io so accogliere, ma so anche punire")).Wait();
                    }
                    return;
                case "Mostra":
                case "mostra":
                    if (comanando.Length < 3)
                    {
                        bot.MakeRequestAsync(new SendMessage(
                       messaggio.Chat.Id,
                       "Molto interessante, però, hai visto la vastità del cazzo che me ne frega?")).Wait();
                    }
                    else
                    {
                        bot.MakeRequestAsync(new SendMessage(
                          messaggio.Chat.Id,
                         "Ok " + comanando[2] + " ma almeno hai visto l'immensità del cazzo che me ne frega?")).Wait();

                    }
                    return;

                case "punisci":
                case "Punisci":
                    break;

                case "vaffanculo":
                case "Vaffanculo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?")).Wait();
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te con tre tappi in culo (con amore <3) ")).Wait();
                    break;

            }

        }

        public void ComandoInsulta(string[] comanando, Message messaggio, bool offese, TelegramBot bot, int contatoreOffese)
        {

            if (messaggio.From.FirstName != "Cosimo" && messaggio.From.FirstName != "cosimo" &&
                messaggio.From.FirstName != "Giulio" && messaggio.From.FirstName != "giulio" &&
                messaggio.From.FirstName != "Gabriele" && messaggio.From.FirstName != "gabriele" &&
                messaggio.From.FirstName != "Diego" && messaggio.From.FirstName != "diego" &&
                !offese)

            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Mi dispiace, ma ne Lattana non si può offendere nessuno")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "O meglio, te " + messaggio.From.FirstName + " non hai il privilegio di usare tutte le mie funzionalità")).Wait();
                return;
            }

            if (comanando[1] == "il" || comanando[1] == "la" || comanando[1] == "lo" || comanando[1] == "gli" || comanando[1] == "le")
                comanando[1] = comanando[2];

            switch (comanando[1])
            {
                case "cosimo":
                case "Cosimo":
                case "chello":
                case "kelinic":
                case "Chello":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Uno con il nome a cazzo tipo " + messaggio.From.FirstName + " farebbe meglio a stare zitto")).Wait();
                    return;
                case "Giulio":
                case "giulio":
                case "guidotti":
                case "Guidotti":
                    bot.MakeRequestAsync(new SendMessage(
                        messaggio.Chat.Id,
                        "Non mi sembra il caso di offendere giulio, è già messo male per conto suo")).Wait();
                    bot.MakeRequestAsync(new SendMessage(
                      messaggio.Chat.Id,
                      "E poi lui abita dentro di me, non ho voglia di sentirlo soffrire")).Wait();

                    bot.MakeRequestAsync(new SendMessage(
                       messaggio.Chat.Id,
                      "Come se lui non soffrisse abbastanza")).Wait();
                    return;

                case "Ruocco":
                case "ruocco":
                case "rocchino":
                case "Rocchino":
                case "ruocchino":
                case "Ruocchino":
                case "Federico":
                case "federico":
                case "tocchino":
                case "Tocchino":
                    bot.MakeRequestAsync(new SendMessage(
                        messaggio.Chat.Id,
                        "Con grande piacere")).Wait();
                    break;

                case "Lattana":
                case "lattana":
                case "lattanabot":
                case "lattanaBot":
                case "LattanaBot":
                    bot.MakeRequestAsync(new SendMessage(
                            messaggio.Chat.Id,
                            "Hahahaha " + messaggio.From.FirstName + " sei veramente un cretino")).Wait();
                    return;

            }


            //Qua verranno tutte le offese più generiche
            var casuale = new Random();

            var generatore = new GeneratoreOffesa();
            var offesa = generatore.CreaOffesa(comanando[1], casuale.Next(0, contatoreOffese));
            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, offesa)).Wait();


        }
        
        public void ComandoInfo(Message messaggio, TelegramBot bot)
        {
            bot.MakeRequestAsync(new SendMessage(
                       messaggio.Chat.Id,
                       "Ciao " + messaggio.From.FirstName + " ecco cosa so fare, per ora sono in beta " + Versione + " , ma migliorerò")).Wait();
            bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                       "GLI AUDIOOOOO ERA L'ORAAAAAA")).Wait();
            bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                       "Sticker Nomrali/Porno")).Wait();

            bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                       "Sito nazista")).Wait();

            bot.MakeRequestAsync(new SendMessage(
                     messaggio.Chat.Id,
                        "Insulta [Qualcuno]")).Wait();
            bot.MakeRequestAsync(new SendMessage(
                messaggio.Chat.Id,
                        "Vai [fancuno / dormire]")).Wait();
            bot.MakeRequestAsync(new SendMessage(
                    messaggio.Chat.Id,
                        "Lattana Accogli[Qualcuno]/Vaffanculo/Mostra")).Wait();
            bot.MakeRequestAsync(new SendMessage(
                   messaggio.Chat.Id,
                        "Proverbio")).Wait();
            bot.MakeRequestAsync(new SendMessage(
                  messaggio.Chat.Id,
                        "Bruto/Belo")).Wait();
            bot.MakeRequestAsync(new SendMessage(
                  messaggio.Chat.Id,
                        "Poherino?")).Wait();

            bot.MakeRequestAsync(new SendMessage(
                 messaggio.Chat.Id,
                        "Paolo?")).Wait();

            bot.MakeRequestAsync(new SendMessage(
                messaggio.Chat.Id,
                        "Fai soffrire Giulio")).Wait();



            bot.MakeRequestAsync(new SendMessage(
                messaggio.Chat.Id,
                        "Raccogli/Raccatta [Qualcuno]")).Wait();


            bot.MakeRequestAsync(new SendMessage(
                  messaggio.Chat.Id,
                        "Ricezione parole chiave tipo orso/bang/studdio")).Wait();

        }

    }

}
