using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPatternCL.Models.Shapes
{
  public abstract class ShapeDecorator : Shape
  {
    protected Shape Component;

    public ShapeDecorator(Shape _Componenet)
    {
      Component = _Componenet;
    }

  }
}
