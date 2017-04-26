namespace TelegramBotDemo.Models
{
    public class UserStat
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int ContText { get; set; } = 0;
        public int ContAudio { get; set; } = 0;
        public int ContImg { get; set; } = 0;
        public int ContSticker { get; set; } = 0;
        public long Id { get; set; }
    }
}
