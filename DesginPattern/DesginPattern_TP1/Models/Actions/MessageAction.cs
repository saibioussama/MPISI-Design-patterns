using DesginPatternCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesginPatternCL.Models.Actions
{
  class MessageAction : IAction
  {
    public void DoSomething()
    {
      throw new NotImplementedException();
    }

    public string GetAction()
    {
      throw new NotImplementedException();
    }

    public void Show()
    {
      Console.WriteLine("Hello World");
    }

    public void Hide()
    {
      
    }

  }
}
