using System.Linq;

namespace Telegram.Bot.Examples.Echo.Models
{
    public static class ArrayCaratteriInderiderati
    {
        public static string PurificaStringa(string frase)
        {
            var charArray = new[] {"\"", "?", "!", "#", "'", "\r", "\n", ".", ",", "_", "-"};
            
            frase = charArray.Aggregate(frase, (current, item) => current.Replace(item, " "));

            return frase;
        }

    }
}
