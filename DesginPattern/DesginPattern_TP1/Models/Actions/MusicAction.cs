using DesignPatternCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCL.Actions.Models
{
  public class MusicAction : IAction
  {
    public void DoSomething()
    {
      throw new NotImplementedException();
    }

    public string GetAction()
    {
      return "Music";
    }

    public void Play()
    {

    }

    public void Stop()
    {

    }

  }
}
