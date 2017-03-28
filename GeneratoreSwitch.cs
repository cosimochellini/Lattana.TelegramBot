using System;
using System.Linq;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace TelegramBotDemo
{
    internal class GeneratoreSwitch
    {
        private readonly GeneratoreSofferenza _managerSofferenza = new GeneratoreSofferenza();
        private readonly GeneratoreComandi _managerComandi = new GeneratoreComandi();
        private readonly GeneratoreAudio _managerAudio = new GeneratoreAudio();
        private readonly GeneratoreSofferenza4Giulio _managerSofferenza4Giulio = new GeneratoreSofferenza4Giulio();

        private static readonly int ContOffese = 17;
        private static readonly int ContPerle = 20;
        private static readonly int ContPaolo = 23;
        private static readonly int ContSofferenza = 10;
        private static readonly int ContGiulio = 10;

        public void SwitchFunzioni(Message messaggio, TelegramBot bot, bool offese, bool giano)
        {
            try
            {
                if (messaggio.Text == null)
                    return;
            }
            catch (Exception)
            {
                Console.WriteLine("Messaggio nullo acciderbolina");
                return;

            }


            var comanando = messaggio.Text.Split(Convert.ToChar(" ")).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            //controllo ,,


            if (Switch(messaggio, comanando, bot, ContOffese, ContPaolo, ContPerle, offese, giano))
                return;

            foreach (var comando in comanando)
            {
                if (Contiene(messaggio, comando, bot, ContSofferenza))
                    return;
            }

            if (comanando[0].Equals("Non") && comanando[1].Equals("ci") && comanando[2].Equals("sono"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();

                return;
            }

            if (comanando[0].Equals("Sito") && comanando[1].Equals("nazista"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Questo è il sito dove potete vedere tutte le info sui nostri progetti https://goo.gl/e8Lpu7")).Wait();

                return;
            }

            if (comanando[0].Equals("Sticker") && comanando[1].Equals("normali"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano1")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano2")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano3")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/VCCMNF")).Wait();

                return;
            }

            if (comanando[0].Equals("Sticker") && comanando[1].Equals("porno"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano4")).Wait();

                return;
            }


            if (comanando[0].Equals("Fai") && comanando[1].Equals("soffrire") && comanando[2].Equals("Giulio"))
            {
                var casuale = new Random();
                var next = casuale.Next(0, ContGiulio);

                _managerSofferenza4Giulio.creaSofferenza(messaggio, bot, next);
                return;
            }

            if (comanando[0].Equals("Stasera") && comanando[1].Equals("non") && comanando[2].Equals("posso"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();

                return;
            }

            if (comanando[0].Equals("Stasera") && comanando[1].Equals("nonci"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();

                return;
            }

            if (comanando[0].Equals("io") && comanando[1].Equals("non") && comanando[2].Equals("posso"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();

                return;
            }

            if (comanando[0].Equals("Stasera") && comanando[1].Equals("non") && comanando[2].Equals("ci") && comanando[3].Equals("sono"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();

                return;
            }


            if (comanando[0].Equals("Non") && comanando[1].Equals("vengo"))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                return;
            }

            if (comanando[0].Equals("Non") && comanando[1].Equals("mi") && comanando[2].Equals("fare") &&
                comanando[3].Equals("incazzare"))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                             new FileToSend(
                                 "https://d3uepj124s5rcx.cloudfront.net/items/2y051F3X27163c1x2k0w/acciderbolina.ogg"))).Wait();
            }

            if (comanando.Any(x => x.Contains("Briuto") || x.Contains("bruto") || x.Contains("Bruto")) && comanando.Any(x => x.Contains("non") || x.Contains("Non")))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "le belo")).Wait();
            }
        }

        private bool Switch(Message messaggio, string[] comanando, TelegramBot bot, int contatoreOffese, int contatorePaolo, int contatoreProfezia, bool offese, bool giano)
        {

            switch (comanando[0])    //Qui sotto una sola parola -------------------------------------------
            {
                case "insulta":
                case "Insulta":
                case "Offendi":
                case "offendi":
                case "percula":
                case "Percula":
                    _managerComandi.ComandoInsulta(comanando, messaggio, offese, bot, contatoreOffese);

                    return true;

               
                case "paolo":
                case "Paolo":
                case "Bitta":
                case "bitta":
                    _managerComandi.ComandoBitta(messaggio, bot, contatorePaolo);

                    return true;

                case "Lattana":
                case "lattana":
                    _managerComandi.ComandoLattana(comanando, messaggio, bot);
                    return true;

                case "info":
                case "Info":
                case "help":
                case "Help":
                case "/info":
                case "/Info":
                case "/help":
                case "/Help":
                    if (giano)
                    {
                                            _managerComandi.ComandoInfo(messaggio, bot);

                    }
                    else
                    {
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Mi dispiace ma il giano non capisce un cazzo")).Wait();

                    }
                    return true;


                case "Vai":
                case "vai":
                    _managerComandi.ComandoVai(comanando, messaggio, bot);
                    return true;

                case "orso":
                case "Orso":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Dai " + messaggio.From.FirstName + ", lascia stare Gabriele, è periodo di letargo per gli orsi bruni")).Wait();

                    return true;

                case "raccogli":
                case "Raccogli":
                case "raccatta":
                case "Raccatta":
                    _managerComandi.ComandoRaccogli(comanando, messaggio, bot);
                    return true;

                case "vaffanculo":
                case "Vaffanculo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?")).Wait();
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te, testa di merda (con amore <3) ")).Wait();
                    return true;

                case "profezia":
                case "Profezia":
                case "profeta":
                case "Profeta":
                case "proverbio":
                case "Proverbio":
                    _managerComandi.ComandoProfeta(messaggio, bot, contatoreProfezia);
                    return true;

                case "Briuto":
                case "briuto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " beelo")).Wait();
                    return true;

                case "beelo":
                case "Beelo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " bruto")).Wait();
                    return true;

                case "Bëhlo":
                case "bëhlo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " Brühto")).Wait();
                    return true;

                case "Bëlo":
                case "bëlo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " bëlo")).Wait();
                    return true;

                case "Bruto":
                case "bruto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " belo")).Wait();
                    return true;

                case "Belo":
                case "belo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "bruto")).Wait();
                    return true;

                case "Brühto":
                case "brühto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " Bëhlo")).Wait();
                    return true;

                case "Brüto":
                case "brüto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " bëlo")).Wait();
                    return true;

                case "Mw3":
                case "MW3":
                case "mW3":
                case "Djruocco":
                case "djruocco":

                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                        new FileToSend(
                            "https://d3uepj124s5rcx.cloudfront.net/items/0C2p3y3A3y3E371Q2L39/Dj%20Ruocco.mp3"))).Wait();
                    return true;


                case "Poherino":
                case "poherino":
                case "Poherino?":
                case "poherino?":
                case "Poerino?":
                case "poerino?":
                case "Poerino":
                case "poerino":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Briuuuuuuuuutooooooooooooooooooooooo pooooheeeeeeeeriiiiiiiino no perché  siiiiiiii diiiice")).Wait();
                    return true;

                case "Audio":
                case "audio":
                    _managerAudio.SwitchAudio(comanando, messaggio, bot);
                    return true;


                case "httpoog":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                            new FileToSend(
                  "http://nazista.altervista.org/Nuova%20cartella/acciderbolina.ogg"))).Wait();
                    return true;

            }
            return false;
        }

        private bool Contiene(Message messaggio, string comanando, TelegramBot bot, int contatoreSofferenza)
        {
            switch (comanando)
            {

                case "bang":
                case "Bang":
                case "banghino":
                case "Banghino":
                case "Beng":
                case "beng":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/Audio/bang.ogg"))).Wait();
                    return true;

                case "yes":
                case "Yes":
                case "Yess":
                case "yess":
                case "Yesss":
                case "yesss":
                case "paio":
                case "Paio":
                case "Paioled":
                case "paioled":
                case "SI":
                case "si":
                case "Si":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                   new FileToSend(
                                       "http://nazista.altervista.org/Audio/yes.ogg"))).Wait();
                    return true;

                case "No":
                case "no":
                case "NO":

                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                           new FileToSend(
                                               "http://nazista.altervista.org/Audio/no.ogg"))).Wait();
                    return true;

                case "Balza":
                case "balza":
                    _managerSofferenza.Sofferenza(messaggio, bot, contatoreSofferenza);
                    return true;

                case "maiala":
                case "Maiala":
                case "Maialala":
                case "maialala":
                case "Maialalala":
                case "maialalala":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                                          new FileToSend(
                                                              "https://cl.ly/jghN/maialala.ogg"))).Wait();
                    return true;

                case "balzo":
                case "Balzo":
                case "bosco":
                case "Bosco":
                case "Salto":
                case "salto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                    return true;

                case "orso":
                case "Orso":
                case "Bear":
                case "bear":
                case "letargo":
                case "Letargo":
                case "orsaggine":
                case "Orsaggine":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Dai " + messaggio.From.FirstName + ", lascia stare Gabriele, è periodo di letargo per gli orsi bruni")).Wait();
                    return true;


                case "studdio":
                case "Studdio":
                case "Studio":
                case "studio":
                    if (messaggio.From.FirstName == "Diego" || messaggio.From.FirstName.Equals("diego"))
                        bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Che dite, si imbuzza tempi bui tempi di studdio?")).Wait();
                    return true;

                default:
                    return false;

            }
        }

    }
}