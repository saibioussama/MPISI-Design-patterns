using DesignPatternCL.Actions;
using DesignPatternCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCL.Models
{
  public class Citation : ISubject
  {

    private List<IObserver> Shapes = new List<IObserver>();

    public IAction Action;

    #region Constractors

    public Citation() { }

    public Citation(IAction _action) 
    {
      Action = _action;
    }

    #endregion

    public void Notify()
    {
      foreach (var shape in Shapes)
        shape.Update();
    }

    public void Subscribe(IObserver shape)
    {
      Shapes.Add(shape);
    }

    public void Unsubscribe(IObserver shape)
    {
      Shapes.Remove(shape);
    }

    public IAction State()
    {
      return Action;
    }

  }
}
