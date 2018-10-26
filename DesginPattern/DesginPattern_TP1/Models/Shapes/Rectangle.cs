using DesginPattern_TP1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Shapes.Models
{
    public class Rectangle : IShape
    {
        public IAction Action { get; set; }

        public Rectangle(IAction _Action)
        {
            Action = _Action;
        }

        string IShape.GetType()
        {
            return nameof(Rectangle);
        }
    }
}
