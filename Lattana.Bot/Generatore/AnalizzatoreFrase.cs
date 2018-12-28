using Lattana.Bot.Esecutori;
using Lattana.Bot.Istance;
using Lattana.Bot.Manager;
using Lattana.Bot.Models;
using System;
using Telegram.Bot.Types;

namespace Lattana.Bot.Generatore
{
    public static class AnalizzatoreFrase
    {
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
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, preghiera);
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/Audio/mooseca.ogg");
                    return true;
                case "paolo":
                case "bitta":
                    GeneratorePaolo.ComandoBitta(messaggio, contatorePaolo);
                    return true;

                case "lattana":
                    EsecutoreLattana.ComandoLattana(comando, messaggio);
                    return true;

                case "updatemodules":
                    ModulesManager.LoadModules();
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, $"moduli caricati correttamente : {ModulesManager.Modules.Count}");
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
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Abbiamo un simpaticone fra di noi, non è vero?");
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, messaggio.From.FirstName + " vacci te, testa di merda (con amore <3) ");
                    return true;

                case "giulia":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "<3");
                    return true;

                case "ping":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "pong");
                    return true;

                case "pong":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "ping");
                    return true;

                case "profezia":
                case "profeta":
                case "proverbio":
                    GeneratoreProfeta.ComandoProfeta(messaggio, contatoreProfezia);
                    return true;

                case "mw3":
                case "barum":
                case "djruocco":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, "https://d3uepj124s5rcx.cloudfront.net/items/0C2p3y3A3y3E371Q2L39/Dj%20Ruocco.mp3");
                    return true;

                case "poherino":
                case "poherino?":
                case "poerino?":
                case "poerino":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Briuuuuuuuuutooooooooooooooooooooooo pooooheeeeeeeeriiiiiiiino no perché  siiiiiiii diiiice");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/Audio/yes.ogg");
                    return true;

                case "no":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/Audio/no.ogg");
                    return true;

                case "statistica":
                case "statistiche":
                    EsecutoreStatistiche.ComandoStatistiche(messaggio, comando);
                    return true;
                case "statcarica":
                    StatManager.CaricaStistiche();
                    return true;
                case "statsalva":
                    if (StatManager.SalvaStatistiche())
                        Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "salvataggio riuscito :D");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/Audio/la%20sciali.ogg");
                    return true;

                case "bang":
                case "bangh":
                case "sparo":
                case "banghino":
                case "beng":
                case "bengh":
                case "pum":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/Audio/bang.ogg");
                    return true;

                case "auguri":
                case "augurii":
                case "auguriii":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Auguriiiiii anche da parte miaa XDD");
                    return true;

                case "domma":
                case "donma":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/don%20matteo%2C%20donma%2C%20domma.mp3");
                    return true;

                case "briuto":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " beelo");
                    return true;

                case "beelo":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " briuto");
                    return true;

                case "bëhlo":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " Brühto");
                    return true;

                case "bëlo":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " Brüto");
                    return true;

                case "bruto":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " belo");
                    return true;

                case "belo":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "bruto");
                    return true;

                case "brühto":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " Bëhlo");
                    return true;

                case "brüto":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, " bëlo");
                    return true;

                case "pano":
                case "pano?":
                case "panuozzo":
                case "panuozzo?":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, GeneratorePano.CreaPano(new Random().Next(0, contPano)));
                    return true;

                case "12345":
                case "123":
                case "1234":
                case "primo":
                case "uno":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/12345.mp3");
                    return true;

                case "sa":
                case "saa":
                case "saaa":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/sa.ogg");
                    return true;

                case "acciderbolina":
                case "accipicchia":
                case "cavolo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/acciderbolina.mp3");
                    return true;

                case "ahahahahah":
                case "hahaha":
                case "hahahaha":
                case "hahahahaha":
                case "ahah":
                case "ahahah":
                case "ahahahah":
                case "ahaha":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/ahahah.mp3");
                    return true;

                case "gruppo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/altro%20gruppo.mp3");
                    return true;

                case "bella":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/bella.mp3");
                    return true;

                case "brava":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/brava%20brava.mp3");
                    return true;

                case "bruscolini":
                case "bruce":
                case "brus":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/bruscolini" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "eccitato":
                case "godo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/cazzo%20duro.mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/barum.mp3");
                    return true;

                case "applausi":
                case "bravo":
                case "complimenti":
                case "congratulazioni":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/applausi.mp3");
                    return true;

                case "cezionale":
                case "cezio":
                case "eccezionale":
                case "incredibile":
                case "eccezio":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/cezzionale%2C%20cezzio.mp3");
                    return true;

                case "cervellone":
                case "inteligente":
                case "furbo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/che%20cervellone.mp3");
                    return true;

                case "cureggia":
                case "scureggiare":
                case "scorreggiare":
                case "puzza":
                case "puzzetta":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/cureggia.mp3");
                    return true;

                case "stronzate":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dici%20solo%20stronzate.mp3");
                    return true;

                case "dieghino":
                case "diego":
                case "pieghino":
                case "piegolo":
                case "piegolino":
                case "diegolino":
                case "landi":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dieghino{new Random().Next(1, 4)}.mp3");  //todo controllare se funziona
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/eee.mp3");
                    return true;

                case "brutto":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/brutto" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "ettore":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/ettore.mp3");
                    return true;

                case "mossa":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/fagli%20la%20mossa.mp3");
                    return true;

                case "fenomeni":
                case "fenomeno":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/fenomeno.mp3");
                    return true;

                case "finalmente":
                case "alleluia":
                case "alleluja":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/finalmente%2C%20alleluia.mp3");
                    return true;

                case "gay":
                case "frocio":
                case "omosessuale":
                case "ricchione":
                case "ricchio":
                case "effemminato":
                case "finocchio":
                case "checca":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/gay%2C%20omosessuale.mp3");
                    return true;

                case "gnamo":
                case "andiamo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/gnamo.mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/grande.mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/hihihi.mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/lalalala.mp3");
                    return true;

                case "nazione":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/la%20nazione.mp3");
                    return true;

                case "fisse":
                case "fissato":
                case "fissazione":
                case "fissazioni":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/le%20fisse.mp3");
                    return true;

                case "lololo":
                case "lolololo":
                case "lololololo":
                case "lolololololo":
                case "lololololololo":
                case "lolololololololo":
                case "lololololololololo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/lololo.mp3");
                    return true;

                case "certo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/ma%20certo.mp3");
                    return true;

                case "male":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/male.mp3");
                    return true;

                case "mani":
                case "maniviglioso":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/maniviglioso.mp3");
                    return true;

                case "manuel":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/manuel.mp3");
                    return true;

                case "muschio":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/muschio.mp3");
                    return true;

                case "incazzare":
                case "inca":
                case "arrabbiare":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/non%20mi%20fare%20incazzare.mp3");
                    return true;

                case "cioè":
                case "cioé":
                case "cioe":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/cioe%20ti.mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/pagare.mp3");
                    return true;

                case "pazzesco":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/pazzesco.mp3");
                    return true;

                case "pippo":
                case "pippolino":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/pippo.mp3");
                    return true;

                case "puttana":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/puttana%20maiala.mp3");
                    return true;

                case "divertente":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/quanto%20sono%20divertente.mp3");
                    return true;

                case "rispondi":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/rispondi.mp3");
                    return true;

                case "storie":
                case "roito":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3");
                    return true;

                case "sciabolata":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/sciabolata.mp3");
                    return true;

                case "scossa":
                case "vabbene":
                case "vabene":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/scossa%2C%20va%20bene.mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/shalala.mp3");
                    return true;

                case "scambi":
                case "asta":
                case "insieme":
                case "scorretti":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/siete%20degli%20scorretti.mp3");
                    return true;

                case "silvia":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/silviaaa.mp3");
                    return true;

                case "spezzarsela":
                case "spezzatela":
                case "piega":
                case "spezzartela":
                case "speziamo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3");
                    return true;

                case "spezzino":
                case "spezzam":
                case "spezza":
                case "play":
                case "playozzo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/spezzino.mp3");
                    return true;

                case "subito":
                case "aliscante":
                case "allistante":
                case "all'istante":
                case "immediatamente":
                case "ora":
                case "adesso":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/subito.mp3");
                    return true;

                case "succo":
                case "succhino":
                case "pera":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/succo%20alla%20pera.mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/tegamello%20rispondi.mp3");
                    return true;

                case "sentito":
                case "sentire":
                case "sento":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/ti%20ho%20sentito.mp3");
                    return true;

                case "odio":
                case "odiare":
                case "odi":
                case "odia":
                case "odiamo":
                case "odiate":
                case "odiano":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/ti%20odio.mp3");
                    return true;

                case "tng":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/tng.mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/top%20grende%20buio.mp3");
                    return true;

                case "troia":
                case "troio":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/troia.mp3");
                    return true;

                case "uuu":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/uuu.mp3");
                    return true;

                case "maiale":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/vecchio%20maiale.mp3");
                    return true;

                case "violento":
                case "violenza":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/violento.mp3");
                    return true;

                case "cacare":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/vo%20a%20cacare.mp3");
                    return true;

                case "imbecille":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/imbecille.ogg");
                    return true;

                case "lego":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dove%20vai.mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/essol%20pussy.mp3");
                    return true;

                case "zecchi":
                case "zecconi":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/e%20zecchi%20ce.mp3");
                    return true;

                case "daun":
                case "dawn":
                case "down":
                case "doun":
                case "deun":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/daun" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "lista":
                case "listone":
                case "listaccia":
                case "listuccia":
                case "listona":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/lista" + new Random().Next(1, 4) + ".mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/artuuu.ogg");
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

                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/mmma" + new Random().Next(1, 6) + ".mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/wela" + new Random().Next(1, 5) + ".mp3");
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
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/pulirsiculo" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "piedi":
                case "piede":
                case "piedini":
                case "piedine":
                case "piedino":
                case "feticista":
                case "feticismo":
                case "fetish":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/piedi" + new Random().Next(1, 5) + ".mp3");
                    return true;

                case "gesu":
                case "gesù":
                case "cristo":
                case "madonna":
                case "inchiodare":
                case "chiodi":
                case "inchiodalo":
                case "croce":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/inchiodaregesu.mp3");
                    return true;

                case "merda":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/merda" + new Random().Next(1, 3) + ".mp3");
                    return true;

                case "soffro":
                case "sofferenza":
                case "soffri":
                case "soffrono":
                case "soffre":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/soffro.ogg");
                    return true;

                case "tullosai":
                case "tullo":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/tullosai" + new Random().Next(1, 3) + ".ogg");

                    return true;
                //fine aggiunte mie

                case "yes":
                case "yess":
                case "yesss":
                case "paio":
                case "paioled":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/Audio/yes.ogg");
                    return true;

                case "balza":
                    GeneratoreSofferenza.Sofferenza(messaggio, Istance.Bot.Istance, contatoreSofferenza);
                    return true;

                case "maiala":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/maiala" + new Random().Next(1, 10) + ".mp3");
                    return true;

                case "maialala":
                case "maialalala":
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/maialala.ogg");
                    return true;

                case "balzo":
                case "bosco":
                case "salto":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                    return true;

                case "orso":
                case "bear":
                case "letargo":
                case "orsaggine":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Dai " + messaggio.From.FirstName + ", lascia stare Gabriele, è periodo di letargo per gli orsi bruni");
                    return true;

                case "studdio":
                case "studio":
                case "biblio":
                case "bibblio":
                case "bandino":
                case "studiare":
                case "studdiare":
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Che dite, si imbuzza tempi bui tempi di studdio?");
                    return true;

                default:
                    return false;
            }
        }

        public static bool ListaAudioImmensa(string[] comando, Message messaggio, int contGiulio)
        {
            if (StringOperator.Contains(comando, new[] { "enrico", "papi" }, 1))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/Audio/mooseca.ogg");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "chi" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Sto cazzo");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "cecche", "lex" }, 2))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Dura lex.");
                return true;
            }
            if (StringOperator.Contains(comando, new[] { "dura", "lex" }, 2))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Cecche lex.");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "dio", "città", "immensità" }, 2))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dioCitta.ogg");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "pooh", "puh", "pu", "poo" }, 1))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dioCitta.ogg");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "seghe", "porno", "ettore", "disperazione" }, 2))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/pornoettore.ogg");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "senza", "internet" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/senzainternet.ogg");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "ennio", "morricone", "si", "vola", "130", "centotrenta", "autostrada" }, 2))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/siVola.ogg");
                return true;
            }


            if (StringOperator.Contains(comando, new[] { "fai", "soffrire", "giulio" }))
            {
                GeneratoreSofferenza4Giulio.CreaSofferenza(messaggio, Istance.Bot.Istance, new Random().Next(0, contGiulio));
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "stasera", "non", "posso" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "stasera", "nonci" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "io", "non", "posso" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }
            if (StringOperator.Contains(comando, new[] { "stasera", "non", "posso" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "non", "vengo" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }
            if (StringOperator.Contains(comando, new[] { "bruto", "bruhuto", "brutto", "briuto", "non" }, 2))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "le belo");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "non", "ci", "sono" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Bravo " + messaggio.From.FirstName + " tradisci così Lattana nel momento del bisogno?");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "cazzo", "duro", "ritto" }, 2))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/cazzo%20duro.mp3");
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/cazzo%20duro.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "sito", "nazista" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Questo è il sito dove potete vedere tutte le info sui nostri progetti https://goo.gl/e8Lpu7");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "problema", "se", "stasera", "veniamo", "da", "te", "giulio", "non", "c'è" }, 8))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Volentieri, tanto lui sarà dalla silvia a fare il denutrito");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "buono", "brutto", "cattivo" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/buono%20brutto%20e%20cattivo.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "sticker", "normali" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id,
                    "1) https://goo.gl/AsLTH2 \r\n" +
                    "2) https://goo.gl/kV18vp \r\n" +
                    "3) https://goo.gl/APXoRo \r\n" +
                    "4) https://goo.gl/9q1qYy \r\n"
                    );
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "sticker", "porno" }))
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "https://goo.gl/zR1jTT");
                return true;
            }



            if (StringOperator.Contains(comando, new[] { "don", "matteo" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/don%20matteo%2C%20donma%2C%20domma.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "cazzo", "duro" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/cazzo%20duro.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "ceci", "na", "pa", "pe", "une", "pipe" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/ceci%20na%20pa%20pe%20une%20pipe.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "ceci", "nes", "pas", "une", "pip" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/ceci%20nes%20pas%20une%20pip.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "ceci", "nes", "pas", "une", "pipe" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/ceci%20nes%20pas%20une%20pipe.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "cazzo", "ritto" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/cazzo%20duro.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "faccie", "culo" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/cosi%20si%20dice%20faccia%20di%20culo.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "faccia", "culo" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/faccia%20di%20culo.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "non", "fare", "la", "merda" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/giano%20non%20fare%20la%20merda.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "giochi", "di", "sabato" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/giochi%20di%20sabato.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "era", "l'ora" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/finalmente%2C%20alleluia.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "non", "mi", "riesce" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/non%20mi%20riesce%20mandare%20gli%20audi.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "come", "stai" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "va", "bene" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/scossa%2C%20va%20bene.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "la", "spezza" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "cazzo", "dici" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/checazzodici" + new Random().Next(1, 4) + ".mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "tornato", "internet" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/internet{new Random().Next(1, 3)}.ogg");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "cazzo", "dicendo" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/checazzodici" + new Random().Next(1, 4) + ".mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "cascano", "braccia" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/checazzodici3.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "cascare", "braccia" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/checazzodici3.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "dove", "vai" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dove%20vai.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "non", "vai" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dove%20vai.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "dove", "andando" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dove%20vai.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "non", "vado" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dove%20vai.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "non", "vo" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dove%20vai.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "ci", "vado" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dove%20vai.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "ci", "vo" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/dove%20vai.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "schifo", "immagini" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "merda", "immagini" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "vomitare", "immagini" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "non", "sanno", "di", "niente" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "non", "sanno", "di", "nulla" }))
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/audi/fanno%20cagare%20quelle%20immagini.mp3");
                return true;
            }
            if (StringOperator.Contains(comando, new[] { "me", "il", "cazzo" }))
            {
                Istance.Bot.Istance.SendVideoNoteAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/VideoNote/meIlCazzo.mp4");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "camera", "caffè" }))
            {
                Istance.Bot.Istance.SendVideoNoteAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/VideoNote/sega.mp4");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "yo", "bitch", "biatch", "biach" }))
            {
                Istance.Bot.Istance.SendVideoNoteAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/VideoNote/yoBitch.mp4");
                return true;
            }

            if (StringOperator.Contains(comando, new[] { "weekend", "weekends" }, 1) || StringOperator.Contains(comando, new[] { "week", "end", "ends" }))
            {
                Istance.Bot.Istance.SendVideoNoteAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/VideoNote/weekEnd.mp4");
                return true;
            }

            return false;
        }

    }
}
