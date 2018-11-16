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
  public class Circle : Shape
  {
    #region Constractors

    public Circle(IAction _Action, Citation citation)
    {
      _Citation = citation;
      Action = _Action;
    }

    #endregion

    #region Operations


    #endregion

    public override string GetShape()
    {
      return nameof(Circle);
    }

    public override ShapeFactory.ShapeType GetType()
    {
      return ShapeFactory.ShapeType.Circle;
    }
  }
}
