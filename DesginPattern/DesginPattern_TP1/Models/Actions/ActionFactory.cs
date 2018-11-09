using DesginPattern_TP1.Actions.Models;
using DesginPattern_TP1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Actions
{
    public class ActionFactory 
    {
        public enum ActionType
        {
            Music,
            Noise
        };

        private ActionFactory() { }

        public static IAction Build(ActionType actionType)
        {
            switch (actionType)
            {
                case ActionType.Music:
                    return new MusicAction();
                case ActionType.Noise:
                    return new NoiseAction();
                default:
                    return null;
            }
        }
    }
}
