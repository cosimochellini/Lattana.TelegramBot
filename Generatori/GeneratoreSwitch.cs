using System;
using System.Linq;
using System.Reflection.Emit;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace TelegramBotDemo.Generatori
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
            for (var i = 0; i < comanando.Length; i++)
            {
                comanando[i] = comanando[i].ToLower();
            }
            //controllo ,,




            if (Switch(messaggio, comanando, bot, ContOffese, ContPaolo, ContPerle, offese, giano))    //controllo sulla prima parola
                return;

            foreach (var comando in comanando)   //controllo su parola singola, ma su tutto il messaggio
            {
                if (Contiene(messaggio, comando, bot, ContSofferenza))
                    return;
            }



            if (FraseContiene(comanando, new[] { "non", "ci", "sono" }))
            {

                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                return;
            }


            if (FraseContiene(comanando, new[] { "sito", "nazista" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Questo è il sito dove potete vedere tutte le info sui nostri progetti https://goo.gl/e8Lpu7")).Wait();

                return;
            }

            if (FraseContiene(comanando, new[] { "sticker", "normali" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano1")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano2")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano3")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/VCCMNF")).Wait();
                return;
            }

            if (FraseContiene(comanando, new[] { "sticker", "porno" }))
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
                case "offendi":
                case "percula":
                    _managerComandi.ComandoInsulta(comanando, messaggio, offese, bot, contatoreOffese);

                    return true;


                case "paolo":
                case "bitta":
                    _managerComandi.ComandoBitta(messaggio, bot, contatorePaolo);

                    return true;

                case "lattana":
                    _managerComandi.ComandoLattana(comanando, messaggio, bot);
                    return true;

                case "info":
                case "help":
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


                case "vai":
                    _managerComandi.ComandoVai(comanando, messaggio, bot);
                    return true;

                case "raccogli":
                case "raccatta":
                    _managerComandi.ComandoRaccogli(comanando, messaggio, bot);
                    return true;

                case "vaffanculo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?")).Wait();
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te, testa di merda (con amore <3) ")).Wait();
                    return true;

                case "profezia":
                case "profeta":
                case "Profeta":
                case "proverbio":
                    _managerComandi.ComandoProfeta(messaggio, bot, contatoreProfezia);
                    return true;

                  //TUTTI ANCHE SE CONTENUTI IN FRASI
                case "briuto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " beelo")).Wait();
                    return true;

                case "beelo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " bruto")).Wait();
                    return true;

                case "bëhlo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " Brühto")).Wait();
                    return true;

                case "bëlo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " bëlo")).Wait();
                    return true;

                case "bruto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " belo")).Wait();
                    return true;

                case "belo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "bruto")).Wait();
                    return true;

                case "brühto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " Bëhlo")).Wait();
                    return true;

                case "Brüto":
                case "brüto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " bëlo")).Wait();
                    return true;

                case "MW3":
                case "mW3":
                case "djruocco":

                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                        new FileToSend(
                            "https://d3uepj124s5rcx.cloudfront.net/items/0C2p3y3A3y3E371Q2L39/Dj%20Ruocco.mp3"))).Wait();
                    return true;


                case "poherino":
                case "Poherino?":
                case "poherino?":
                case "poerino?":
                case "Poerino":
                case "poerino":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Briuuuuuuuuutooooooooooooooooooooooo pooooheeeeeeeeriiiiiiiino no perché  siiiiiiii diiiice")).Wait();
                    return true;

                case "audio":
                    _managerAudio.SwitchAudio(comanando, messaggio, bot);
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
                case "pum":
                case "Pum":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/Audio/bang.ogg"))).Wait();
                    return true;
                //inizio aggiunte mie da quel che ho capito dovrebbero fare anche se contenute
                case "don matteo":
                case "Don matteo":
                case "domma":
                case "Domma":
                case "donma":
                case "Donma":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                         "http://nazista.altervista.org/audi/don%20matteo%2C%20donma%2C%20domma.mp3"))).Wait();
                    return true;

                case "12345":
                case "123":
                case "primo":
                case "Primo":
                case "Uno":
                case "uno":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/12345.mp3"))).Wait();
                    return true;

                case "acciderbolina":
                case "Acciderbolina":
                case "accipicchia":
                case "Accipicchia":
                case "cavolo":
                case "Cavolo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/acciderbolina.mp3"))).Wait();
                    return true;

                case "ahahah":
                case "AHAHAH":
                case "AHAHAHAH":
                case "ahahahah":
                case "AHAHAHAHAH":
                case "ahahahahah":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/ahahah.mp3"))).Wait();
                    return true;

                case "gruppo":
                case "Gruppo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/altro%20gruppo.mp3"))).Wait();
                    return true;

                case "bella":
                case "Bella":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/bella.mp3"))).Wait();
                    return true;

                case "brava":
                case "Brava":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/brava%20brava.mp3"))).Wait();
                    return true;

                case "bruscolini":
                case "Bruscolini":
                case "bruce":
                case "Bruce":
                case "brus":
                case "Brus":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                    //"http://nazista.altervista.org/audi/bruscolini.mp3"; //deve mandare uno dei 2 casualmente
                    "http://nazista.altervista.org/audi/bruscolini2.mp3"))).Wait();
                    return true;

                case "buono brutto e cattivo":
                case "Buono brutto e cattivo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/buono%20brutto%20e%20cattivo.mp3"))).Wait();
                    return true;

                case "Cazzo duro":
                case "cazzo duro":
                case "eccitato":
                case "Eccitato":
                case "godo":
                case "Godo":
                case "cazzo ritto":
                case "Cazzo ritto":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/cazzo%20duro.mp3"))).Wait();
                    return true;

                case "barum":
                case "Barum":
                case "barlum":
                case "Barlum":
                case "arla":
                case "Arla":
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/barum.mp3"))).Wait();
                    return true;

                case "applausi":
                case "Applausi":
                case "bravo":
                case "Bravo":
                case "Complimenti":
                case "complimenti":
                case "congratulazioni":
                case "Congratulazioni":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/applausi.mp3"))).Wait();
                    return true;

                //fine aggiunte mie

                case "yes":
                case "Yes":
                case "Yess":
                case "yess":
                case "Yesss":
                case "yesss":// METTERLO NON NELLE FRASI APPARTE PER IL SI
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
                case "no"://METTERLO NOn NELLE FRASI
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
                                                          new FileToSend("https://cl.ly/jghN/maialala.ogg"))).Wait();

                    //"http://nazista.altervista.org/audi/maiala%20professionista.mp3";
                    //"http://nazista.altervista.org/audi/maiala.mp3";
                    //"http://nazista.altervista.org/audi/maiala2.mp3";
                    //"http://nazista.altervista.org/audi/maiala3.mp3";// solo alla parola maiala e Maiala inviare anche questi casualmente 
                    //"http://nazista.altervista.org/audi/maiala4.mp3";
                    //"http://nazista.altervista.org/audi/maiala5.mp3";
                    //"http://nazista.altervista.org/audi/maiala6.mp3";
                    //"http://nazista.altervista.org/audi/maiala7.mp3";
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

        private bool FraseContiene(string[] comando, string[] vettoreParole)
        {
            var contatore = 0;
            foreach (var parola in vettoreParole)
            {
                if (comando.Any(x => x.Equals(parola)))
                {
                    contatore++;
                }
                else
                {
                    return false;
                }
            }


            if (contatore == vettoreParole.Length)
            {
                return true;

            }
            else
            {

            }
            return false;
        }

    }
}