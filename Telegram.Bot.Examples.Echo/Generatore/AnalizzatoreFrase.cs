using System;
using Telegram.Bot.Examples.Echo.Esecutori;
using Telegram.Bot.Examples.Echo.Manager;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Generatore
{
    public static class AnalizzatoreFrase
    {
        private const string UrlBase = "http://nazista.altervista.org";

        public static bool Switch(Message messaggio, string[] comando, int contatoreOffese, int contatorePaolo, int contatoreProfezia)
        {
            const string preghiera = "Lattana nostra, che sei in via Lungo l'Affrico 4, sia santificato il tuo nome, venga  il tuo regno," +
                                     " sia fatta la tua volontà, come in gruppo Cecche così in gruppo Silvia.     Dacci oggi il nostro pano quotidiano," +
                                     " e rimetti a noi i nostri cocuzzi, come noi rimettiamo le offerte per lattana, e non ci indurre in sofferenza, ma liberaci dal Mani e la Silvia.   Amen.";

            switch (comando[0])
            {
                case "preghiera":
                case "amen":
                case "ammen":
                case "pregghiera":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, preghiera);
                    return true;

                case "insulta":
                case "offendi":
                case "percula":
                    GeneratoreOffesa.ComandoInsulta(comando, messaggio, contatoreOffese);
                    return true;
                case "mooseca":
                case "musica":
                case "maestro":
                case "labamba":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/Audio/mooseca.ogg");
                    return true;
                case "paolo":
                case "bitta":
                    GeneratorePaolo.ComandoBitta(messaggio, contatorePaolo);
                    return true;

                case "lattana":
                    EsecutoreLattana.ComandoLattana(comando, messaggio);
                    return true;
                case "analizza":
                case "ispeziona":
                    EsecutoreStatistiche.ComandoAnalizza(comando, messaggio);
                    return true;

                case "info":
                case "help":
                    EsecutoreInfo.ComandoInfo(messaggio);
                    return true;

                case "vai":
                    EsecutoreVai.ComandoVai(comando, messaggio);
                    return true;

                case "vastità":
                case "vastita":
                    EsecutoreCazzoFrega.CazzoCheMeNeFregaStiker(messaggio);
                    return true;

                case "raccogli":
                case "raccatta":
                    EsecutoreRaccogli.ComandoRaccogli(comando, messaggio);
                    return true;

                case "punnisci":
                case "punisci":
                    EsecutorePunisci.ComandoPunnisci(messaggio, comando);
                    return true;

                case "vaffanculo":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?");
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te, testa di merda (con amore <3) ");
                    return true;

                case "giulia":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "<3");
                    return true;

                case "ping":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "pong");
                    return true;

                case "pong":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "ping");
                    return true;

                case "profezia":
                case "profeta":
                case "proverbio":
                    GeneratoreProfeta.ComandoProfeta(messaggio, contatoreProfezia);
                    return true;

                case "mw3":
                case "barum":
                case "djruocco":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, "https://d3uepj124s5rcx.cloudfront.net/items/0C2p3y3A3y3E371Q2L39/Dj%20Ruocco.mp3");
                    return true;

                case "poherino":
                case "poherino?":
                case "poerino?":
                case "poerino":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Briuuuuuuuuutooooooooooooooooooooooo pooooheeeeeeeeriiiiiiiino no perché  siiiiiiii diiiice");
                    return true;

                case "audio":
                    GeneratoreAudio.SwitchAudio(comando, messaggio);
                    return true;

                case "yes":
                case "yess":
                case "yesss":
                case "paio":
                case "paioled":
                case "si":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/Audio/yes.ogg");
                    return true;

                case "no":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/Audio/no.ogg");
                    return true;

                case "statistica":
                case "statistiche":
                    EsecutoreStatistiche.ComandoStatistiche(messaggio, comando);
                    return true;
                case "statcarica":
                    StatManager.CaricaStistiche();
                    return true;
                case "statsalva":
                    if (Models.Bot.StatManager.SalvaStatistiche())
                        Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "salvataggio riuscito :D");
                    return true;
            }
            return false;
        }

        public static bool Contiene(Message messaggio, string comanando, int contatoreSofferenza, int contPano)
        {
            switch (comanando)
            {

                case "sciali":
                case "scialaha":
                case "scialata":
                case "sgrezzi":
                case "sgrezi":
                case "sciupi":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/Audio/la%20sciali.ogg");
                    return true;

                case "bang":
                case "bangh":
                case "sparo":
                case "banghino":
                case "beng":
                case "bengh":
                case "pum":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/Audio/bang.ogg");
                    return true;

                case "auguri":
                case "augurii":
                case "auguriii":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Auguriiiiii anche da parte miaa XDD");
                    return true;

                case "domma":
                case "donma":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/don%20matteo%2C%20donma%2C%20domma.mp3");
                    return true;

                case "briuto":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " beelo");
                    return true;

                case "beelo":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " briuto");
                    return true;

                case "bëhlo":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " Brühto");
                    return true;

                case "bëlo":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " Brüto");
                    return true;

                case "bruto":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " belo");
                    return true;

                case "belo":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "bruto");
                    return true;

                case "brühto":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " Bëhlo");
                    return true;

                case "brüto":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " bëlo");
                    return true;

                case "pano":
                case "pano?":
                case "panuozzo":
                case "panuozzo?":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, GeneratorePano.CreaPano(new Random().Next(0, contPano)));
                    return true;

                case "12345":
                case "123":
                case "1234":
                case "primo":
                case "uno":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/12345.mp3");
                    return true;

                case "sa":
                case "saa":
                case "saaa":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/sa.ogg");
                    return true;

                case "acciderbolina":
                case "accipicchia":
                case "cavolo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/acciderbolina.mp3");
                    return true;

                case "ahahahahah":
                case "hahaha":
                case "hahahaha":
                case "hahahahaha":
                case "ahah":
                case "ahahah":
                case "ahahahah":
                case "ahaha":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/ahahah.mp3");
                    return true;

                case "gruppo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/altro%20gruppo.mp3");
                    return true;

                case "bella":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/bella.mp3");
                    return true;

                case "brava":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/brava%20brava.mp3");
                    return true;

                case "bruscolini":
                case "bruce":
                case "brus":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/bruscolini" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "eccitato":
                case "godo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/cazzo%20duro.mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/barum.mp3");
                    return true;

                case "applausi":
                case "bravo":
                case "complimenti":
                case "congratulazioni":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/applausi.mp3");
                    return true;

                case "cezionale":
                case "cezio":
                case "eccezionale":
                case "incredibile":
                case "eccezio":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/cezzionale%2C%20cezzio.mp3");
                    return true;

                case "cervellone":
                case "inteligente":
                case "furbo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/che%20cervellone.mp3");
                    return true;

                case "cureggia":
                case "scureggiare":
                case "scorreggiare":
                case "puzza":
                case "puzzetta":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/cureggia.mp3");
                    return true;

                case "stronzate":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dici%20solo%20stronzate.mp3");
                    return true;

                case "dieghino":
                case "diego":
                case "pieghino":
                case "piegolo":
                case "piegolino":
                case "diegolino":
                case "landi":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dieghino{new Random().Next(1, 4)}.mp3");  //todo controllare se funziona
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/eee.mp3");
                    return true;

                case "brutto":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/brutto" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "ettore":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/ettore.mp3");
                    return true;

                case "mossa":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/fagli%20la%20mossa.mp3");
                    return true;

                case "fenomeni":
                case "fenomeno":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/fenomeno.mp3");
                    return true;

                case "finalmente":
                case "alleluia":
                case "alleluja":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/finalmente%2C%20alleluia.mp3");
                    return true;

                case "gay":
                case "frocio":
                case "omosessuale":
                case "ricchione":
                case "ricchio":
                case "effemminato":
                case "finocchio":
                case "checca":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/gay%2C%20omosessuale.mp3");
                    return true;

                case "gnamo":
                case "andiamo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/gnamo.mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/grande.mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/hihihi.mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/lalalala.mp3");
                    return true;

                case "nazione":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/la%20nazione.mp3");
                    return true;

                case "fisse":
                case "fissato":
                case "fissazione":
                case "fissazioni":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/le%20fisse.mp3");
                    return true;

                case "lololo":
                case "lolololo":
                case "lololololo":
                case "lolololololo":
                case "lololololololo":
                case "lolololololololo":
                case "lololololololololo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/lololo.mp3");
                    return true;

                case "certo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/ma%20certo.mp3");
                    return true;

                case "male":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/male.mp3");
                    return true;

                case "mani":
                case "maniviglioso":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/maniviglioso.mp3");
                    return true;

                case "manuel":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/manuel.mp3");
                    return true;

                case "muschio":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/muschio.mp3");
                    return true;

                case "incazzare":
                case "inca":
                case "arrabbiare":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/non%20mi%20fare%20incazzare.mp3");
                    return true;

                case "cioè":
                case "cioé":
                case "cioe":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/cioe%20ti.mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/pagare.mp3");
                    return true;

                case "pazzesco":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/pazzesco.mp3");
                    return true;

                case "pippo":
                case "pippolino":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/pippo.mp3");
                    return true;

                case "puttana":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/puttana%20maiala.mp3");
                    return true;

                case "divertente":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/quanto%20sono%20divertente.mp3");
                    return true;

                case "rispondi":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/rispondi.mp3");
                    return true;

                case "storie":
                case "roito":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3");
                    return true;

                case "sciabolata":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/sciabolata.mp3");
                    return true;

                case "scossa":
                case "vabbene":
                case "vabene":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/scossa%2C%20va%20bene.mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/shalala.mp3");
                    return true;

                case "scambi":
                case "asta":
                case "insieme":
                case "scorretti":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/siete%20degli%20scorretti.mp3");
                    return true;

                case "silvia":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/silviaaa.mp3");
                    return true;

                case "spezzarsela":
                case "spezzatela":
                case "piega":
                case "spezzartela":
                case "speziamo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3");
                    return true;

                case "spezzino":
                case "spezzam":
                case "spezza":
                case "play":
                case "playozzo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/spezzino.mp3");
                    return true;

                case "subito":
                case "aliscante":
                case "allistante":
                case "all'istante":
                case "immediatamente":
                case "ora":
                case "adesso":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/subito.mp3");
                    return true;

                case "succo":
                case "succhino":
                case "pera":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/succo%20alla%20pera.mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/tegamello%20rispondi.mp3");
                    return true;

                case "sentito":
                case "sentire":
                case "sento":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/ti%20ho%20sentito.mp3");
                    return true;

                case "odio":
                case "odiare":
                case "odi":
                case "odia":
                case "odiamo":
                case "odiate":
                case "odiano":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/ti%20odio.mp3");
                    return true;

                case "tng":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/tng.mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/top%20grende%20buio.mp3");
                    return true;

                case "troia":
                case "troio":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/troia.mp3");
                    return true;

                case "uuu":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/uuu.mp3");
                    return true;

                case "maiale":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/vecchio%20maiale.mp3");
                    return true;

                case "violento":
                case "violenza":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/violento.mp3");
                    return true;

                case "cacare":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/vo%20a%20cacare.mp3");
                    return true;

                case "imbecille":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/imbecille.ogg");
                    return true;

                case "lego":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dove%20vai.mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/essol%20pussy.mp3");
                    return true;

                case "zecchi":
                case "zecconi":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/e%20zecchi%20ce.mp3");
                    return true;

                case "daun":
                case "dawn":
                case "down":
                case "doun":
                case "deun":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/daun" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "lista":
                case "listone":
                case "listaccia":
                case "listuccia":
                case "listona":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/lista" + new Random().Next(1, 4) + ".mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/artuuu.ogg");
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

                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/mmma" + new Random().Next(1, 6) + ".mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/wela" + new Random().Next(1, 5) + ".mp3");
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
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/pulirsiculo" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "piedi":
                case "piede":
                case "piedini":
                case "piedine":
                case "piedino":
                case "feticista":
                case "feticismo":
                case "fetish":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/piedi" + new Random().Next(1, 5) + ".mp3");
                    return true;

                case "gesu":
                case "gesù":
                case "cristo":
                case "madonna":
                case "inchiodare":
                case "chiodi":
                case "inchiodalo":
                case "croce":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/inchiodaregesu.mp3");
                    return true;

                case "merda":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/merda" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "soffro":
                case "sofferenza":
                case "soffri":
                case "soffrono":
                case "soffre":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/soffro.ogg");
                    return true;

                case "tullosai":
                case "tullo":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/tullosai" + new Random().Next(1, 3) + ".ogg");

                    return true;
                //fine aggiunte mie

                case "yes":
                case "yess":
                case "yesss":
                case "paio":
                case "paioled":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/Audio/yes.ogg");
                    return true;

                case "balza":
                    GeneratoreSofferenza.Sofferenza(messaggio, Models.Bot.Istance, contatoreSofferenza);
                    return true;

                case "maiala":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/maiala" + new Random().Next(1, 10) + ".mp3");
                    return true;

                case "maialala":
                case "maialalala":
                    Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/maialala.ogg");
                    return true;

                case "balzo":
                case "bosco":
                case "salto":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                    return true;

                case "orso":
                case "bear":
                case "letargo":
                case "orsaggine":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Dai " + messaggio.From.FirstName + ", lascia stare Gabriele, è periodo di letargo per gli orsi bruni");
                    return true;

                case "studdio":
                case "studio":
                case "biblio":
                case "bibblio":
                case "bandino":
                case "studiare":
                case "studdiare":
                    Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Che dite, si imbuzza tempi bui tempi di studdio?");
                    return true;

                default:
                    return false;
            }
        }

        public static bool ListaAudioImmensa(string[] comando, Message messaggio, int contGiulio)
        {
            if (GeneratoreSwitch.FraseContiene(comando, new[] { "enrico", "papi" }, 1))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/Audio/mooseca.ogg");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "chi" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Sto cazzo");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cecche", "lex" }, 2))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Dura lex.");
                return true;
            }
            if (GeneratoreSwitch.FraseContiene(comando, new[] { "dura", "lex" }, 2))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Cecche lex.");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "dio", "città", "immensità" }, 2))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dioCitta.ogg");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "pooh", "puh", "pu", "poo" }, 1))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dioCitta.ogg");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "seghe", "porno", "ettore", "disperazione" }, 2))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/pornoettore.ogg");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "senza", "internet" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/senzainternet.ogg");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ennio", "morricone", "si", "vola", "130", "centotrenta", "autostrada" }, 2))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/siVola.ogg");
                return true;
            }


            if (GeneratoreSwitch.FraseContiene(comando, new[] { "fai", "soffrire", "giulio" }))
            {
                GeneratoreSofferenza4Giulio.CreaSofferenza(messaggio, Models.Bot.Istance, new Random().Next(0, contGiulio));
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "stasera", "non", "posso" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "stasera", "nonci" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "io", "non", "posso" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }
            if (GeneratoreSwitch.FraseContiene(comando, new[] { "stasera", "non", "posso" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "vengo" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }
            if (GeneratoreSwitch.FraseContiene(comando, new[] { "bruto", "bruhuto", "brutto", "briuto", "non" }, 2))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "le belo");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "ci", "sono" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "duro", "ritto" }, 2))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/cazzo%20duro.mp3");
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/cazzo%20duro.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "sito", "nazista" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Questo è il sito dove potete vedere tutte le info sui nostri progetti https://goo.gl/e8Lpu7");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "problema", "se", "stasera", "veniamo", "da", "te", "giulio", "non", "c'è" }, 8))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Volentieri, tanto lui sarà dalla silvia a fare il denutrito");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "buono", "brutto", "cattivo" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/buono%20brutto%20e%20cattivo.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "sticker", "normali" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id,
                    "1) https://goo.gl/AsLTH2 \r\n" +
                    "2) https://goo.gl/kV18vp \r\n" +
                    "3) https://goo.gl/APXoRo \r\n" +
                    "4) https://goo.gl/9q1qYy \r\n"
                    );
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "sticker", "porno" }))
            {
                Models.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "https://goo.gl/zR1jTT");
                return true;
            }



            if (GeneratoreSwitch.FraseContiene(comando, new[] { "don", "matteo" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/don%20matteo%2C%20donma%2C%20domma.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "duro" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/cazzo%20duro.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ceci", "na", "pa", "pe", "une", "pipe" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/ceci%20na%20pa%20pe%20une%20pipe.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ceci", "nes", "pas", "une", "pip" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/ceci%20nes%20pas%20une%20pip.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ceci", "nes", "pas", "une", "pipe" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/ceci%20nes%20pas%20une%20pipe.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "ritto" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/cazzo%20duro.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "faccie", "culo" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/cosi%20si%20dice%20faccia%20di%20culo.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "faccia", "culo" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/faccia%20di%20culo.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "fare", "la", "merda" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/giano%20non%20fare%20la%20merda.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "giochi", "di", "sabato" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/giochi%20di%20sabato.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "era", "l'ora" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/finalmente%2C%20alleluia.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "mi", "riesce" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/non%20mi%20riesce%20mandare%20gli%20audi.mp3");
                //Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, "http://nazista.altervista.org/ogg/non_mi_riesce_mandare_gli_audi.ogg", 0, true);
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "come", "stai" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "va", "bene" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/scossa%2C%20va%20bene.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "la", "spezza" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "dici" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/checazzodici" + new Random().Next(1, 4) + ".mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "tornato", "internet" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/internet{new Random().Next(1, 3)}.ogg");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cazzo", "dicendo" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/checazzodici" + new Random().Next(1, 4) + ".mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cascano", "braccia" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/checazzodici3.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "cascare", "braccia" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/checazzodici3.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "dove", "vai" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dove%20vai.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "vai" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dove%20vai.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "dove", "andando" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dove%20vai.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "vado" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dove%20vai.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "vo" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dove%20vai.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ci", "vado" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dove%20vai.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "ci", "vo" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/dove%20vai.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "schifo", "immagini" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "merda", "immagini" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "vomitare", "immagini" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "sanno", "di", "niente" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "non", "sanno", "di", "nulla" }))
            {
                Models.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }
            if (GeneratoreSwitch.FraseContiene(comando, new[] { "me", "il", "cazzo" }))
            {
                Models.Bot.Istance.SendVideoNoteAsync(messaggio.Chat.Id, $"{UrlBase}/VideoNote/meIlCazzo.mp4");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "camera", "caffè" }))
            {
                Models.Bot.Istance.SendVideoNoteAsync(messaggio.Chat.Id, $"{UrlBase}/VideoNote/sega.mp4");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "yo", "bitch", "biatch", "biach" }))
            {
                Models.Bot.Istance.SendVideoNoteAsync(messaggio.Chat.Id, $"{UrlBase}/VideoNote/yoBitch.mp4");
                return true;
            }

            if (GeneratoreSwitch.FraseContiene(comando, new[] { "weekend", "weekends" }, 1) || GeneratoreSwitch.FraseContiene(comando, new[] { "week", "end", "ends" }))
            {
                Models.Bot.Istance.SendVideoNoteAsync(messaggio.Chat.Id, $"{UrlBase}/VideoNote/weekEnd.mp4");
                return true;
            }

            return false;
        }

    }
}
