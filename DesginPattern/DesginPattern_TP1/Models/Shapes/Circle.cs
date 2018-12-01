using DesginPatternCL.Interfaces;
using DesginPatternCL.Models;
using DesginPatternCL.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPatternCL.Models.Shapes
{
  public class Circle : Shape
  {
    #region Constractors

    public Circle(IAction _Action, Citation citation) 
    {
      _Citation = citation;
      Action = _Action;
    }

    public override int GetPoid()
    {
      return 0;
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
