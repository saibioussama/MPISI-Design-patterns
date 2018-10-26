using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Interfaces
{
    public interface IShape
    {
        IAction Action { get; set; }

        string GetType();
    }
}
