namespace Lattana.Bot.Models
{
    public class UserStat
    {
        public string Username { get; set; } ="";
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int ContText { get; set; }
        public int ContAudio { get; set; }
        public int ContImg { get; set; }
        public int ContSticker { get; set; }
        public long Id { get; set; }
    }
}