using System;
using System.Linq;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;
using TelegramBotDemo.Manager;

namespace TelegramBotDemo.Generatori
{
    public static class GeneratoreSwitch
    {
        private const int ContOffese = 18;
        private const int ContPerle = 25;
        private const int ContPaolo = 25;
        private const int ContSofferenza = 11;
        private const int ContGiulio = 9;
        private const int ContPano = 12;

        public static bool SwitchFunzioni(Message messaggio, TelegramBot bot, bool offese, StatManager statManager)
        {
            try
            {
                if (messaggio.Text == null)
                    return true;
            }
            catch (Exception)
            {
                IftttManager.SendException("Messaggio nullo dall'utente \n \r");
                Console.WriteLine("Messaggio nullo acciderbolina");
                return true;

            }


            var comando = messaggio.Text.Split(Convert.ToChar(" ")).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            for (var i = 0; i < comando.Length; i++)
            {
                comando[i] = comando[i].ToLower();
            }

            if (ListaAudioImmensa(comando, bot, messaggio))
                return true;

            if (Switch(messaggio, comando, bot, ContOffese, ContPaolo, ContPerle, offese, statManager))    //controllo sulla prima parola
                return true;


            if (comando.Any(x => Contiene(messaggio, x, bot, ContSofferenza)))
            {
                return true;
            }

            return false;


        }

        private static bool Switch(Message messaggio, string[] comando, TelegramBot bot, int contatoreOffese, int contatorePaolo, int contatoreProfezia, bool offese, StatManager statManager)
        {

            switch (comando[0])
            {
                case "insulta":
                case "offendi":
                case "percula":
                    GeneratoreComandi.ComandoInsulta(comando, messaggio, offese, bot, contatoreOffese);
                    return true;
                case "mooseca":
                case "musica":
                case "maestro":
                case "labamba":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/Audio/mooseca.ogg"))).Wait();
                    return true;
                case "paolo":
                case "bitta":
                    GeneratoreComandi.ComandoBitta(messaggio, bot, contatorePaolo);
                    return true;

                case "lattana":
                    GeneratoreComandi.ComandoLattana(comando, messaggio, bot);
                    return true;
                case "analizza":
                case "ispeziona":
                    GeneratoreComandi.ComandoAnalizza(comando, messaggio, bot, statManager);
                    return true;

                case "info":
                case "help":
                case "/info":
                case "/Info":
                case "/help":
                case "/Help":
                    GeneratoreComandi.ComandoInfo(messaggio, bot);
                    return true;

                case "vai":
                    GeneratoreComandi.ComandoVai(comando, messaggio, bot);
                    return true;

                case "raccogli":
                case "raccatta":
                    GeneratoreComandi.ComandoRaccogli(comando, messaggio, bot);
                    return true;

                case "vaffanculo":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?")).Wait();
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te, testa di merda (con amore <3) ")).Wait();
                    return true;

                case "profezia":
                case "profeta":
                case "proverbio":
                    GeneratoreComandi.ComandoProfeta(messaggio, bot, contatoreProfezia);
                    return true;

                case "mw3":
                case "barum":
                case "djruocco":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("https://d3uepj124s5rcx.cloudfront.net/items/0C2p3y3A3y3E371Q2L39/Dj%20Ruocco.mp3"))).Wait();
                    return true;


                case "poherino":
                case "poherino?":
                case "poerino?":
                case "poerino":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Briuuuuuuuuutooooooooooooooooooooooo pooooheeeeeeeeriiiiiiiino no perché  siiiiiiii diiiice")).Wait();
                    return true;

                case "audio":
                    GeneratoreAudio.SwitchAudio(comando, messaggio, bot);
                    return true;

                case "yes":
                case "yess":
                case "yesss":
                case "paio":
                case "paioled":
                case "si":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/Audio/yes.ogg"))).Wait();
                    return true;

                case "no":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/Audio/no.ogg"))).Wait();
                    return true;
                case "statistica":
                case "statistiche":
                    GeneratoreComandi.ComandoStatistiche(messaggio, comando, bot, statManager);
                    return true;

            }
            return false;
        }

        private static bool Contiene(Message messaggio, string comanando, TelegramBot bot, int contatoreSofferenza)
        {
            switch (comanando)
            {

                case "sciali":
                case "scialaha":
                case "scialata":
                case "sgrezzi":
                case "sgrezi":
                case "sciupi":

                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/Audio/la%20sciali.ogg"))).Wait();
                    return true;

                case "bang":
                case "bangh":
                case "sparo":
                case "banghino":
                case "beng":
                case "bengh":
                case "pum":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/Audio/bang.ogg"))).Wait();
                    return true;

                case "auguri":
                case "augurii":
                case "auguriii":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Auguriiiiii anche da parte miaa XDD")).Wait();
                    return true;

                case "domma":
                case "donma":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/don%20matteo%2C%20donma%2C%20domma.mp3"))).Wait();
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

                case "pano":
                case "pano?":
                case "panuozzo":
                case "panuozzo?":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, GeneratorePano.CreaPano(new Random().Next(0, ContPano)))).Wait();
                    return true;

                case "12345":
                case "123":
                case "1234":
                case "primo":
                case "uno":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/12345.mp3"))).Wait();
                    return true;

                case "sa":
                case "saa":
                case "saaa":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/sa.ogg"))).Wait();
                    return true;

                case "acciderbolina":
                case "accipicchia":
                case "cavolo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/acciderbolina.mp3"))).Wait();
                    return true;

                case "ahahahahah":
                case "hahaha":
                case "hahahaha":
                case "hahahahaha":
                case "ahah":
                case "ahahah":
                case "ahahahah":
                case "ahaha":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/ahahah.mp3"))).Wait();
                    return true;

                case "gruppo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/altro%20gruppo.mp3"))).Wait();
                    return true;

                case "bella":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/bella.mp3"))).Wait();
                    return true;

                case "brava":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/brava%20brava.mp3"))).Wait();
                    return true;

                case "bruscolini":
                case "bruce":
                case "brus":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/bruscolini" + new Random().Next(1, 3) + ".mp3"))).Wait();
                    return true;

                case "eccitato":
                case "godo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/cazzo%20duro.mp3"))).Wait();
                    return true;

                case "barum":
                case "barlum":
                case "arla":
                case "ruocco":
                case "rocco":
                case "rocchino":
                case "ruocchino":
                case "federico":
                case "tocchino":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/barum.mp3"))).Wait();
                    return true;

                case "applausi":
                case "bravo":
                case "complimenti":
                case "congratulazioni":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/applausi.mp3"))).Wait();
                    return true;

                case "cezionale":
                case "cezio":
                case "eccezionale":
                case "incredibile":
                case "eccezio":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/cezzionale%2C%20cezzio.mp3"))).Wait();
                    return true;

                case "cervellone":
                case "inteligente":
                case "furbo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/che%20cervellone.mp3"))).Wait();
                    return true;

                case "cureggia":
                case "scureggiare":
                case "scorreggiare":
                case "puzza":
                case "puzzetta":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/cureggia.mp3"))).Wait();
                    return true;

                case "stronzate":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dici%20solo%20stronzate.mp3"))).Wait();
                    return true;

                case "dieghino":
                case "diego":
                case "pieghino":
                case "piegolo":
                case "piegolino":
                case "diegolino":
                case "landi":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dieghino" + new Random().Next(1, 4) + ".mp3"))).Wait();
                    return true;

                case "ee":
                case "eee":
                case "eeee":
                case "eeeee":
                case "eeeeee":
                case "eeeeeee":
                case "eeeeeeee":
                case "eeeeeeeee":
                case "eeeeeeeeee":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/eee.mp3"))).Wait();
                    return true;

                case "brutto":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/brutto" + new Random().Next(1, 3) + ".mp3"))).Wait();
                    return true;

                case "ettore":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/ettore.mp3"))).Wait();
                    return true;

                case "mossa":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/fagli%20la%20mossa.mp3"))).Wait();
                    return true;

                case "fenomeni":
                case "fenomeno":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/fenomeno.mp3"))).Wait();
                    return true;

                case "finalmente":
                case "alleluia":
                case "alleluja":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/finalmente%2C%20alleluia.mp3"))).Wait();
                    return true;

                case "gay":
                case "frocio":
                case "omosessuale":
                case "ricchione":
                case "ricchio":
                case "effemminato":
                case "finocchio":
                case "checca":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/gay%2C%20omosessuale.mp3"))).Wait();
                    return true;

                case "gnamo":
                case "andiamo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/gnamo.mp3"))).Wait();
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/grande.mp3"))).Wait();
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/hihihi.mp3"))).Wait();
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/lalalala.mp3"))).Wait();
                    return true;

                case "nazione":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/la%20nazione.mp3"))).Wait();
                    return true;

                case "fisse":
                case "fissato":
                case "fissazione":
                case "fissazioni":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/le%20fisse.mp3"))).Wait();
                    return true;

                case "lololo":
                case "lolololo":
                case "lololololo":
                case "lolololololo":
                case "lololololololo":
                case "lolololololololo":
                case "lololololololololo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/lololo.mp3"))).Wait();
                    return true;

                case "certo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/ma%20certo.mp3"))).Wait();
                    return true;

                case "male":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/male.mp3"))).Wait();
                    return true;

                case "mani":
                case "maniviglioso":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/maniviglioso.mp3"))).Wait();
                    return true;

                case "manuel":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/manuel.mp3"))).Wait();
                    return true;

                case "muschio":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/muschio.mp3"))).Wait();
                    return true;

                case "incazzare":
                case "inca":
                case "arrabbiare":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/non%20mi%20fare%20incazzare.mp3"))).Wait();
                    return true;

                case "cioè":
                case "cioé":
                case "cioe":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/cioe%20ti.mp3"))).Wait();
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/pagare.mp3"))).Wait();
                    return true;

                case "pazzesco":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/pazzesco.mp3"))).Wait();
                    return true;

                case "pippo":
                case "pippolino":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/pippo.mp3"))).Wait();
                    return true;

                case "puttana":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/puttana%20maiala.mp3"))).Wait();
                    return true;

                case "divertente":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/quanto%20sono%20divertente.mp3"))).Wait();
                    return true;

                case "rispondi":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/rispondi.mp3"))).Wait();
                    return true;

                case "storie":
                case "roito":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3"))).Wait();
                    return true;

                case "sciabolata":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/sciabolata.mp3"))).Wait();
                    return true;

                case "scossa":
                case "vabbene":
                case "vabene":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/scossa%2C%20va%20bene.mp3"))).Wait();
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/shalala.mp3"))).Wait();
                    return true;

                case "scambi":
                case "asta":
                case "insieme":
                case "scorretti":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/siete%20degli%20scorretti.mp3"))).Wait();
                    return true;

                case "silvia":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/silviaaa.mp3"))).Wait();
                    return true;

                case "spezzarsela":
                case "spezzatela":
                case "piega":
                case "spezzartela":
                case "speziamo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3"))).Wait();
                    return true;

                case "spezzino":
                case "spezzam":
                case "spezza":
                case "play":
                case "playozzo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/spezzino.mp3"))).Wait();
                    return true;

                case "subito":
                case "aliscante":
                case "allistante":
                case "all'istante":
                case "immediatamente":
                case "ora":
                case "adesso":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/subito.mp3"))).Wait();
                    return true;

                case "succo":
                case "succhino":
                case "pera":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/succo%20alla%20pera.mp3"))).Wait();
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/tegamello%20rispondi.mp3"))).Wait();
                    return true;

                case "sentito":
                case "sentire":
                case "sento":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/ti%20ho%20sentito.mp3"))).Wait();
                    return true;

                case "odio":
                case "odiare":
                case "odi":
                case "odia":
                case "odiamo":
                case "odiate":
                case "odiano":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/ti%20odio.mp3"))).Wait();
                    return true;

                case "tng":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/tng.mp3"))).Wait();
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/top%20grende%20buio.mp3"))).Wait();
                    return true;

                case "troia":
                case "troio":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/troia.mp3"))).Wait();
                    return true;

                case "uuu":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/uuu.mp3"))).Wait();
                    return true;

                case "maiale":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/vecchio%20maiale.mp3"))).Wait();
                    return true;

                case "violento":
                case "violenza":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/violento.mp3"))).Wait();
                    return true;

                case "cacare":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/vo%20a%20cacare.mp3"))).Wait();
                    return true;

                case "imbecille":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/imbecille.ogg"))).Wait();
                    return true;

                case "lego":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
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
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/essol%20pussy.mp3"))).Wait();
                    return true;

                case "zecchi":
                case "zecconi":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/e%20zecchi%20ce.mp3"))).Wait();
                    return true;

                case "daun":
                case "dawn":
                case "down":
                case "doun":
                case "deun":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/daun" + new Random().Next(1, 3) + ".mp3"))).Wait();
                    return true;

                case "lista":
                case "listone":
                case "listaccia":
                case "listuccia":
                case "listona":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/lista" + new Random().Next(1, 4) + ".mp3"))).Wait();
                    return true;

                case "arturo":
                case "roma":
                case "romanelli":
                case "artu":
                case "artuu":
                case "artuuu":
                case "artuuuu":
                case "artuuuuu":
                case "artuuuuuu":
                case "artuuuuuuu":
                case "artuuuuuuuu":
                case "artuuuuuuuuu":
                case "artuuuuuuuuuu":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/artuuu.ogg"))).Wait();
                    return true;

                case "guidotti":
                case "stronzo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/guidottistronzo.mp3"))).Wait();
                    return true;

                case "mmma":
                case "mmmaaa":
                case "mmmmmmaaaaa":
                case "mmmmaaa":
                case "mmmmaaaa":
                case "mmmaa":
                case "mmmmmmmaaaaaa":
                case "mmmmmmmmmaaaaaaaa":
                case "mmmmmmmmmmmmmaaaaaaaaaaa":

                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/mmma" + new Random().Next(1, 6) + ".mp3"))).Wait();
                    return true;

                case "wela":
                case "weela":
                case "weelaa":
                case "welaa":
                case "weeelaaa":
                case "weeelaaaa":
                case "weeelaaaaa":
                case "welaaaa":
                case "weeelaaaaaa":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/wela" + new Random().Next(1, 5) + ".mp3"))).Wait();
                    return true;

                case "pulito":
                case "pulirsi":
                case "lavati":
                case "lavarsi":
                case "lindo":
                case "pulisciti":
                case "bide":
                case "bidet":
                case "lavato":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/pulirsiculo" + new Random().Next(1, 3) + ".mp3"))).Wait();
                    return true;

                case "piedi":
                case "piede":
                case "piedini":
                case "piedine":
                case "piedino":
                case "feticista":
                case "feticismo":
                case "fetish":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/piedi" + new Random().Next(1, 5) + ".mp3"))).Wait();
                    return true;

                case "gesu":
                case "gesù":
                case "cristo":
                case "madonna":
                case "inchiodare":
                case "chiodi":
                case "inchiodalo":
                case "croce":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/inchiodaregesu.mp3"))).Wait();
                    return true;

                case "merda":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/merda" + new Random().Next(1, 3) + ".mp3"))).Wait();
                    return true;

                case "soffro":
                case "sofferenza":
                case "soffri":
                case "soffrono":
                case "soffre":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/soffro.ogg"))).Wait();
                    return true;

                case "tullosai":
                case "tullo":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/tullosai.ogg"))).Wait();
                    return true;
                //fine aggiunte mie

                case "yes":
                case "yess":
                case "yesss":
                case "paio":
                case "paioled":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/Audio/yes.ogg"))).Wait();
                    return true;

                case "balza":
                    GeneratoreSofferenza.Sofferenza(messaggio, bot, contatoreSofferenza);
                    return true;

                case "maiala":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/maiala" + new Random().Next(1, 10) + ".mp3"))).Wait();
                    return true;

                case "maialala":
                case "maialalala":
                    bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/maialala.ogg"))).Wait();
                    return true;

                case "balzo":
                case "bosco":
                case "salto":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                    return true;

                case "orso":
                case "bear": 
                case "letargo":
                case "orsaggine":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Dai " + messaggio.From.FirstName + ", lascia stare Gabriele, è periodo di letargo per gli orsi bruni")).Wait();
                    return true;

                case "studdio":
                case "studio":
                case "biblio":
                case "bibblio":
                case "bandino":
                case "studiare":
                case "studdiare":
                    bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Che dite, si imbuzza tempi bui tempi di studdio?")).Wait();
                    return true;

                default:
                    return false;
            }
        }

        private static bool FraseContiene(string[] comando, string[] vettoreParole, int numeroCondizioni = 0)
        {

            if (numeroCondizioni == 0)
                numeroCondizioni = vettoreParole.Length;

            var contatore = 0;
            foreach (var parola in vettoreParole)
            {
                if (comando.Any(x => x.Equals(parola))) contatore++;
            }

            return contatore >= numeroCondizioni;
        }

        private static bool ListaAudioImmensa(string[] comando, TelegramBot bot, Message messaggio)
        {
            if (FraseContiene(comando, new[] { "enrico", "papi" }, 1))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/Audio/mooseca.ogg"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "fai", "soffrire", "giulio" }))
            {
                GeneratoreSofferenza4Giulio.CreaSofferenza(messaggio, bot, new Random().Next(0, ContGiulio));
                return true;
            }

            if (FraseContiene(comando, new[] { "stasera", "non", "posso" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "stasera", "nonci" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "io", "non", "posso" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                return true;
            }
            if (FraseContiene(comando, new[] { "stasera", "non", "posso" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "vengo" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                return true;
            }
            if (FraseContiene(comando, new[] { "bruto", "bruhuto", "brutto", "briuto", "non" }, 2))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "le belo")).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "ci", "sono" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?")).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cazzo", "duro", "ritto" }, 2))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/cazzo%20duro.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "sito", "nazista" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Questo è il sito dove potete vedere tutte le info sui nostri progetti https://goo.gl/e8Lpu7")).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "sito", "nazista" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Questo è il sito dove potete vedere tutte le info sui nostri progetti https://goo.gl/e8Lpu7")).Wait();
                return true;
            }


            if (FraseContiene(comando, new[] { "problema", "se", "stasera", "veniamo", "da", "te", "giulio", "non", "c'è" }, 8))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "Volentieri, tanto lui sarà dalla silvia a fare il denutrito")).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "buono", "brutto", "cattivo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/buono%20brutto%20e%20cattivo.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "sticker", "normali" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id,
                    "1) https://goo.gl/AsLTH2 \r\n" +
                    "2) https://goo.gl/kV18vp \r\n" +
                    "3) https://goo.gl/APXoRo \r\n" +
                    "4) https://goo.gl/9q1qYy \r\n"
                    )).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "sticker", "porno" }))
            {
                bot.MakeRequestAsync(new SendMessage(messaggio.Chat.Id, "https://goo.gl/zR1jTT")).Wait();
                return true;
            }



            if (FraseContiene(comando, new[] { "don", "matteo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/don%20matteo%2C%20donma%2C%20domma.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cazzo", "duro" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/cazzo%20duro.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ceci", "na", "pa", "pe", "une", "pipe" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/ceci%20na%20pa%20pe%20une%20pipe.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ceci", "nes", "pas", "une", "pip" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/ceci%20nes%20pas%20une%20pip.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ceci", "nes", "pas", "une", "pipe" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/ceci%20nes%20pas%20une%20pipe.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cazzo", "ritto" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/cazzo%20duro.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "faccie", "culo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/cosi%20si%20dice%20faccia%20di%20culo.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "faccia", "culo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/faccia%20di%20culo.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "fare", "la", "merda" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/giano%20non%20fare%20la%20merda.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "giochi", "di", "sabato" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/giochi%20di%20sabato.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "era", "l'ora" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/finalmente%2C%20alleluia.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "mi", "riesce" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/non%20mi%20riesce%20mandare%20gli%20audi.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "come", "stai" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "va", "bene" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/scossa%2C%20va%20bene.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "la", "spezza" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cazzo", "dici" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/checazzodici" + new Random().Next(1, 4) + ".mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cazzo", "dicendo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/checazzodici" + new Random().Next(1, 4) + ".mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cascano", "braccia" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/checazzodici3.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cascare", "braccia" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/checazzodici3.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "dove", "vai" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "vai" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "dove", "andando" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "vado" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "vo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ci", "vado" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "ci", "vo" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/dove%20vai.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "cagare", "immagini" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "schifo", "immagini" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "merda", "immagini" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "vomitare", "immagini" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "sanno", "di", "niente" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }

            if (FraseContiene(comando, new[] { "non", "sanno", "di", "nulla" }))
            {
                bot.MakeRequestAsync(new SendAudio(messaggio.Chat.Id, new FileToSend("http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3"))).Wait();
                return true;
            }
            return false;
        }

    }
}