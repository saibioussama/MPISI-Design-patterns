using DesginPattern_TP1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Models.Shapes
{
  public abstract class Shape : IObserver
  {
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public Citation _Citation { get; set; }

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

    public virtual string Details(int depth = 2) => new string('-', depth) + $" {GetShape()}";

    #region Observer methods  (Observeur)

    public void Update()
    {
      Action = _Citation.State();
    }

    #endregion

  }
}

