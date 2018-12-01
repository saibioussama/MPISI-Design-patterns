using DesginPatternCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesginPatternCL.Models.Shapes.Decorators
{
  public class BackgroundColor : ShapeDecorator
  {
    #region Constractors

    public BackgroundColor(Shape _Component) : base(_Component)
    {

    }

    #endregion

    public Color Color { get; set; } = Color.FromRgb(0, 0, 0);

    #region Implementation of Shape decorator

    public override int GetPoid()
    {
      return 1 + Component.GetPoid();
    }

    public override string GetShape()
    {
      return Component.GetShape();
    }

    public override ShapeFactory.ShapeType GetType()
    {
      return Component.GetType();
    }

    #endregion

  }
}
