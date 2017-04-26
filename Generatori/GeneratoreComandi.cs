using System;
using System.Configuration;
using System.Linq;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;
using TelegramBotDemo.Manager;
using TelegramBotDemo.Models;

namespace TelegramBotDemo.Generatori
{
    public static class GeneratoreComandi
    {
        private static readonly string Versione = ConfigurationManager.AppSettings["Versione"];

        public static void ComandoBitta(Message messaggio, TelegramBot bot, int contatorePaolo)
        {
            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, GeneratorePaolo.CreaPaolo(new Random().Next(0, contatorePaolo + 1)))).Wait();
        }

        public static void ComandoProfeta(Message messaggio, TelegramBot bot, int contatoreProfezia, int sceltaNonCasuale = 0)
        {
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

            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, GeneratoreProfeta.CreaProfezia(numero - 1))).Wait();


        }

        public static void ComandoRaccogli(string[] comanando, Message messaggio, TelegramBot bot)
        {
            if (comanando.Length == 1 && messaggio.From.FirstName != "Cosimo")
                return;

            if (comanando.Length == 1 && messaggio.From.FirstName == "Cosimo")
            {
                IftttManager.SendException("Hai fatto schiantare il bot");
            }

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

        public static void ComandoVai(string[] comanando, Message messaggio, TelegramBot bot)
        {
            if (comanando.Length <= 2)
                return;

            if (comanando[1] == "a")
                comanando[1] = comanando[2];

            switch (comanando[1])
            {
                case "fanculo":
                case "Fanculo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?")).Wait();
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te con tre tappi in culo (con amore <3) ")).Wait();
                    break;

                case "Dormire":
                case "dormire":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "idiota, non sono mica spacobot")).Wait();
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Io non dormo mai, al massimo riposo gli occhi")).Wait();
                    break;
            }
        }

        internal static void ComandoAnalizza(string[] comando, Message messaggio, TelegramBot bot, StatManager statManager)
        {

            if (comando.Length == 1)
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, devi inserire il nome di qualcuno da analizzare")).Wait();
                return;
            }

            if (comando.Length > 3)
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, hai inserito troppi termini nel comando")).Wait();
                return;
            }

            if (comando.Length == 2)
            {
                AnalizzaPerNome(statManager, messaggio, bot, comando);
            }

            if (comando.Length == 3)
            {
                AnalizzaPerUsername(statManager, messaggio, bot, comando);
            }
        }

        private static void SendReportUser(UserStat utente, TelegramBot bot, Message messaggio)
        {
            var messaggiTotali = utente.ContAudio + utente.ContText + utente.ContImg+ utente.ContSticker;
            var percentualeMessaggi = (float)utente.ContText / messaggiTotali;
            var percentualeAudio = (float)utente.ContAudio /messaggiTotali;
            var percentualeImmagini = (float)utente.ContImg / messaggiTotali;
            var percentualeSticker = (float)utente.ContSticker / messaggiTotali;
            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, $"Analisi utente \r \n \r \n" +
                                                                    $" Nome : {utente.Nome} \r \n" +
                                                                    $" Cognome : {utente.Cognome} \r \n" +
                                                                    $" Id : {utente.Id} \r \n" +
                                                                    $" Messaggi inviati : {utente.ContText}  ({percentualeMessaggi * 100}%) \r \n" +
                                                                    $" Foto inviate : {utente.ContImg}  ({percentualeImmagini * 100}%) \r \n" +
                                                                    $" Audio inviati: {utente.ContAudio }({ percentualeAudio * 100}%) \r \n"+
                                                                    $" Stickers inviati: {utente.ContSticker}({ percentualeSticker * 100}%) \r \n")).Wait();


        }

        private static void AnalizzaPerNome(StatManager statManager, Message messaggio, TelegramBot bot, string[] comando)
        {
            var listaUtenti = statManager.GetListaUser();
            UserStat utente;

            try
            {
                utente = listaUtenti.Single(x => x.Nome.Equals(comando[1]));
            }
            catch (Exception)
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, la ricerca di {comando[1]} ha risultato 0 o più di un risultato")).Wait();
                return;
            }

            SendReportUser(utente, bot, messaggio);

        }

        private static void AnalizzaPerUsername(StatManager statManager, Message messaggio, TelegramBot bot, string[] comando)
        {

            var listaUtenti = statManager.GetListaUser();
            UserStat utente;

            try
            {
                utente = listaUtenti.Single(x => x.Nome.Equals(comando[1]));
            }
            catch (Exception)
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, la ricerca di {comando[1]} ha risultato 0 o più di un risultato")).Wait();
                return;
            }

            SendReportUser(utente, bot, messaggio);

        }


        public static void ComandoLattana(string[] comanando, Message messaggio, TelegramBot bot)
        {

            if (comanando.Length <= 2)
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, messaggio.From.FirstName + " perchè nomini il mio nome invano?")).Wait();
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
                        bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Da sempre, lattana accoglie chiunque")).Wait();
                    }
                    else
                    {
                        bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Benvenuto " + comanando[2] + " in lattana, io so accogliere, ma so anche punire")).Wait();
                    }
                    return;
                case "Mostra":
                case "mostra":
                    if (comanando.Length < 3)
                    {
                        bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Molto interessante, però, hai visto la vastità del cazzo che me ne frega?")).Wait();
                    }
                    else
                    {
                        bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Ok " + comanando[2] + " ma almeno hai visto l'immensità del cazzo che me ne frega?")).Wait();
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

        public static void ComandoInsulta(string[] comanando, Message messaggio, bool offese, TelegramBot bot, int contatoreOffese)
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
            try
            {
                if (comanando[1] == "il" || comanando[1] == "la" || comanando[1] == "lo" || comanando[1] == "gli" || comanando[1] == "le")
                    comanando[1] = comanando[2];

            }
            catch (Exception)
            {
                IftttManager.SendException("Eccezione Gestre Comandi \n \r" + messaggio.From.Username);

                Console.WriteLine("Eccezione il lo la");
                Console.WriteLine("GestoreComandi riga 170");
                return;
            }

            switch (comanando[1])
            {
                case "cosimo":
                case "chello":
                case "kelinic":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Uno con il nome a cazzo tipo " + messaggio.From.FirstName + " farebbe meglio a stare zitto")).Wait();
                    return;
                case "giulio":
                case "guidotti":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Non mi sembra il caso di offendere giulio, è già messo male per conto suo")).Wait();
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "E poi lui abita dentro di me, non ho voglia di sentirlo soffrire")).Wait();
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Come se lui non soffrisse abbastanza")).Wait();
                    return;

                case "ruocco":
                case "rocchino":
                case "ruocchino":
                case "federico":
                case "tocchino":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Con grande piacere")).Wait();
                    break;

                case "lattana":
                case "lattanabot":
                case "lattanaBot":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Hahahaha " + messaggio.From.FirstName + " sei veramente un cretino")).Wait();
                    return;

            }


            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, GeneratoreOffesa.CreaOffesa(comanando[1], new Random().Next(0, contatoreOffese)))).Wait();
        }

        public static void ComandoInfo(Message messaggio, TelegramBot bot)
        {
            try
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id,
                         "Versione: " + Versione + " (GM) \r\n" +
                          "Sito nazista \r\n" +
                          "Proverbio \r\n" +
                          "Bruto/Belo \r\n" +
                          "Poherino? \r\n" +
                          "Paolo/Bitta \r\n" +
                          "Insulta [Qualcuno] \r\n" +
                          "Fai soffrire Giulio \r\n" +
                          "Sticker Nomrali/Porno \r\n" +
                          "Vai [fancuno / dormire] \r\n" +
                          "Raccogli/Raccatta [Qualcuno] \r\n" +
                          "Lattana Accogli/Vaffanculo/Mostra \r\n" +
                          "Statistiche e analisi utenti (NEW) \r\n" +
                          "Ricezione parole chiave tipo Orso/Bang \r\n"
                           )).Wait();
            }
            catch (Exception)
            {
                IftttManager.SendException("Un utente probabilmente ha bloccato il bot  \n \r" + messaggio.From.Username);
                Console.WriteLine("L'utente ha bloccato il bot ( gestoreComandi)");
            }
        }

        public static void ComandoStatistiche(Message messaggio, string[] comando, TelegramBot bot, StatManager statManager)
        {
            switch (comando[1])
            {
                case "audio":
                case "audi":
                case "vocali":
                    StatisticheAudio(statManager, bot, messaggio);
                    break;

                case "foto":
                case "immagini":
                case "photo":
                    StatisticheFoto(statManager, bot, messaggio);

                    break;

                case "messaggi":
                case "testo":
                case "testi":
                    StatisticheMessaggi(statManager, bot, messaggio);
                    break;


            }
        }

        private static void StatisticheAudio(StatManager statManager, TelegramBot bot, Message messaggio)
        {
            var arrangedAudio = statManager.GetListaUser().OrderByDescending(x => x.ContAudio).ToList();
            var statisticaTxt = "Ordine utenti per numero audio inviati \r \n  \r \n";
            var contatore = 1;

            foreach (var utente in arrangedAudio)
            {
                statisticaTxt = statisticaTxt + $"{contatore}) {utente.Nome} {utente.Cognome} | n° audio: {utente.ContAudio} \r \n";
                contatore++;
            }

            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, statisticaTxt)).Wait();

        }

        private static void StatisticheMessaggi(StatManager statManager, TelegramBot bot, Message messaggio)
        {
            var arrangedAudio = statManager.GetListaUser().OrderByDescending(x => x.ContText).ToList();
            var statisticaTxt = "Ordine utenti per numero messaggi inviati \r \n  \r \n";
            var contatore = 1;

            foreach (var utente in arrangedAudio)
            {
                statisticaTxt = statisticaTxt + $"{contatore})  {utente.Nome} {utente.Cognome} : {utente.ContText} \r \n";
                contatore++;
            }

            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, statisticaTxt)).Wait();

        }

        private static void StatisticheFoto(StatManager statManager, TelegramBot bot, Message messaggio)
        {
            var arrangedAudio = statManager.GetListaUser().OrderByDescending(x => x.ContImg).ToList();
            var statisticaTxt = "Ordine utenti per numero foto inviate \r \n  \r \n";
            var contatore = 1;

            foreach (var utente in arrangedAudio)
            {
                statisticaTxt = statisticaTxt + $"{contatore}: {utente.Nome} {utente.Cognome} | n° foto: {utente.ContImg} \r \n";
                contatore++;
            }

            bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, statisticaTxt)).Wait();

        }


    }

}
