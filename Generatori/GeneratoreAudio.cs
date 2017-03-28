using System;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi.Types;

namespace TelegramBotDemo.Generatori
{
    internal class GeneratoreAudio
    {
        public void SwitchAudio(string[] comanando, Message messaggio, TelegramBot bot)
        {
            if (comanando.Length == 1)
            {
                var casuale = new Random();
                var numero = casuale.Next(0, 114);//modificato a 114
                var audio = GeneraLinkAudio(numero);
                var file = new FileToSend(audio);
                bot.MakeRequestAsync(new SendVoice(messaggio.Chat.Id, file
                 )).Wait();
                return;
            }

            switch (comanando[1])
            {
                case "info":
                case "Info":
                    bot.MakeRequestAsync(new SendMessage(
              messaggio.Chat.Id,
              "Qua verrà mandata la lista degli audio che potrai scrivere")).Wait();
                    break;
            }

        }
        //aggiunto un audio
        private string GeneraLinkAudio(int casuale)
        {
            var linkAudi = new string[115];//modificato a 115
            linkAudi[0] = "http://nazista.altervista.org/audi/don%20matteo%2C%20donma%2C%20domma.mp3";
            linkAudi[1] = "http://nazista.altervista.org/audi/12345.mp3";
            linkAudi[2] = "http://nazista.altervista.org/audi/acciderbolina.mp3";
            linkAudi[3] = "http://nazista.altervista.org/audi/ahahah.mp3";
            linkAudi[4] = "http://nazista.altervista.org/audi/altro%20gruppo.mp3";
            linkAudi[5] = "http://nazista.altervista.org/audi/applausi.mp3";
            linkAudi[6] = "http://nazista.altervista.org/audi/bang.mp3";
            linkAudi[7] = "http://nazista.altervista.org/audi/bella.mp3";
            linkAudi[8] = "http://nazista.altervista.org/audi/brava%20brava.mp3";
            linkAudi[9] = "http://nazista.altervista.org/audi/bruscolini.mp3";
            linkAudi[10] = "http://nazista.altervista.org/audi/bruscolini2.mp3";
            linkAudi[11] = "http://nazista.altervista.org/audi/buono%20brutto%20e%20cattivo.mp3";
            linkAudi[12] = "http://nazista.altervista.org/audi/cazzo%20duro.mp3";
            linkAudi[13] = "http://nazista.altervista.org/audi/ceci%20na%20pa%20pe%20une%20pipe.mp3";
            linkAudi[14] = "http://nazista.altervista.org/audi/ceci%20nes%20pas%20une%20pip.mp3";
            linkAudi[15] = "http://nazista.altervista.org/audi/ceci%20nes%20pas%20une%20pipe.mp3";
            linkAudi[16] = "http://nazista.altervista.org/audi/cezzionale%2C%20cezzio.mp3";
            linkAudi[17] = "http://nazista.altervista.org/audi/che%20cacchio%20dici.mp3";
            linkAudi[18] = "http://nazista.altervista.org/audi/che%20cazzo%20dici.mp3";
            linkAudi[19] = "http://nazista.altervista.org/audi/che%20cervellone.mp3";
            linkAudi[20] = "http://nazista.altervista.org/audi/cioe%20ti.mp3";
            linkAudi[21] = "http://nazista.altervista.org/audi/cosi%20si%20dice%20faccia%20di%20culo.mp3";
            linkAudi[22] = "http://nazista.altervista.org/audi/culo%20pulito%2C%20culo%20lindo.mp3";
            linkAudi[23] = "http://nazista.altervista.org/audi/cureggia.mp3";
            linkAudi[24] = "http://nazista.altervista.org/audi/daun.mp3";
            linkAudi[25] = "http://nazista.altervista.org/audi/daun2.mp3";
            linkAudi[26] = "http://nazista.altervista.org/audi/dici%20solo%20stronzate.mp3";
            linkAudi[27] = "http://nazista.altervista.org/audi/dieghino%20dai%20denti%20a%20sciabola.mp3";
            linkAudi[28] = "http://nazista.altervista.org/audi/dove%20vai.mp3";
            linkAudi[29] = "http://nazista.altervista.org/audi/e%20brutto.mp3";
            linkAudi[30] = "http://nazista.altervista.org/audi/e%20questo%20brutto.mp3";
            linkAudi[31] = "http://nazista.altervista.org/audi/e%20zecchi%20ce.mp3";
            linkAudi[32] = "http://nazista.altervista.org/audi/eee.mp3";
            linkAudi[33] = "http://nazista.altervista.org/audi/faccia%20di%20culo.mp3";
            linkAudi[34] = "http://nazista.altervista.org/audi/fagli%20la%20mossa.mp3";
            linkAudi[35] = "http://nazista.altervista.org/audi/fanno%20cagare%20quelle%20immagini.mp3";
            linkAudi[36] = "http://nazista.altervista.org/audi/fenomeno.mp3";
            linkAudi[37] = "http://nazista.altervista.org/audi/finalmente%2C%20alleluia.mp3";
            linkAudi[38] = "http://nazista.altervista.org/audi/gay%2C%20omosessuale.mp3";
            linkAudi[39] = "http://nazista.altervista.org/audi/giano%20non%20fare%20la%20merda.mp3";
            linkAudi[40] = "http://nazista.altervista.org/audi/giochi%20di%20sabato.mp3";
            linkAudi[41] = "http://nazista.altervista.org/audi/gnamo.mp3";
            linkAudi[42] = "http://nazista.altervista.org/audi/grande.mp3";
            linkAudi[43] = "http://nazista.altervista.org/audi/hihihi.mp3";
            linkAudi[44] = "http://nazista.altervista.org/audi/la%20nazione.mp3";
            linkAudi[45] = "http://nazista.altervista.org/audi/lalalala.mp3";
            linkAudi[46] = "http://nazista.altervista.org/audi/landi%2C%20diego%2C%20dieghino%2C%20pieghino.mp3";
            linkAudi[47] = "http://nazista.altervista.org/audi/lavati%20il%20culo.mp3";
            linkAudi[48] = "http://nazista.altervista.org/audi/le%20fisse.mp3";
            linkAudi[49] = "http://nazista.altervista.org/audi/lololo.mp3";
            linkAudi[50] = "http://nazista.altervista.org/audi/ma%20certo.mp3";
            linkAudi[51] = "http://nazista.altervista.org/audi/maiala%20professionista.mp3";
            linkAudi[52] = "http://nazista.altervista.org/audi/maiala.mp3";
            linkAudi[53] = "http://nazista.altervista.org/audi/maiala2.mp3";
            linkAudi[54] = "http://nazista.altervista.org/audi/maiala3.mp3";
            linkAudi[55] = "http://nazista.altervista.org/audi/maiala4.mp3";
            linkAudi[56] = "http://nazista.altervista.org/audi/maiala5.mp3";
            linkAudi[57] = "http://nazista.altervista.org/audi/maiala6.mp3";
            linkAudi[58] = "http://nazista.altervista.org/audi/maiala7.mp3";
            linkAudi[59] = "http://nazista.altervista.org/audi/male.mp3";
            linkAudi[60] = "http://nazista.altervista.org/audi/maniviglioso.mp3";
            linkAudi[61] = "http://nazista.altervista.org/audi/manuel.mp3";
            linkAudi[62] = "http://nazista.altervista.org/audi/merda.mp3";
            linkAudi[63] = "http://nazista.altervista.org/audi/merda2.mp3";
            linkAudi[64] = "http://nazista.altervista.org/audi/mi%20cascano%20le%20braccia.mp3";
            linkAudi[65] = "http://nazista.altervista.org/audi/mmma.mp3";
            linkAudi[66] = "http://nazista.altervista.org/audi/mmma2.mp3";
            linkAudi[67] = "http://nazista.altervista.org/audi/mmma3.mp3";
            linkAudi[68] = "http://nazista.altervista.org/audi/mmma4.mp3";
            linkAudi[69] = "http://nazista.altervista.org/audi/mmma5.mp3";
            linkAudi[70] = "http://nazista.altervista.org/audi/muschio.mp3";
            linkAudi[71] = "http://nazista.altervista.org/audi/MW3.mp3";
            linkAudi[72] = "http://nazista.altervista.org/audi/no.mp3";
            linkAudi[73] = "http://nazista.altervista.org/audi/non%20mi%20fare%20incazzare.mp3";
            linkAudi[74] = "http://nazista.altervista.org/audi/non%20mi%20riesce%20mandare%20gli%20audi.mp3";
            linkAudi[75] = "http://nazista.altervista.org/audi/nooo%20dieghino.mp3";
            linkAudi[76] = "http://nazista.altervista.org/audi/pagare.mp3";
            linkAudi[77] = "http://nazista.altervista.org/audi/pazzesco.mp3";
            linkAudi[78] = "http://nazista.altervista.org/audi/piedi.mp3";
            linkAudi[79] = "http://nazista.altervista.org/audi/piedi2.mp3";
            linkAudi[80] = "http://nazista.altervista.org/audi/piedi3.mp3";
            linkAudi[81] = "http://nazista.altervista.org/audi/piedi4.mp3";
            linkAudi[82] = "http://nazista.altervista.org/audi/pippo.mp3";
            linkAudi[83] = "http://nazista.altervista.org/audi/puttana%20maiala.mp3";
            linkAudi[84] = "http://nazista.altervista.org/audi/quanto%20sono%20divertente.mp3";
            linkAudi[85] = "http://nazista.altervista.org/audi/rispondi.mp3";
            linkAudi[86] = "http://nazista.altervista.org/audi/roito%20della%20natura%2C%20guarda%20come%20tu%20stai.mp3";
            linkAudi[87] = "http://nazista.altervista.org/audi/sciabolata.mp3";
            linkAudi[88] = "http://nazista.altervista.org/audi/scossa%2C%20va%20bene.mp3";
            linkAudi[89] = "http://nazista.altervista.org/audi/shalala.mp3";
            linkAudi[90] = "http://nazista.altervista.org/audi/si.mp3";
            linkAudi[91] = "http://nazista.altervista.org/audi/siete%20degli%20scorretti.mp3";
            linkAudi[92] = "http://nazista.altervista.org/audi/silviaaa.mp3";
            linkAudi[93] = "http://nazista.altervista.org/audi/spezarsela%2C%20spezzatela%2C%20se%20la%20spezza.mp3";
            linkAudi[94] = "http://nazista.altervista.org/audi/spezzino.mp3";
            linkAudi[95] = "http://nazista.altervista.org/audi/studio.mp3";
            linkAudi[96] = "http://nazista.altervista.org/audi/subito.mp3";
            linkAudi[97] = "http://nazista.altervista.org/audi/succo%20alla%20pera.mp3";
            linkAudi[98] = "http://nazista.altervista.org/audi/tegamello%20rispondi.mp3";
            linkAudi[99] = "http://nazista.altervista.org/audi/ti%20ho%20sentito.mp3";
            linkAudi[100] = "http://nazista.altervista.org/audi/ti%20odio.mp3";
            linkAudi[101] = "http://nazista.altervista.org/audi/tng.mp3";
            linkAudi[102] = "http://nazista.altervista.org/audi/top%20grende%20buio.mp3";
            linkAudi[103] = "http://nazista.altervista.org/audi/troia.mp3";
            linkAudi[104] = "http://nazista.altervista.org/audi/uuu.mp3";
            linkAudi[105] = "http://nazista.altervista.org/audi/vecchio%20maiale.mp3";
            linkAudi[106] = "http://nazista.altervista.org/audi/violento.mp3";
            linkAudi[107] = "http://nazista.altervista.org/audi/vo%20a%20cacare.mp3";
            linkAudi[108] = "http://nazista.altervista.org/audi/wela.mp3";
            linkAudi[109] = "http://nazista.altervista.org/audi/wela2.mp3";
            linkAudi[110] = "http://nazista.altervista.org/audi/wela3.mp3";
            linkAudi[111] = "http://nazista.altervista.org/audi/wela4.mp3";
            linkAudi[112] = "http://nazista.altervista.org/audi/yes.mp3";
            linkAudi[113] = "http://nazista.altervista.org/audi/barum.mp3";
            linkAudi[114] = "http://nazista.altervista.org/audi/essol%20pussy.mp3";//audio aggiunto
            return linkAudi[casuale];
        }
    }
}


