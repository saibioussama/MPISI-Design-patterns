﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCL.Interfaces
{

  public interface ISubject
  {
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify();
  }
}
