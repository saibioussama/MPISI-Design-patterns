﻿using DesignPatternCL.Actions.Models;
using DesignPatternCL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCL.Models.Commands
{
  public class PlayMusicCommand : ICommand
  {
    private MusicAction Music;

    public PlayMusicCommand(MusicAction _Music)
    {
      Music = _Music;
    }

    public void Cancel()
    {
      Music.Stop();
    }

    public void Execute()
    {
      Music.Play();
    }
  }
}
