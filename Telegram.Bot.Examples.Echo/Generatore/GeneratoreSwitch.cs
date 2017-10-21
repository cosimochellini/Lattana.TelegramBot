using System;
using System.Linq;
using Telegram.Bot.Examples.Echo.Manager;
using Telegram.Bot.Examples.Echo.Models;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Generatore
{
    public static class GeneratoreSwitch
    {
        private const int ContOffese = 18;
        private const int ContPerle = 26;
        private const int ContPaolo = 25;
        private const int ContSofferenza = 11;
        private const int ContGiulio = 9;
        private const int ContPano = 13;

        public static bool SwitchFunzioni(Message messaggio, TelegramBotClient bot, StatManager statManager)
        {

            if (messaggio.Text == null)
                return true;

            var comando = PurificaStringa(messaggio.Text);

            if (AnalizzatoreFrase.ListaAudioImmensa(comando, bot, messaggio, ContGiulio))
                return true;

            if (AnalizzatoreFrase.Switch(messaggio, comando, bot, ContOffese, ContPaolo, ContPerle, statManager))    //controllo sulla prima parola
                return true;

            if (comando.Any(x => AnalizzatoreFrase.Contiene(messaggio, x, bot, ContSofferenza, ContPano)))
            {
                return true;
            }

            return false;

        }

        public static bool FraseContiene(string[] comando, string[] vettoreParole, int numeroCondizioni = 0)
        {

            if (numeroCondizioni == 0)
                numeroCondizioni = vettoreParole.Length;

            var contatore = vettoreParole.Count(parola => comando.Any(x => x.Equals(parola)));

            //foreach (var parola in vettoreParole)
            //{
            //    if (comando.Any(x => x.Equals(parola))) contatore++;
            //}

            return contatore >= numeroCondizioni;
        }

        private static string[] PurificaStringa(string strindaDaPurificare)
        {
            strindaDaPurificare = ArrayCaratteriInderiderati.PurificaStringa(strindaDaPurificare);

            var arrayPurificato = strindaDaPurificare.Split(Convert.ToChar(" ")).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (var i = 0; i < arrayPurificato.Length; i++)
            {
                arrayPurificato[i] = arrayPurificato[i].ToLower();
            }

            return arrayPurificato;
        }
    }
}