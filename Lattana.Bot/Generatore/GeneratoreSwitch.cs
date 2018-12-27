using System.Linq;
using Telegram.Bot.Examples.Echo.Manager;
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

        public static bool SwitchFunzioni(Message messaggio)
        {

            if (messaggio.Text == null)
                return true;

            var comando = StringOperator.PurgeString(messaggio.Text);

            if (ModulesManager.CheckModules(comando, messaggio))
                return true;

            if (AnalizzatoreFrase.ListaAudioImmensa(comando, messaggio, ContGiulio))
                return true;

            if (AnalizzatoreFrase.Switch(messaggio, comando, ContOffese, ContPaolo, ContPerle))    //controllo sulla prima parola
                return true;

            if (comando.Any(x => AnalizzatoreFrase.Contiene(messaggio, x, ContSofferenza, ContPano)))
            {
                return true;
            }

            return false;
        }
    }
}