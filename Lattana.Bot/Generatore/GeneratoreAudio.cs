using Lattana.Bot.Models;
using System;
using Telegram.Bot.Types;

namespace Lattana.Bot.Generatore
{
    public static class GeneratoreAudio
    {

        public static void SwitchAudio(string[] comando, Message messaggio)
        {
            if (comando.Length == 1)
            {
                Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, GeneraLinkAudio(new Random().Next(0, 116), 0, messaggio));
            }
            else
            {
                try
                {
                    var numeroSelezionato = Convert.ToInt32(comando[1]) + 1 - 1;
                    Istance.Bot.Istance.SendVoiceAsync(messaggio.Chat.Id, GeneraLinkAudio(99, numeroSelezionato, messaggio));
                }
                catch (Exception)
                {

                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Mi dispiace ma hai inserito un numero non valido");
                }
            }
        }

        private static string GeneraLinkAudio(int casuale, int selezioneVolontaria, Message messaggio)
        {
            var linkAudi = new string[115];//modificato a 115
            linkAudi[0] = $"{Constant.BaseUrl}/audi/don%20matteo%2C%20donma%2C%20domma.mp3";
            linkAudi[1] = $"{Constant.BaseUrl}/audi/12345.mp3";
            linkAudi[2] = $"{Constant.BaseUrl}/audi/acciderbolina.mp3";
            linkAudi[3] = $"{Constant.BaseUrl}/audi/ahahah.mp3";
            linkAudi[4] = $"{Constant.BaseUrl}/audi/altro%20gruppo.mp3";
            linkAudi[5] = $"{Constant.BaseUrl}/audi/applausi.mp3";
            linkAudi[6] = $"{Constant.BaseUrl}/audi/bang.mp3";
            linkAudi[7] = $"{Constant.BaseUrl}/audi/bella.mp3";
            linkAudi[8] = $"{Constant.BaseUrl}/audi/brava%20brava.mp3";
            linkAudi[9] = $"{Constant.BaseUrl}/audi/bruscolini.mp3";
            linkAudi[10] = $"{Constant.BaseUrl}/audi/bruscolini2.mp3";
            linkAudi[11] = $"{Constant.BaseUrl}/audi/buono%20brutto%20e%20cattivo.mp3";
            linkAudi[12] = $"{Constant.BaseUrl}/audi/cazzo%20duro.mp3";
            linkAudi[13] = $"{Constant.BaseUrl}/audi/ceci%20na%20pa%20pe%20une%20pipe.mp3";
            linkAudi[14] = $"{Constant.BaseUrl}/audi/ceci%20nes%20pas%20une%20pip.mp3";
            linkAudi[15] = $"{Constant.BaseUrl}/audi/ceci%20nes%20pas%20une%20pipe.mp3";
            linkAudi[16] = $"{Constant.BaseUrl}/audi/cezzionale%2C%20cezzio.mp3";
            linkAudi[17] = $"{Constant.BaseUrl}/audi/che%20cacchio%20dici.mp3";
            linkAudi[18] = $"{Constant.BaseUrl}/audi/che%20cazzo%20dici.mp3";
            linkAudi[19] = $"{Constant.BaseUrl}/audi/che%20cervellone.mp3";
            linkAudi[20] = $"{Constant.BaseUrl}/audi/cioe%20ti.mp3";
            linkAudi[21] = $"{Constant.BaseUrl}/audi/cosi%20si%20dice%20faccia%20di%20culo.mp3";
            linkAudi[22] = $"{Constant.BaseUrl}/audi/culo%20pulito%2C%20culo%20lindo.mp3";
            linkAudi[23] = $"{Constant.BaseUrl}/audi/cureggia.mp3";
            linkAudi[24] = $"{Constant.BaseUrl}/audi/daun.mp3";
            linkAudi[25] = $"{Constant.BaseUrl}/audi/daun2.mp3";
            linkAudi[26] = $"{Constant.BaseUrl}/audi/dici%20solo%20stronzate.mp3";
            linkAudi[27] = $"{Constant.BaseUrl}/audi/dieghino%20dai%20denti%20a%20sciabola.mp3";
            linkAudi[28] = $"{Constant.BaseUrl}/audi/dove%20vai.mp3";
            linkAudi[29] = $"{Constant.BaseUrl}/audi/e%20brutto.mp3";
            linkAudi[30] = $"{Constant.BaseUrl}/audi/e%20questo%20brutto.mp3";
            linkAudi[31] = $"{Constant.BaseUrl}/audi/e%20zecchi%20ce.mp3";
            linkAudi[32] = $"{Constant.BaseUrl}/audi/eee.mp3";
            linkAudi[33] = $"{Constant.BaseUrl}/audi/faccia%20di%20culo.mp3";
            linkAudi[34] = $"{Constant.BaseUrl}/audi/fagli%20la%20mossa.mp3";
            linkAudi[35] = $"{Constant.BaseUrl}/audi/fanno%20cagare%20quelle%20immagini.mp3";
            linkAudi[36] = $"{Constant.BaseUrl}/audi/fenomeno.mp3";
            linkAudi[37] = $"{Constant.BaseUrl}/audi/finalmente%2C%20alleluia.mp3";
            linkAudi[38] = $"{Constant.BaseUrl}/audi/gay%2C%20omosessuale.mp3";
            linkAudi[39] = $"{Constant.BaseUrl}/audi/giano%20non%20fare%20la%20merda.mp3";
            linkAudi[40] = $"{Constant.BaseUrl}/audi/giochi%20di%20sabato.mp3";
            linkAudi[41] = $"{Constant.BaseUrl}/audi/gnamo.mp3";
            linkAudi[42] = $"{Constant.BaseUrl}/audi/grande.mp3";
            linkAudi[43] = $"{Constant.BaseUrl}/audi/hihihi.mp3";
            linkAudi[44] = $"{Constant.BaseUrl}/audi/la%20nazione.mp3";
            linkAudi[45] = $"{Constant.BaseUrl}/audi/lalalala.mp3";
            linkAudi[46] = $"{Constant.BaseUrl}/audi/landi%2C%20diego%2C%20dieghino%2C%20pieghino.mp3";
            linkAudi[47] = $"{Constant.BaseUrl}/audi/lavati%20il%20culo.mp3";
            linkAudi[48] = $"{Constant.BaseUrl}/audi/le%20fisse.mp3";
            linkAudi[49] = $"{Constant.BaseUrl}/audi/lololo.mp3";
            linkAudi[50] = $"{Constant.BaseUrl}/audi/ma%20certo.mp3";
            linkAudi[51] = $"{Constant.BaseUrl}/audi/maiala%20professionista.mp3";
            linkAudi[52] = $"{Constant.BaseUrl}/audi/maiala.mp3";
            linkAudi[53] = $"{Constant.BaseUrl}/audi/maiala2.mp3";
            linkAudi[54] = $"{Constant.BaseUrl}/audi/maiala3.mp3";
            linkAudi[55] = $"{Constant.BaseUrl}/audi/maiala4.mp3";
            linkAudi[56] = $"{Constant.BaseUrl}/audi/maiala5.mp3";
            linkAudi[57] = $"{Constant.BaseUrl}/audi/maiala6.mp3";
            linkAudi[58] = $"{Constant.BaseUrl}/audi/maiala7.mp3";
            linkAudi[59] = $"{Constant.BaseUrl}/audi/male.mp3";
            linkAudi[60] = $"{Constant.BaseUrl}/audi/maniviglioso.mp3";
            linkAudi[61] = $"{Constant.BaseUrl}/audi/manuel.mp3";
            linkAudi[62] = $"{Constant.BaseUrl}/audi/merda.mp3";
            linkAudi[63] = $"{Constant.BaseUrl}/audi/merda2.mp3";
            linkAudi[64] = $"{Constant.BaseUrl}/audi/mi%20cascano%20le%20braccia.mp3";
            linkAudi[65] = $"{Constant.BaseUrl}/audi/mmma.mp3";
            linkAudi[66] = $"{Constant.BaseUrl}/audi/mmma2.mp3";
            linkAudi[67] = $"{Constant.BaseUrl}/audi/mmma3.mp3";
            linkAudi[68] = $"{Constant.BaseUrl}/audi/mmma4.mp3";
            linkAudi[69] = $"{Constant.BaseUrl}/audi/mmma5.mp3";
            linkAudi[70] = $"{Constant.BaseUrl}/audi/muschio.mp3";
            linkAudi[71] = $"{Constant.BaseUrl}/audi/MW3.mp3";
            linkAudi[72] = $"{Constant.BaseUrl}/audi/no.mp3";
            linkAudi[73] = $"{Constant.BaseUrl}/audi/non%20mi%20fare%20incazzare.mp3";
            linkAudi[74] = $"{Constant.BaseUrl}/audi/non%20mi%20riesce%20mandare%20gli%20audi.mp3";
            linkAudi[75] = $"{Constant.BaseUrl}/audi/nooo%20dieghino.mp3";
            linkAudi[76] = $"{Constant.BaseUrl}/audi/pagare.mp3";
            linkAudi[77] = $"{Constant.BaseUrl}/audi/pazzesco.mp3";
            linkAudi[78] = $"{Constant.BaseUrl}/audi/piedi.mp3";
            linkAudi[79] = $"{Constant.BaseUrl}/audi/piedi2.mp3";
            linkAudi[80] = $"{Constant.BaseUrl}/audi/piedi3.mp3";
            linkAudi[81] = $"{Constant.BaseUrl}/audi/piedi4.mp3";
            linkAudi[82] = $"{Constant.BaseUrl}/audi/pippo.mp3";
            linkAudi[83] = $"{Constant.BaseUrl}/audi/puttana%20maiala.mp3";
            linkAudi[84] = $"{Constant.BaseUrl}/audi/quanto%20sono%20divertente.mp3";
            linkAudi[85] = $"{Constant.BaseUrl}/audi/rispondi.mp3";
            linkAudi[86] = $"{Constant.BaseUrl}/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3";
            linkAudi[87] = $"{Constant.BaseUrl}/audi/sciabolata.mp3";
            linkAudi[88] = $"{Constant.BaseUrl}/audi/scossa%2C%20va%20bene.mp3";
            linkAudi[89] = $"{Constant.BaseUrl}/audi/shalala.mp3";
            linkAudi[90] = $"{Constant.BaseUrl}/audi/si.mp3";
            linkAudi[91] = $"{Constant.BaseUrl}/audi/siete%20degli%20scorretti.mp3";
            linkAudi[92] = $"{Constant.BaseUrl}/audi/silviaaa.mp3";
            linkAudi[93] = $"{Constant.BaseUrl}/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3";
            linkAudi[94] = $"{Constant.BaseUrl}/audi/spezzino.mp3";
            linkAudi[95] = $"{Constant.BaseUrl}/audi/studio.mp3";
            linkAudi[96] = $"{Constant.BaseUrl}/audi/subito.mp3";
            linkAudi[97] = $"{Constant.BaseUrl}/audi/succo%20alla%20pera.mp3";
            linkAudi[98] = $"{Constant.BaseUrl}/audi/tegamello%20rispondi.mp3";
            linkAudi[99] = $"{Constant.BaseUrl}/audi/ti%20ho%20sentito.mp3";
            linkAudi[100] = $"{Constant.BaseUrl}/audi/ti%20odio.mp3";
            linkAudi[101] = $"{Constant.BaseUrl}/audi/tng.mp3";
            linkAudi[102] = $"{Constant.BaseUrl}/audi/top%20grende%20buio.mp3";
            linkAudi[103] = $"{Constant.BaseUrl}/audi/troia.mp3";
            linkAudi[104] = $"{Constant.BaseUrl}/audi/uuu.mp3";
            linkAudi[105] = $"{Constant.BaseUrl}/audi/vecchio%20maiale.mp3";
            linkAudi[106] = $"{Constant.BaseUrl}/audi/violento.mp3";
            linkAudi[107] = $"{Constant.BaseUrl}/audi/vo%20a%20cacare.mp3";
            linkAudi[108] = $"{Constant.BaseUrl}/audi/wela.mp3";
            linkAudi[109] = $"{Constant.BaseUrl}/audi/wela2.mp3";
            linkAudi[110] = $"{Constant.BaseUrl}/audi/wela3.mp3";
            linkAudi[111] = $"{Constant.BaseUrl}/audi/wela4.mp3";
            linkAudi[112] = $"{Constant.BaseUrl}/audi/yes.mp3";
            linkAudi[113] = $"{Constant.BaseUrl}/audi/barum.mp3";
            linkAudi[114] = $"{Constant.BaseUrl}/audi/essol%20pussy.mp3";

            if (selezioneVolontaria <= 114)
                return selezioneVolontaria == 0 ? linkAudi[casuale - 1] : linkAudi[selezioneVolontaria];


            Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Mi dispiace ma hai inserito un numero non valido");
            return "";
        }
    }
}


