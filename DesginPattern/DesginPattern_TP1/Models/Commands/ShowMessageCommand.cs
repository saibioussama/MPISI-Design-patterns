using DesginPatternCL.Interfaces;
using DesginPatternCL.Models.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPatternCL.Models.Commands
{
  class ShowMessageCommand : ICommand
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
