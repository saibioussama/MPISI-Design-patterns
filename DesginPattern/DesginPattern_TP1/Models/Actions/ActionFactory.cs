using DesginPatternCL.Actions.Models;
using DesginPatternCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPatternCL.Actions
{
  public class ActionFactory
  {
    public enum ActionType
    {
      Music,
      Noise
    };

    private ActionFactory() { }

    public static IAction Build(ActionType actionType)
    {
      switch (actionType)
      {
        case ActionType.Music:
          return new MusicAction();
        case ActionType.Noise:
          return new NoiseAction();
        default:
          return new NoiseAction();
      }
    }
  }
}
