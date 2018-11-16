using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Interfaces
{

  public interface ISubject
  {
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify();
  }
}
