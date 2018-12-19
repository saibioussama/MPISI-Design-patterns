using DesignPatternCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPatternCL.Models.Actions
{
  public class MessageAction : IAction
  {
    public void DoSomething()
    {
      throw new NotImplementedException();
    }

    public string GetAction()
    {
      return "Message";
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
