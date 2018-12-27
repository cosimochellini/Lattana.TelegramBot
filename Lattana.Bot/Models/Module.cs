using System;
using System.Collections.Generic;
using Telegram.Bot.Examples.Echo.Manager;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Models
{
    public class Module
    {
        public List<Condition> Conditions = new List<Condition>();

        public bool CheckAll = false;

        public List<Action> Actions = new List<Action>();

        public bool Check(string[] comando)
        {
            if (CheckAll)
            {
                foreach (var condition in Conditions)
                {
                    if (!StringOperator.Contains(comando, condition.Phrases.ToArray(), condition.ConditionCounter))
                        return false;
                }
                return true;
            }

            foreach (var condition in Conditions)
            {
                if (StringOperator.Contains(comando, condition.Phrases.ToArray(), condition.ConditionCounter))
                    return true;
            }
            return false;
        }

        public bool Execute(Message messaggio)
        {
            try
            {
                foreach (var action in Actions)
                {
                    action.Execute(messaggio);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

    }
}