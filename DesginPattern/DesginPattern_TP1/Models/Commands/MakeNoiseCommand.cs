using DesignPatternCL.Actions.Models;
using DesignPatternCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCL.Models.Commands
{
  class MakeNoiseCommand : ICommand
  {

    private NoiseAction noiseAction;

    public MakeNoiseCommand(NoiseAction _noiseAction)
    {
      noiseAction = _noiseAction;
    }

    public void Cancel()
    {
      noiseAction.StopMakingNoise();
    }

    public void Execute()
    {
      noiseAction.MakeNoise();
    }
  }
}
