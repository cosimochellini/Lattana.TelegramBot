using System.Collections.Generic;

namespace Telegram.Bot.Examples.Echo.Models
{
    public class Module
    {
        public List<Condition> Conditions = new List<Condition>();

        public List<Action> Actions = new List<Action>();

        public bool Check(string[] comando)
        {
            throw new System.NotImplementedException();
        }

        public bool Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}