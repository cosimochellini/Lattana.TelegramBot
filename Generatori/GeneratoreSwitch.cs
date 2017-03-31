using System;
using System.Linq;
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
        private static readonly int ContPerle = 24;
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


            if (ListaAudioImmensa(comanando, bot, messaggio))
                return;

            if (Switch(messaggio, comanando, bot, ContOffese, ContPaolo, ContPerle, offese, giano))    //controllo sulla prima parola
                return;


            if (comanando.Any(comando => Contiene(messaggio, comando, bot, ContSofferenza)))
            {
                return;
            }


            //fine audio miei con spazi
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

                case "yes":
                case "Yes":
                case "Yess":
                case "yess":
                case "Yesss":
                case "yesss":// METTERLO NON NELLE FRASI APPARTE PER IL SI
                case "paio":
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

                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                           new FileToSend(
                                               "http://nazista.altervista.org/Audio/no.ogg"))).Wait();
                    return true;


            }
            return false;
        }

        private bool Contiene(Message messaggio, string comanando, TelegramBot bot, int contatoreSofferenza)
        {
            switch (comanando)
            {

                case "bang":
                case "bangh":
                case "sparo":
                case "banghino":
                case "Banghino":
                case "Beng":
                case "beng":
                case "bengh":
                case "pum":
                case "Pum":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/Audio/bang.ogg"))).Wait();
                    return true;

                case "domma":
                case "Domma":
                case "donma":
                case "Donma":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                         "http://nazista.altervista.org/audi/don%20matteo%2C%20donma%2C%20domma.mp3"))).Wait();
                    return true;


                case "briuto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " beelo")).Wait();
                    return true;

                case "beelo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " briuto")).Wait();
                    return true;

                case "bëhlo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " Brühto")).Wait();
                    return true;

                case "bëlo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " Brüto")).Wait();
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

                case "brüto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, " bëlo")).Wait();
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
                    var bruscoliniRandom = new Random();

                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                    "http://nazista.altervista.org/audi/bruscolini"+ bruscoliniRandom.Next(1,2)+ ".mp3"))).Wait();
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
                case "barlum":
                case "arla":
                case "Ruocco":
                case "ruocco":
                case "Rocco":
                case "rocco":
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

                case "cezionale":
                case "cezio":
                case "eccezionale":
                case "incredibile":
                case "eccezio":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/cezzionale%2C%20cezzio.mp3"))).Wait();
                    return true;

                case "cervellone":
                case "inteligente":
                case "furbo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/che%20cervellone.mp3"))).Wait();
                    return true;

                case "cureggia":
                case "scureggiare":
                case "scorreggiare":
                case "puzza":
                case "puzzetta":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/cureggia.mp3"))).Wait();
                    return true;

                case "stronzate":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dici%20solo%20stronzate.mp3"))).Wait();
                    return true;

                case "dieghino":
                case "diego":
                case "pieghino":
                case "piegolo":
                case "piegolino":
                case "diegolino":
                case "landi":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dieghino%20dai%20denti%20a%20sciabola.mp3"))).Wait();
                    return true;

                case "eee":
                case "ee":
                case "eeee":
                case "eeeee":
                case "eeeeee":
                case "eeeeeee":
                case "eeeeeeee":
                case "eeeeeeeee":
                case "eeeeeeeeee":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/eee.mp3"))).Wait();
                    return true;

                case "brutto":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/e%20questo%20brutto.mp3"))).Wait();
                    return true;

                case "ettore":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/ettore%20ettore.mp3"))).Wait();
                    return true;

                case "mossa":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/fagli%20la%20mossa.mp3"))).Wait();
                    return true;

                case "fenomeni":
                case "fenomeno":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/fenomeno.mp3"))).Wait();
                    return true;

                case "finalmente":
                case "alleluia":
                case "alleluja":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/finalmente%2C%20alleluia.mp3"))).Wait();
                    return true;

                case "gay":
                case "frocio":
                case "omosessuale":
                case "ricchione":
                case "ricchio":
                case "effemminato":
                case "finocchio":
                case "checca":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/gay%2C%20omosessuale.mp3"))).Wait();
                    return true;

                case "gnamo":
                case "andiamo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/gnamo.mp3"))).Wait();
                    return true;

                case "grande":
                case "grandee":
                case "grandeee":
                case "grandeeee":
                case "grandeeeee":
                case "grandeeeeee":
                case "grandeeeeeee":
                case "grandeeeeeeee":
                case "grandeeeeeeeee":
                case "grandeeeeeeeeee":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/grande.mp3"))).Wait();
                    return true;

                case "hihihi":
                case "hihihihi":
                case "hihihihihi":
                case "hihihihihihi":
                case "hihihihihihihi":
                case "hihihihihihihihi":
                case "hihihihihihihihihi":
                case "hihihihihihihihihihi":
                case "hihihihihihihihihihihi":
                case "hihihihihihihihihihihihi":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/hihihi.mp3"))).Wait();
                    return true;

                case "lalala":
                case "aaa":
                case "aaaa":
                case "aaaaa":
                case "aaaaaa":
                case "aaaaaaa":
                case "aaaaaaaa":
                case "aaaaaaaaa":
                case "aaaaaaaaaa":
                case "aaaaaaaaaaa":
                case "lalalala":
                case "lalalalala":
                case "lalalalalala":
                case "lalalalalalala":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/lalalala.mp3"))).Wait();
                    return true;

                case "nazione":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/la%20nazione.mp3"))).Wait();
                    return true;

                case "fisse":
                case "fissato":
                case "fissazione":
                case "fissazioni":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/le%20fisse.mp3"))).Wait();
                    return true;

                case "lololo":
                case "lolololo":
                case "lololololo":
                case "lolololololo":
                case "lololololololo":
                case "lolololololololo":
                case "lololololololololo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/lololo.mp3"))).Wait();
                    return true;

                case "certo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/ma%20certo.mp3"))).Wait();
                    return true;

                case "male":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/male.mp3"))).Wait();
                    return true;

                case "mani":
                case "maniviglioso":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/maniviglioso.mp3"))).Wait();
                    return true;

                case "manuel":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/manuel.mp3"))).Wait();
                    return true;

                case "muschio":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/muschio.mp3"))).Wait();
                    return true;

                case "incazzare":
                case "inca":
                case "arrabbiare":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/non%20mi%20fare%20incazzare.mp3"))).Wait();
                    return true;

                case "cioè":
                case "cioé":
                case "cioe":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/cioe%20ti.mp3"))).Wait();
                    return true;

                case "pagare":
                case "soldi":
                case "sordi":
                case "pagami":
                case "pagamento":
                case "denaro":
                case "moneta":
                case "money":
                case "cash":
                case "pecunia":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/pagare.mp3"))).Wait();
                    return true;

                case "pazzesco":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/pazzesco.mp3"))).Wait();
                    return true;

                case "pippo":
                case "pippolino":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/pippo.mp3"))).Wait();
                    return true;

                case "puttana":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/puttana%20maiala.mp3"))).Wait();
                    return true;

                case "divertente":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/quanto%20sono%20divertente.mp3"))).Wait();
                    return true;

                case "rispondi":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/rispondi.mp3"))).Wait();
                    return true;

                case "storie":
                case "roito":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3"))).Wait();
                    return true;

                case "sciabolata":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/sciabolata.mp3"))).Wait();
                    return true;

                case "scossa":
                case "vabbene":
                case "vabene":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/scossa%2C%20va%20bene.mp3"))).Wait();
                    return true;

                case "shalala":
                case "shalalala":
                case "shalalalala":
                case "shalalalalala":
                case "rosemburg":
                case "rosemberg":
                case "rosemborg":
                case "rosenburg":
                case "rosenberg":
                case "rosenborg":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/shalala.mp3"))).Wait();
                    return true;

                case "scambi":
                case "asta":
                case "insieme":
                case "scorretti":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/siete%20degli%20scorretti.mp3"))).Wait();
                    return true;

                case "silvia":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/silviaaa.mp3"))).Wait();
                    return true;

                case "spezzarsela":
                case "spezzatela":
                case "piega":
                case "spezzartela":
                case "speziamo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3"))).Wait();
                    return true;

                case "spezzino":
                case "spezzam":
                case "spezza":
                case "play":
                case "playozzo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/spezzino.mp3"))).Wait();
                    return true;




                case "subito":
                case "aliscante":
                case "allistante":
                case "all'istante":
                case "immediatamente":
                case "ora":
                case "adesso":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/subito.mp3"))).Wait();
                    return true;

                case "succo":
                case "succhino":
                case "pera":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/succo%20alla%20pera.mp3"))).Wait();
                    return true;

                case "tegamello":
                case "tegame":
                case "incazzo":
                case "incazzarsi":
                case "incazzoso":
                case "incazzato":
                case "incazzati":
                case "incazzatevi":
                case "incazzi":
                case "incazza":
                case "incaziamo":
                case "incazzate":
                case "incazzano":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/tegamello%20rispondi.mp3"))).Wait();
                    return true;

                case "sentito":
                case "sentire":
                case "sento":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/ti%20ho%20sentito.mp3"))).Wait();
                    return true;

                case "odio":
                case "odiare":
                case "odi":
                case "odia":
                case "odiamo":
                case "odiate":
                case "odiano":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/ti%20odio.mp3"))).Wait();
                    return true;

                case "tng":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/tng.mp3"))).Wait();
                    return true;

                case "top":
                case "grende":
                case "grendee":
                case "grendeee":
                case "grendeeee":
                case "grendeeeee":
                case "grendeeeeee":
                case "greende":
                case "greeende":
                case "greeeende":
                case "greeeeende":
                case "greeeeeende":
                case "greeendeee":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/top%20grende%20buio.mp3"))).Wait();
                    return true;

                case "troia":
                case "troio":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/troia.mp3"))).Wait();
                    return true;

                case "uuu":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/uuu.mp3"))).Wait();
                    return true;

                case "maiale":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/vecchio%20maiale.mp3"))).Wait();
                    return true;

                case "violento":
                case "violenza":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/violento.mp3"))).Wait();
                    return true;

                case "cacare":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/vo%20a%20cacare.mp3"))).Wait();
                    return true;

                case "imbecille":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/imbecille.ogg"))).Wait();
                    return true;

                case "lego":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                    return true;

                case "essol":
                case "pussy":
                case "piussi":
                case "pussi":
                case "piussy":
                case "assol":
                case "fica":
                case "culo":
                case "piusi":
                case "piusy":
                case "piuuusiii":
                case "piuuuusiii":
                case "piuuuuusiiii":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/essol%20pussy.mp3"))).Wait();
                    return true;

                case "zecchi":
                case "zecconi":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/e%20zecchi%20ce.mp3"))).Wait();
                    return true;



                case "daun":
                case "dawn":
                case "down":
                case "doun":
                case "deun":

                    var rndm = new Random();

                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/daun" + rndm.Next(1, 2) + ".mp3"))).Wait();
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                   new FileToSend(
                                       "http://nazista.altervista.org/Audio/yes.ogg"))).Wait();
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

                    var random = new Random();
                    var casuale = random.Next(1, 8);
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                                          new FileToSend("http://nazista.altervista.org/audi/maiala" + casuale + ".mp3"))).Wait();

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
                case "biblio":
                case "bibblio":
                case "bandino":
                case "studiare":
                case "studdiare":
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

        private bool ListaAudioImmensa(string[] comando, TelegramBot bot, Message messaggio)
        {
            if (FraseContiene(comando, new[] { "non", "ci", "sono" }))
            {

                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                return true;
            }


            if (FraseContiene(comando, new[] { "sito", "nazista" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Questo è il sito dove potete vedere tutte le info sui nostri progetti https://goo.gl/e8Lpu7")).Wait();

                return true;

            }

            if (FraseContiene(comando, new[] { "buono", "brutto", "cattivo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/buono%20brutto%20e%20cattivo.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "sticker", "normali" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano1")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano2")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano3")).Wait();
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/VCCMNF")).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "sticker", "porno" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://t.me/addstickers/caccavellaamano4")).Wait();

                return true;
            }
            //inizio audi miei con spazi


            if (FraseContiene(comando, new[] { "don", "matteo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/don%20matteo%2C%20donma%2C%20domma.mp3"))).Wait();
                return true;

            }

            if (FraseContiene(comando, new[] { "cazzo", "duro" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/cazzo%20duro.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ceci", "na", "pa", "pe", "une", "pipe" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/ceci%20na%20pa%20pe%20une%20pipe.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ceci", "nes", "pas", "une", "pip" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/ceci%20nes%20pas%20une%20pip.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ceci", "nes", "pas", "une", "pipe" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/ceci%20nes%20pas%20une%20pipe.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cazzo", "ritto" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/cazzo%20duro.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "faccie", "culo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/cosi%20si%20dice%20faccia%20di%20culo.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "faccia", "culo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/faccia%20di%20culo.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "fare", "la", "merda" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/giano%20non%20fare%20la%20merda.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "giochi", "di", "sabato" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/giochi%20di%20sabato.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "era", "l'ora" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/finalmente%2C%20alleluia.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "mi", "riesce" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/non%20mi%20riesce%20mandare%20gli%20audi.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "come", "stai" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "va", "bene" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/scossa%2C%20va%20bene.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "la", "spezza" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cazzo", "dici" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/mi%20cascano%20le%20braccia.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cazzo", "dicendo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/mi%20cascano%20le%20braccia.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cascano", "braccia" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/mi%20cascano%20le%20braccia.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cascare", "braccia" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/mi%20cascano%20le%20braccia.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "dove", "vai" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "vai" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "dove", "andando" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "vado" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "vo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ci", "vado" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ci", "vo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cagare", "immagini" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "schifo", "immagini" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;

            }

            if (FraseContiene(comando, new[] { "merda", "immagini" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "vomitare", "immagini" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "sanno", "di", "niente" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "sanno", "di", "nulla" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id,
                                      new FileToSend(
                                          "http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }
            return false;
        }

    }
}