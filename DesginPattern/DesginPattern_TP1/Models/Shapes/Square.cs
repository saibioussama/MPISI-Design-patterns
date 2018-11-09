﻿using DesginPattern_TP1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Shapes.Models
{
    public class Square : IShape
    {
        #region Constractors

        public Square(IAction _Action)
        {
            Action = _Action;
        }

        #endregion

        #region Operations

        

        #endregion

        public override string GetShape()
        {
            return nameof(Square);
        }
    }
}
