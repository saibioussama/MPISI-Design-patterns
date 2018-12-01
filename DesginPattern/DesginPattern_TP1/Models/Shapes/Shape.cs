using DesginPatternCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPatternCL.Models.Shapes
{
  public abstract class Shape : IObserver
  {
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public Citation _Citation { get; set; } // (Observator)

    public System.Windows.Shapes.Shape SystemShape { get; set; } // (WPF Shapes)

    public IAction Action { get; set; } // (Strategie)

    #region Factory abstract methods (Fabrique)

    public abstract string GetShape();

    public abstract new ShapeFactory.ShapeType GetType();

    #endregion

    #region Container methods  (Composite)

    public virtual void Add(Shape shape)
    {
      throw new NotImplementedException();
    }

    public virtual void Remove(Shape shape)
    {
      throw new NotImplementedException();
    }

    #endregion

    public virtual string Details(int depth = 2) => new string('-', depth) + $" {GetShape()}\n";

    #region Observer methods  (Observateur)

    public void Update()
    {
      Action = _Citation.State();
    }

    #endregion

    public abstract int GetPoid();

  }
}

