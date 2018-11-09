using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesginPattern_TP1.Interfaces;
using DesginPattern_TP1.Models;
using DesginPattern_TP1.Actions;

namespace DesignPattern_WinForms
{
    public partial class ShapeUserControl : UserControl
    {
        int depth;
        IShape Shape;
        IShape ParentShape;
        Random rand = new Random();
        public ShapeUserControl()
        {
            InitializeComponent();
        }

        public ShapeUserControl(ref IShape parentShape,ref IShape shape, int depth)
        {
            InitializeComponent();
            ShapeName.Text = shape.GetShape();
            Padding = new Padding(depth * 10, 0, 0, 0);
            this.Dock = DockStyle.Fill;
            this.depth = depth;
            Shape = shape;
            ParentShape = parentShape;
            this.BackColor = ControlPaint.Light(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),0.9F);
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            ParentShape.Remove(Shape);
            this.Parent.Controls.Remove(this);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            this.tableLayoutPanel2.RowCount++;
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent,75));
            IShape shape = ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, ActionFactory.Build(ActionFactory.ActionType.Noise));
            Shape.Add(shape);
            this.tableLayoutPanel2.Controls.Add(new ShapeUserControl(ref Shape,ref shape,depth+2),0,1);
        }
    }
}
