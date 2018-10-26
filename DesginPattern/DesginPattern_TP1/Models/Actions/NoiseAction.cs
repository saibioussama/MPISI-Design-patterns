using DesginPattern_TP1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Actions.Models
{
    public class NoiseAction : IAction
    {
        public string GetAction()
        {
            return "Noise action ";
        }
    }
}
