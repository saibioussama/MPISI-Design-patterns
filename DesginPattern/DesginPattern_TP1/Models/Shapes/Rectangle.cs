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
  public class Rectangle : Shape
  {
    List<Shape> Shapes = new List<Shape>();

    #region Constratctors

    public Rectangle(IAction _Action, Citation citation)
    {
      _Citation = citation;
      Action = _Action;
    }

    public Rectangle(IAction _Action, List<Shape> shapes,Citation citation)
    {
      Action = _Action;
      Shapes = new List<Shape>(shapes);
      _Citation = citation;
    }

    #endregion

    #region Operations

    public override void Add(Shape shape)
    {
      this.Shapes.Add(shape);
    }

    public override void Remove(Shape shape)
    {
      this.Shapes.Remove(shape);
    }

    public override string Details(int depth = 2)
    {
      string result = new string('-', depth) + $" {GetShape()}\n";
      foreach (var shape in Shapes)
        result += $"{shape.Details(depth + 4)}\n";
      return result;
    }

    #endregion

    public override string GetShape()
    {
      return nameof(Rectangle);
    }

    public override ShapeFactory.ShapeType GetType()
    {
      return ShapeFactory.ShapeType.Rectangle;
    }
  }
}
