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

        public static ShapeFactory.ShapeType selectedShape;
        public static ActionFactory.ActionType selectedAction;

        IShape ParentShape;

        public Home()
        {
            InitializeComponent();

            Shapes = Enum.GetValues(typeof(ShapeFactory.ShapeType)).Cast<ShapeFactory.ShapeType>().ToList();
            Actions = Enum.GetValues(typeof(ActionFactory.ActionType)).Cast<ActionFactory.ActionType>().ToList();
            ActionsComboBox.DataSource = Actions;
            ShapesCombobox.DataSource = Shapes;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            var shapeType = Shapes[ShapesCombobox.SelectedIndex];
            var actionType = Actions[ActionsComboBox.SelectedIndex];

            var action = ActionFactory.Build(actionType);
            var shape = ShapeFactory.Build(shapeType, action);
            ParentShape = shape;
            MyPanel.Controls.Add(new ShapeUserControl(ref ParentShape,ref shape, 1));
        }

        private void DetailsBtn_Click(object sender, EventArgs e)
        {
            DetailsLabel.Text = ParentShape.Details();
        }

        private void ShapesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShape = Shapes[ShapesCombobox.SelectedIndex];
        }

        private void ActionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAction= Actions[ActionsComboBox.SelectedIndex];
        }
    }
}
