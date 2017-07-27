using System;
using Telegram.Bot.Examples.Echo.Esecutori;
using Telegram.Bot.Examples.Echo.Manager;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Generatore
{
    public static class AnalizzatoreFrase
    {
        private const string UrlBase = "http://nazista.altervista.org";

        public static bool Switch(Message messaggio, string[] comando, TelegramBotClient bot, int contatoreOffese, int contatorePaolo, int contatoreProfezia, StatManager statManager)
        {
            var preghiera =
                "Lattana nostra, che sei in via Lungo l'Affrico 4, sia santificato il tuo nome, venga  il tuo regno," +
                " sia fatta la tua volontà, come in gruppo Cecche così in gruppo Silvia.     Dacci oggi il nostro pano quotidiano," +
                " e rimetti a noi i nostri cocuzzi, come noi rimettiamo le offerte per lattana, e non ci indurre in sofferenza, ma liberaci dal Mani e la Silvia.   Amen.";

            switch (comando[0])
            {
                case "preghiera":
                case "amen":
                case "ammen":
                case "pregghiera":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, preghiera);
                    return true;

                case "insulta":
                case "offendi":
                case "percula":
                    GeneratoreOffesa.ComandoInsulta(comando, messaggio, bot, contatoreOffese);
                    return true;
                case "mooseca":
                case "musica":
                case "maestro":
                case "labamba":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/Audio/mooseca.ogg")));
                    return true;
                case "paolo":
                case "bitta":
                    GeneratorePaolo.ComandoBitta(messaggio, bot, contatorePaolo);
                    return true;

                case "lattana":
                    EsecutoreLattana.ComandoLattana(comando, messaggio, bot);
                    return true;
                case "analizza":
                case "ispeziona":
                    EsecutoreStatistiche.ComandoAnalizza(comando, messaggio, bot, statManager);
                    return true;

                case "info":
                case "help":
                    EsecutoreInfo.ComandoInfo(messaggio, bot);
                    return true;

                case "vai":
                    EsecutoreVai.ComandoVai(comando, messaggio, bot);
                    return true;

                case "vastità":
                case "vastita":
                    EsecutoreCazzoFrega.CazzoCheMeNeFregaStiker(messaggio, bot);
                    return true;

                case "raccogli":
                case "raccatta":
                    EsecutoreRaccogli.ComandoRaccogli(comando, messaggio, bot);
                    return true;

                case "punnisci":
                case "punisci":
                    EsecutorePunisci.ComandoPunnisci(messaggio, bot, comando, statManager);
                    return true;

                case "vaffanculo":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?");
                    bot.SendTextMessageAsync(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te, testa di merda (con amore <3) ");
                    return true;

                case "giulia":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "<3");
                    return true;

                case "ping":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "pong");
                    return true;

                case "pong":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "ping");
                    return true;

                case "profezia":
                case "profeta":
                case "proverbio":
                    GeneratoreProfeta.ComandoProfeta(messaggio, bot, contatoreProfezia);
                    return true;

                case "mw3":
                case "barum":
                case "djruocco":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri("https://d3uepj124s5rcx.cloudfront.net/items/0C2p3y3A3y3E371Q2L39/Dj%20Ruocco.mp3")));
                    return true;

                case "poherino":
                case "poherino?":
                case "poerino?":
                case "poerino":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "Briuuuuuuuuutooooooooooooooooooooooo pooooheeeeeeeeriiiiiiiino no perché  siiiiiiii diiiice");
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/Audio/yes.ogg")));
                    return true;

                case "no":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/Audio/no.ogg")));
                    return true;

                case "statistica":
                case "statistiche":
                    EsecutoreStatistiche.ComandoStatistiche(messaggio, comando, bot, statManager);
                    return true;
                case "statcarica":
                    StatManager.CaricaStistiche();
                    return true;
                case "statsalva":
                    if (statManager.SalvaStatistiche())
                        bot.SendTextMessageAsync(messaggio.Chat.Id, "salvataggio riuscito :D");
                    return true;
            }
            return false;
        }

        public static bool Contiene(Message messaggio, string comanando, TelegramBotClient bot, int contatoreSofferenza, int contPano)
        {
            switch (comanando)
            {

                case "sciali":
                case "scialaha":
                case "scialata":
                case "sgrezzi":
                case "sgrezi":
                case "sciupi":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/Audio/la%20sciali.ogg")));
                    return true;

                case "bang":
                case "bangh":
                case "sparo":
                case "banghino":
                case "beng":
                case "bengh":
                case "pum":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/Audio/bang.ogg")));
                    return true;

                case "auguri":
                case "augurii":
                case "auguriii":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "Auguriiiiii anche da parte miaa XDD");
                    return true;

                case "domma":
                case "donma":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/don%20matteo%2C%20donma%2C%20domma.mp3")));
                    return true;

                case "briuto":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, " beelo");
                    return true;

                case "beelo":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, " briuto");
                    return true;

                case "bëhlo":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, " Brühto");
                    return true;

                case "bëlo":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, " Brüto");
                    return true;

                case "bruto":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, " belo");
                    return true;

                case "belo":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "bruto");
                    return true;

                case "brühto":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, " Bëhlo");
                    return true;

                case "brüto":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, " bëlo");
                    return true;

                case "pano":
                case "pano?":
                case "panuozzo":
                case "panuozzo?":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, GeneratorePano.CreaPano(new Random().Next(0, contPano)));
                    return true;

                case "12345":
                case "123":
                case "1234":
                case "primo":
                case "uno":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/12345.mp3")));
                    return true;

                case "sa":
                case "saa":
                case "saaa":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/sa.ogg")));
                    return true;

                case "acciderbolina":
                case "accipicchia":
                case "cavolo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/acciderbolina.mp3")));
                    return true;

                case "ahahahahah":
                case "hahaha":
                case "hahahaha":
                case "hahahahaha":
                case "ahah":
                case "ahahah":
                case "ahahahah":
                case "ahaha":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/ahahah.mp3")));
                    return true;

                case "gruppo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/altro%20gruppo.mp3")));
                    return true;

                case "bella":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/bella.mp3")));
                    return true;

                case "brava":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/brava%20brava.mp3")));
                    return true;

                case "bruscolini":
                case "bruce":
                case "brus":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/bruscolini" + new Random().Next(1, 3) + ".mp3")));
                    return true;

                case "eccitato":
                case "godo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/cazzo%20duro.mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/barum.mp3")));
                    return true;

                case "applausi":
                case "bravo":
                case "complimenti":
                case "congratulazioni":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/applausi.mp3")));
                    return true;

                case "cezionale":
                case "cezio":
                case "eccezionale":
                case "incredibile":
                case "eccezio":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/cezzionale%2C%20cezzio.mp3")));
                    return true;

                case "cervellone":
                case "inteligente":
                case "furbo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/che%20cervellone.mp3")));
                    return true;

                case "cureggia":
                case "scureggiare":
                case "scorreggiare":
                case "puzza":
                case "puzzetta":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/cureggia.mp3")));
                    return true;

                case "stronzate":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dici%20solo%20stronzate.mp3")));
                    return true;

                case "dieghino":
                case "diego":
                case "pieghino":
                case "piegolo":
                case "piegolino":
                case "diegolino":
                case "landi":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dieghino{new Random().Next(1, 4)}.mp3")));  //todo controllare se funziona
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/eee.mp3")));
                    return true;

                case "brutto":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/brutto" + new Random().Next(1, 3) + ".mp3")));
                    return true;

                case "ettore":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/ettore.mp3")));
                    return true;

                case "mossa":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/fagli%20la%20mossa.mp3")));
                    return true;

                case "fenomeni":
                case "fenomeno":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/fenomeno.mp3")));
                    return true;

                case "finalmente":
                case "alleluia":
                case "alleluja":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/finalmente%2C%20alleluia.mp3")));
                    return true;

                case "gay":
                case "frocio":
                case "omosessuale":
                case "ricchione":
                case "ricchio":
                case "effemminato":
                case "finocchio":
                case "checca":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/gay%2C%20omosessuale.mp3")));
                    return true;

                case "gnamo":
                case "andiamo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/gnamo.mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/grande.mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/hihihi.mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/lalalala.mp3")));
                    return true;

                case "nazione":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/la%20nazione.mp3")));
                    return true;

                case "fisse":
                case "fissato":
                case "fissazione":
                case "fissazioni":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/le%20fisse.mp3")));
                    return true;

                case "lololo":
                case "lolololo":
                case "lololololo":
                case "lolololololo":
                case "lololololololo":
                case "lolololololololo":
                case "lololololololololo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/lololo.mp3")));
                    return true;

                case "certo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/ma%20certo.mp3")));
                    return true;

                case "male":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/male.mp3")));
                    return true;

                case "mani":
                case "maniviglioso":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/maniviglioso.mp3")));
                    return true;

                case "manuel":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/manuel.mp3")));
                    return true;

                case "muschio":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/muschio.mp3")));
                    return true;

                case "incazzare":
                case "inca":
                case "arrabbiare":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/non%20mi%20fare%20incazzare.mp3")));
                    return true;

                case "cioè":
                case "cioé":
                case "cioe":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/cioe%20ti.mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/pagare.mp3")));
                    return true;

                case "pazzesco":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/pazzesco.mp3")));
                    return true;

                case "pippo":
                case "pippolino":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/pippo.mp3")));
                    return true;

                case "puttana":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/puttana%20maiala.mp3")));
                    return true;

                case "divertente":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/quanto%20sono%20divertente.mp3")));
                    return true;

                case "rispondi":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/rispondi.mp3")));
                    return true;

                case "storie":
                case "roito":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3")));
                    return true;

                case "sciabolata":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/sciabolata.mp3")));
                    return true;

                case "scossa":
                case "vabbene":
                case "vabene":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/scossa%2C%20va%20bene.mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/shalala.mp3")));
                    return true;

                case "scambi":
                case "asta":
                case "insieme":
                case "scorretti":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/siete%20degli%20scorretti.mp3")));
                    return true;

                case "silvia":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/silviaaa.mp3")));
                    return true;

                case "spezzarsela":
                case "spezzatela":
                case "piega":
                case "spezzartela":
                case "speziamo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3")));
                    return true;

                case "spezzino":
                case "spezzam":
                case "spezza":
                case "play":
                case "playozzo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/spezzino.mp3")));
                    return true;

                case "subito":
                case "aliscante":
                case "allistante":
                case "all'istante":
                case "immediatamente":
                case "ora":
                case "adesso":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/subito.mp3")));
                    return true;

                case "succo":
                case "succhino":
                case "pera":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/succo%20alla%20pera.mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/tegamello%20rispondi.mp3")));
                    return true;

                case "sentito":
                case "sentire":
                case "sento":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/ti%20ho%20sentito.mp3")));
                    return true;

                case "odio":
                case "odiare":
                case "odi":
                case "odia":
                case "odiamo":
                case "odiate":
                case "odiano":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/ti%20odio.mp3")));
                    return true;

                case "tng":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/tng.mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/top%20grende%20buio.mp3")));
                    return true;

                case "troia":
                case "troio":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/troia.mp3")));
                    return true;

                case "uuu":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/uuu.mp3")));
                    return true;

                case "maiale":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/vecchio%20maiale.mp3")));
                    return true;

                case "violento":
                case "violenza":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/violento.mp3")));
                    return true;

                case "cacare":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/vo%20a%20cacare.mp3")));
                    return true;

                case "imbecille":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/imbecille.ogg")));
                    return true;

                case "lego":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dove%20vai.mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/essol%20pussy.mp3")));
                    return true;

                case "zecchi":
                case "zecconi":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/e%20zecchi%20ce.mp3")));
                    return true;

                case "daun":
                case "dawn":
                case "down":
                case "doun":
                case "deun":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/daun" + new Random().Next(1, 3) + ".mp3")));
                    return true;

                case "lista":
                case "listone":
                case "listaccia":
                case "listuccia":
                case "listona":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/lista" + new Random().Next(1, 4) + ".mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/artuuu.ogg")));
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

                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/mmma" + new Random().Next(1, 6) + ".mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/wela" + new Random().Next(1, 5) + ".mp3")));
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
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/pulirsiculo" + new Random().Next(1, 3) + ".mp3")));
                    return true;

                case "piedi":
                case "piede":
                case "piedini":
                case "piedine":
                case "piedino":
                case "feticista":
                case "feticismo":
                case "fetish":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/piedi" + new Random().Next(1, 5) + ".mp3")));
                    return true;

                case "gesu":
                case "gesù":
                case "cristo":
                case "madonna":
                case "inchiodare":
                case "chiodi":
                case "inchiodalo":
                case "croce":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/inchiodaregesu.mp3")));
                    return true;

                case "merda":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/merda" + new Random().Next(1, 3) + ".mp3")));
                    return true;

                case "soffro":
                case "sofferenza":
                case "soffri":
                case "soffrono":
                case "soffre":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/soffro.ogg")));
                    return true;

                case "tullosai":
                case "tullo":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/tullosai" + new Random().Next(1, 3) + ".ogg")));

                    return true;
                //fine aggiunte mie

                case "yes":
                case "yess":
                case "yesss":
                case "paio":
                case "paioled":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/Audio/yes.ogg")));
                    return true;

                case "balza":
                    GeneratoreSofferenza.Sofferenza(messaggio, bot, contatoreSofferenza);
                    return true;

                case "maiala":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/maiala" + new Random().Next(1, 10) + ".mp3")));
                    return true;

                case "maialala":
                case "maialalala":
                    bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/maialala.ogg")));
                    return true;

                case "balzo":
                case "bosco":
                case "salto":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                    return true;

                case "orso":
                case "bear":
                case "letargo":
                case "orsaggine":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "Dai " + messaggio.From.FirstName + ", lascia stare Gabriele, è periodo di letargo per gli orsi bruni");
                    return true;

                case "studdio":
                case "studio":
                case "biblio":
                case "bibblio":
                case "bandino":
                case "studiare":
                case "studdiare":
                    bot.SendTextMessageAsync(messaggio.Chat.Id, "Che dite, si imbuzza tempi bui tempi di studdio?");
                    return true;

                default:
                    return false;
            }
        }

        public static bool ListaAudioImmensa(string[] comando, TelegramBotClient bot, Message messaggio, int contGiulio)
        {
            if (GeneratoreSwitch.FraseContiene(comando, new[] { "enrico", "papi" }, 1))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/Audio/mooseca.ogg")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "seghe", "porno", "ettore", "disperazione" }, 2))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/pornoettore.ogg")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "senza", "internet" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/senzainternet.ogg")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "fai", "soffrire", "giulio" }))
            {
                GeneratoreSofferenza4Giulio.CreaSofferenza(messaggio, bot, new Random().Next(0, contGiulio));
                return true;
            }



            if (GeneratoreSwitch.FraseContiene(comando, new[] { "stasera", "non", "posso" }))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "stasera", "nonci" }))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "io", "non", "posso" }))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }
            if (GeneratoreSwitch.FraseContiene(comando, new[] { "stasera", "non", "posso" }))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "vengo" }))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }
            if (GeneratoreSwitch.FraseContiene(comando, new[] { "bruto", "bruhuto", "brutto", "briuto", "non" }, 2))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "le belo");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "ci", "sono" }))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "duro", "ritto" }, 2))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/cazzo%20duro.mp3")));
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/cazzo%20duro.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "sito", "nazista" }))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Questo è il sito dove potete vedere tutte le info sui nostri progetti https://goo.gl/e8Lpu7");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "problema", "se", "stasera", "veniamo", "da", "te", "giulio", "non", "c'è" }, 8))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Volentieri, tanto lui sarà dalla silvia a fare il denutrito");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "buono", "brutto", "cattivo" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/buono%20brutto%20e%20cattivo.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "sticker", "normali" }))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id,
                    "1) https://goo.gl/AsLTH2 \r\n" +
                    "2) https://goo.gl/kV18vp \r\n" +
                    "3) https://goo.gl/APXoRo \r\n" +
                    "4) https://goo.gl/9q1qYy \r\n"
                    );
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "sticker", "porno" }))
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "https://goo.gl/zR1jTT");
                return true;
            }



            if (GeneratoreSwitch.FraseContiene(comando, new[] { "don", "matteo" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/don%20matteo%2C%20donma%2C%20domma.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "duro" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/cazzo%20duro.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ceci", "na", "pa", "pe", "une", "pipe" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/ceci%20na%20pa%20pe%20une%20pipe.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ceci", "nes", "pas", "une", "pip" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/ceci%20nes%20pas%20une%20pip.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ceci", "nes", "pas", "une", "pipe" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/ceci%20nes%20pas%20une%20pipe.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "ritto" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/cazzo%20duro.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "faccie", "culo" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/cosi%20si%20dice%20faccia%20di%20culo.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "faccia", "culo" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/faccia%20di%20culo.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "fare", "la", "merda" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/giano%20non%20fare%20la%20merda.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "giochi", "di", "sabato" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/giochi%20di%20sabato.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "era", "l'ora" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/finalmente%2C%20alleluia.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "mi", "riesce" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/non%20mi%20riesce%20mandare%20gli%20audi.mp3")));
                //bot.SendVoiceAsync(messaggio.Chat.Id, "http://nazista.altervista.org/ogg/non_mi_riesce_mandare_gli_audi.ogg", 0, true);
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "come", "stai" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "va", "bene" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/scossa%2C%20va%20bene.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "la", "spezza" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "dici" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/checazzodici" + new Random().Next(1, 4) + ".mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "tornato", "internet" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/internet{new Random().Next(1, 3)}.ogg")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "dicendo" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/checazzodici" + new Random().Next(1, 4) + ".mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cascano", "braccia" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/checazzodici3.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cascare", "braccia" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/checazzodici3.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "dove", "vai" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dove%20vai.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "vai" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dove%20vai.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "dove", "andando" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dove%20vai.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "vado" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dove%20vai.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "vo" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dove%20vai.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ci", "vado" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dove%20vai.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ci", "vo" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/dove%20vai.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "schifo", "immagini" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "merda", "immagini" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "vomitare", "immagini" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "sanno", "di", "niente" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "sanno", "di", "nulla" }))
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3")));
                return true;
            }
            if (GeneratoreSwitch.FraseContiene(comando, new[] { "me", "il", "cazzo" }))
            {
                bot.SendVideoNoteAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/VideoNote/meIlCazzo.mp4")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "camera", "caffè"}))
            {
                bot.SendVideoNoteAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/VideoNote/sega.mp4")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "yo", "bitch", "biatch", "biach" }))
            {
                bot.SendVideoNoteAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/VideoNote/yoBitch.mp4")));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "weekend", "weekends" }, 1) || GeneratoreSwitch.FraseContiene(comando, new[] { "week", "end", "ends" }))
            {
                bot.SendVideoNoteAsync(messaggio.Chat.Id, new FileToSend(new Uri($"{UrlBase}/VideoNote/weekEnd.mp4")));
                return true;
            }

            return false;
        }

    }
}
