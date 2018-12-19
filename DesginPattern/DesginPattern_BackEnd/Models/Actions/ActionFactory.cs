using DesignPatternCL.Actions.Models;
using DesignPatternCL.Interfaces;
using DesignPatternCL.Models.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCL.Actions
{
  public class ActionFactory
  {
    public enum ActionType
    {
      Music,
      Noise,
      Message
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
        case ActionType.Message:
          return new MessageAction();
        default:
          return new NoiseAction();
      }
    }
  }
}
