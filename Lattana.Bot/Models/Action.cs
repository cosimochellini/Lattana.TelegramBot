using Telegram.Bot.Types;

namespace Lattana.Bot.Models
{
    public class Action
    {
        public string Type = "";

        public string Content = "";

        public void Execute(Message messaggio)
        {
            switch (Type.ToLower())
            {
                case "text":
                    Content = BindContent(Content);
                    Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, Content);
                    break;
                case "audio":
                case "voice":
                    Content = BindContent(Content);
                    Istance.Bot.Istance.SendAudioAsync(messaggio.Chat.Id, Content);
                    break;
                case "sticker":
                    Content = BindContent(Content);
                    Istance.Bot.Istance.SendStickerAsync(messaggio.Chat.Id, Content);
                    break;
            }

        }

        private string BindContent(string content)
        {
            return content.Replace("#baseurl", "").Replace("", "");
        }

    }
}
