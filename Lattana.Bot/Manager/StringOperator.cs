using System;
using System.Linq;

namespace Telegram.Bot.Examples.Echo.Manager
{
    public static class StringOperator
    {
        private static readonly string[] CharArray = { "\"", "?", "!", "#", "'", "\r", "\n", ".", ",", "_", "-" };

        private static string Purifica(string frase) => CharArray.Aggregate(frase, (current, item) => current.Replace(item, " "));

        public static bool Contains(string[] comando, string[] vettoreParole, int numeroCondizioni = 0)
        {

            if (numeroCondizioni == 0)
                numeroCondizioni = vettoreParole.Length;

            var contatore = vettoreParole.Count(parola => comando.Any(x => x.Equals(parola)));

            return contatore >= numeroCondizioni;
        }

        public static string[] PurgeString(string strindaDaPurificare)
        {
            strindaDaPurificare = Purifica(strindaDaPurificare);

            var arrayPurificato = strindaDaPurificare.Split(Convert.ToChar(" ")).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (var i = 0; i < arrayPurificato.Length; i++)
            {
                arrayPurificato[i] = arrayPurificato[i].ToLower();
            }

            return arrayPurificato;
        }
    }
}
