using DesginPattern_TP1.Actions;
using DesginPattern_TP1.Interfaces;
using DesginPattern_TP1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace DesignPattern_WinForms
{
    public partial class Home : Form
    {
        List<ShapeFactory.ShapeType> Shapes;
        List<ActionFactory.ActionType> Actions;

        public Home()
        {
            InitializeComponent();
            Shapes = Enum.GetValues(typeof(ShapeFactory.ShapeType)).Cast<ShapeFactory.ShapeType>().ToList();
            Actions = Enum.GetValues(typeof(ActionFactory.ActionType)).Cast<ActionFactory.ActionType>().ToList();
            ActionComboBox.DataSource = Actions;
            ShapesComboBox.DataSource = Shapes;
        }

        private void MakeShapeBtn_Click(object sender, EventArgs e)
        {
            var shapeType = Shapes[ShapesComboBox.SelectedIndex];
            var actionType = Actions[ActionComboBox.SelectedIndex];
            var action = ActionFactory.GetAction(actionType);
            var shape = ShapeFactory.GetShape(shapeType,action);


            ResultLabel.Text = $"You chose '{shape.GetType()}' with '{shape.Action.GetAction()}' action.";
        }
    }
}
