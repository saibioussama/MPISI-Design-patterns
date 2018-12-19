using DesignPatternCL.Interfaces;
using DesignPatternCL.Models;
using DesignPatternCL.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCL.Models.Shapes
{
  public class Square : Shape
  {
    #region Constractors

    public Square(IAction _Action, Citation citation)
    {
      _Citation = citation;
      Action = _Action;
    }

    public override int GetPoid()
    {
      return 0;
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
