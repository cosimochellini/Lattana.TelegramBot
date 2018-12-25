using System;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Esecutori
{
    public static class EsecutoreCazzoFrega
    {
        public static void CazzoCheMeNeFregaStiker(Message messaggio)
        {
            const string baseUrl = "http://nazista.altervista.org";
            Models.Bot.Istance.SendStickerAsync(messaggio.Chat.Id, $"{baseUrl}/Audio/Vastità/vastità{new Random().Next(1, 19)}.webp");
        }

    }
}
