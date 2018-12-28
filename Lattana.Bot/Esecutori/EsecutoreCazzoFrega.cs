using System;
using Lattana.Bot.Models;
using Telegram.Bot.Types;

namespace Lattana.Bot.Esecutori
{
    public static class EsecutoreCazzoFrega
    {
        public static void CazzoCheMeNeFregaStiker(Message messaggio)
        {
            Istance.Bot.Istance.SendStickerAsync(messaggio.Chat.Id, $"{Constant.BaseUrl}/Audio/Vastità/vastità{new Random().Next(1, 19)}.webp");
        }

    }
}
