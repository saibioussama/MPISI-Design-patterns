using DesignPatternCL.Interfaces;
using DesignPatternCL.Models.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCL.Models.Commands
{
  public class ShowMessageCommand : ICommand
  {
    private MessageAction messageAction;

    public ShowMessageCommand(MessageAction _messageAction)
    {
      messageAction = _messageAction;
    }

    public void Cancel()
    {
      messageAction.Hide();
    }

    public void Execute()
    {
      messageAction.Show();
    }
  }
}
