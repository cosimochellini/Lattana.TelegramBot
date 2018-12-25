using System;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Generatore
{
    public static class GeneratoreAudio
    {
        private const string UrlBase = "http://nazista.altervista.org";

        public static void SwitchAudio(string[] comanando, Message messaggio, TelegramBotClient bot)
        {
            if (comanando.Length == 1)
            {
                bot.SendVoiceAsync(messaggio.Chat.Id, GeneraLinkAudio(new Random().Next(0, 116), 0, bot, messaggio));
            }
            else
            {
                try
                {
                    var numeroSelezionato = Convert.ToInt32(comanando[1]) + 1 - 1;
                    bot.SendVoiceAsync(messaggio.Chat.Id, GeneraLinkAudio(99, numeroSelezionato, bot, messaggio));
                }
                catch (Exception)
                {

                    bot.SendTextMessageAsync(messaggio.Chat.Id, "Mi dispiace ma hai inserito un numero non valido");
                }
            }
        }

        private static string GeneraLinkAudio(int casuale, int selezioneVolontaria, TelegramBotClient bot, Message messaggio)
        {
            if (bot == null) throw new ArgumentNullException(nameof(bot));
            var linkAudi = new string[115];//modificato a 115
            linkAudi[0] = $"{UrlBase}/audi/don%20matteo%2C%20donma%2C%20domma.mp3";
            linkAudi[1] = $"{UrlBase}/audi/12345.mp3";
            linkAudi[2] = $"{UrlBase}/audi/acciderbolina.mp3";
            linkAudi[3] = $"{UrlBase}/audi/ahahah.mp3";
            linkAudi[4] = $"{UrlBase}/audi/altro%20gruppo.mp3";
            linkAudi[5] = $"{UrlBase}/audi/applausi.mp3";
            linkAudi[6] = $"{UrlBase}/audi/bang.mp3";
            linkAudi[7] = $"{UrlBase}/audi/bella.mp3";
            linkAudi[8] = $"{UrlBase}/audi/brava%20brava.mp3";
            linkAudi[9] = $"{UrlBase}/audi/bruscolini.mp3";
            linkAudi[10] = $"{UrlBase}/audi/bruscolini2.mp3";
            linkAudi[11] = $"{UrlBase}/audi/buono%20brutto%20e%20cattivo.mp3";
            linkAudi[12] = $"{UrlBase}/audi/cazzo%20duro.mp3";
            linkAudi[13] = $"{UrlBase}/audi/ceci%20na%20pa%20pe%20une%20pipe.mp3";
            linkAudi[14] = $"{UrlBase}/audi/ceci%20nes%20pas%20une%20pip.mp3";
            linkAudi[15] = $"{UrlBase}/audi/ceci%20nes%20pas%20une%20pipe.mp3";
            linkAudi[16] = $"{UrlBase}/audi/cezzionale%2C%20cezzio.mp3";
            linkAudi[17] = $"{UrlBase}/audi/che%20cacchio%20dici.mp3";
            linkAudi[18] = $"{UrlBase}/audi/che%20cazzo%20dici.mp3";
            linkAudi[19] = $"{UrlBase}/audi/che%20cervellone.mp3";
            linkAudi[20] = $"{UrlBase}/audi/cioe%20ti.mp3";
            linkAudi[21] = $"{UrlBase}/audi/cosi%20si%20dice%20faccia%20di%20culo.mp3";
            linkAudi[22] = $"{UrlBase}/audi/culo%20pulito%2C%20culo%20lindo.mp3";
            linkAudi[23] = $"{UrlBase}/audi/cureggia.mp3";
            linkAudi[24] = $"{UrlBase}/audi/daun.mp3";
            linkAudi[25] = $"{UrlBase}/audi/daun2.mp3";
            linkAudi[26] = $"{UrlBase}/audi/dici%20solo%20stronzate.mp3";
            linkAudi[27] = $"{UrlBase}/audi/dieghino%20dai%20denti%20a%20sciabola.mp3";
            linkAudi[28] = $"{UrlBase}/audi/dove%20vai.mp3";
            linkAudi[29] = $"{UrlBase}/audi/e%20brutto.mp3";
            linkAudi[30] = $"{UrlBase}/audi/e%20questo%20brutto.mp3";
            linkAudi[31] = $"{UrlBase}/audi/e%20zecchi%20ce.mp3";
            linkAudi[32] = $"{UrlBase}/audi/eee.mp3";
            linkAudi[33] = $"{UrlBase}/audi/faccia%20di%20culo.mp3";
            linkAudi[34] = $"{UrlBase}/audi/fagli%20la%20mossa.mp3";
            linkAudi[35] = $"{UrlBase}/audi/fanno%20cagare%20quelle%20immagini.mp3";
            linkAudi[36] = $"{UrlBase}/audi/fenomeno.mp3";
            linkAudi[37] = $"{UrlBase}/audi/finalmente%2C%20alleluia.mp3";
            linkAudi[38] = $"{UrlBase}/audi/gay%2C%20omosessuale.mp3";
            linkAudi[39] = $"{UrlBase}/audi/giano%20non%20fare%20la%20merda.mp3";
            linkAudi[40] = $"{UrlBase}/audi/giochi%20di%20sabato.mp3";
            linkAudi[41] = $"{UrlBase}/audi/gnamo.mp3";
            linkAudi[42] = $"{UrlBase}/audi/grande.mp3";
            linkAudi[43] = $"{UrlBase}/audi/hihihi.mp3";
            linkAudi[44] = $"{UrlBase}/audi/la%20nazione.mp3";
            linkAudi[45] = $"{UrlBase}/audi/lalalala.mp3";
            linkAudi[46] = $"{UrlBase}/audi/landi%2C%20diego%2C%20dieghino%2C%20pieghino.mp3";
            linkAudi[47] = $"{UrlBase}/audi/lavati%20il%20culo.mp3";
            linkAudi[48] = $"{UrlBase}/audi/le%20fisse.mp3";
            linkAudi[49] = $"{UrlBase}/audi/lololo.mp3";
            linkAudi[50] = $"{UrlBase}/audi/ma%20certo.mp3";
            linkAudi[51] = $"{UrlBase}/audi/maiala%20professionista.mp3";
            linkAudi[52] = $"{UrlBase}/audi/maiala.mp3";
            linkAudi[53] = $"{UrlBase}/audi/maiala2.mp3";
            linkAudi[54] = $"{UrlBase}/audi/maiala3.mp3";
            linkAudi[55] = $"{UrlBase}/audi/maiala4.mp3";
            linkAudi[56] = $"{UrlBase}/audi/maiala5.mp3";
            linkAudi[57] = $"{UrlBase}/audi/maiala6.mp3";
            linkAudi[58] = $"{UrlBase}/audi/maiala7.mp3";
            linkAudi[59] = $"{UrlBase}/audi/male.mp3";
            linkAudi[60] = $"{UrlBase}/audi/maniviglioso.mp3";
            linkAudi[61] = $"{UrlBase}/audi/manuel.mp3";
            linkAudi[62] = $"{UrlBase}/audi/merda.mp3";
            linkAudi[63] = $"{UrlBase}/audi/merda2.mp3";
            linkAudi[64] = $"{UrlBase}/audi/mi%20cascano%20le%20braccia.mp3";
            linkAudi[65] = $"{UrlBase}/audi/mmma.mp3";
            linkAudi[66] = $"{UrlBase}/audi/mmma2.mp3";
            linkAudi[67] = $"{UrlBase}/audi/mmma3.mp3";
            linkAudi[68] = $"{UrlBase}/audi/mmma4.mp3";
            linkAudi[69] = $"{UrlBase}/audi/mmma5.mp3";
            linkAudi[70] = $"{UrlBase}/audi/muschio.mp3";
            linkAudi[71] = $"{UrlBase}/audi/MW3.mp3";
            linkAudi[72] = $"{UrlBase}/audi/no.mp3";
            linkAudi[73] = $"{UrlBase}/audi/non%20mi%20fare%20incazzare.mp3";
            linkAudi[74] = $"{UrlBase}/audi/non%20mi%20riesce%20mandare%20gli%20audi.mp3";
            linkAudi[75] = $"{UrlBase}/audi/nooo%20dieghino.mp3";
            linkAudi[76] = $"{UrlBase}/audi/pagare.mp3";
            linkAudi[77] = $"{UrlBase}/audi/pazzesco.mp3";
            linkAudi[78] = $"{UrlBase}/audi/piedi.mp3";
            linkAudi[79] = $"{UrlBase}/audi/piedi2.mp3";
            linkAudi[80] = $"{UrlBase}/audi/piedi3.mp3";
            linkAudi[81] = $"{UrlBase}/audi/piedi4.mp3";
            linkAudi[82] = $"{UrlBase}/audi/pippo.mp3";
            linkAudi[83] = $"{UrlBase}/audi/puttana%20maiala.mp3";
            linkAudi[84] = $"{UrlBase}/audi/quanto%20sono%20divertente.mp3";
            linkAudi[85] = $"{UrlBase}/audi/rispondi.mp3";
            linkAudi[86] = $"{UrlBase}/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3";
            linkAudi[87] = $"{UrlBase}/audi/sciabolata.mp3";
            linkAudi[88] = $"{UrlBase}/audi/scossa%2C%20va%20bene.mp3";
            linkAudi[89] = $"{UrlBase}/audi/shalala.mp3";
            linkAudi[90] = $"{UrlBase}/audi/si.mp3";
            linkAudi[91] = $"{UrlBase}/audi/siete%20degli%20scorretti.mp3";
            linkAudi[92] = $"{UrlBase}/audi/silviaaa.mp3";
            linkAudi[93] = $"{UrlBase}/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3";
            linkAudi[94] = $"{UrlBase}/audi/spezzino.mp3";
            linkAudi[95] = $"{UrlBase}/audi/studio.mp3";
            linkAudi[96] = $"{UrlBase}/audi/subito.mp3";
            linkAudi[97] = $"{UrlBase}/audi/succo%20alla%20pera.mp3";
            linkAudi[98] = $"{UrlBase}/audi/tegamello%20rispondi.mp3";
            linkAudi[99] = $"{UrlBase}/audi/ti%20ho%20sentito.mp3";
            linkAudi[100] = $"{UrlBase}/audi/ti%20odio.mp3";
            linkAudi[101] = $"{UrlBase}/audi/tng.mp3";
            linkAudi[102] = $"{UrlBase}/audi/top%20grende%20buio.mp3";
            linkAudi[103] = $"{UrlBase}/audi/troia.mp3";
            linkAudi[104] = $"{UrlBase}/audi/uuu.mp3";
            linkAudi[105] = $"{UrlBase}/audi/vecchio%20maiale.mp3";
            linkAudi[106] = $"{UrlBase}/audi/violento.mp3";
            linkAudi[107] = $"{UrlBase}/audi/vo%20a%20cacare.mp3";
            linkAudi[108] = $"{UrlBase}/audi/wela.mp3";
            linkAudi[109] = $"{UrlBase}/audi/wela2.mp3";
            linkAudi[110] = $"{UrlBase}/audi/wela3.mp3";
            linkAudi[111] = $"{UrlBase}/audi/wela4.mp3";
            linkAudi[112] = $"{UrlBase}/audi/yes.mp3";
            linkAudi[113] = $"{UrlBase}/audi/barum.mp3";
            linkAudi[114] = $"{UrlBase}/audi/essol%20pussy.mp3";

            if (selezioneVolontaria > 114)
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, "Mi dispiace ma hai inserito un numero non valido");
                return "";
            }

            return selezioneVolontaria == 0 ? linkAudi[casuale - 1] : linkAudi[selezioneVolontaria];
        }
    }
}


