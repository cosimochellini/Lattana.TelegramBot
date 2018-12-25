using System.Linq;

namespace Telegram.Bot.Examples.Echo.Models
{
    public static class ArrayCaratteriIndesiderati
    {
        private static readonly string[] CharArray = { "\"", "?", "!", "#", "'", "\r", "\n", ".", ",", "_", "-" };

        public static string PurificaStringa(string frase) => CharArray.Aggregate(frase, (current, item) => current.Replace(item, " "));        
    }
}
