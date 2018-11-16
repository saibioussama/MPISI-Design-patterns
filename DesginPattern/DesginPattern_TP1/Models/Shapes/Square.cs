using DesginPattern_TP1.Interfaces;
using DesginPattern_TP1.Models;
using DesginPattern_TP1.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Shapes.Models
{
  public class Square : Shape
  {
    #region Constractors

    public Square(IAction _Action, Citation citation)
    {
      _Citation = citation;
      Action = _Action;
    }

    #endregion


    public override string GetShape()
    {
      return nameof(Square);
    }

    public override ShapeFactory.ShapeType GetType()
    {
      return ShapeFactory.ShapeType.Square;
    }
  }
}
