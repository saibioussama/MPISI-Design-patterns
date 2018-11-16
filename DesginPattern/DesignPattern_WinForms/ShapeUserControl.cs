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
using DesginPattern_TP1.Models.Shapes;

namespace DesignPattern_WinForms
{
    public partial class ShapeUserControl : UserControl
    {
        int depth;
        Shape Shape;
        Shape ParentShape;
        Random rand = new Random();
        Graphics graphics;
       
        public ShapeUserControl()
        {
            InitializeComponent();
        }

        public ShapeUserControl(ref Shape parentShape, ref Shape shape, int depth)
        {
            InitializeComponent();
            
            ShapeName.Text = shape.GetShape();
            Padding = new Padding(depth * 10, 0, 0, 0);
            this.Dock = DockStyle.Fill;
            this.depth = depth;
            Shape = shape;
            ParentShape = parentShape;
            if (shape.GetType() == ShapeFactory.ShapeType.Rectangle)
            {
                this.BackColor = Color.FromArgb(rand.Next(50)+200, rand.Next(50) + 200, rand.Next(50) + 200);
            }
            else
            {
                this.BackColor = Color.Transparent;
            }
        }

        private void DrawCircle()
        {
            graphics.FillEllipse(new SolidBrush(Color.White),
                new RectangleF()
                {
                    Height = this.Height,
                    Width = this.Height,
                    X = 0,
                    Y = 0,
                });
        }

        private void DrawSquare()
        {
            graphics.FillRectangle(new SolidBrush(Color.White),
                new RectangleF()
                {
                    Height = this.Height,
                    Width = this.Height,
                    X = 0,
                    Y = 0,
                });
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            ParentShape.Remove(Shape);
            var k = Parent.Controls[Parent.Controls.IndexOf(this)] as ShapeUserControl;
            k.tableLayoutPanel2.RowCount--;
            this.Parent.Controls.Remove(this);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.tableLayoutPanel2.RowCount++;
                this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                Shape shape = ShapeFactory.Build(Home.selectedShape, ActionFactory.Build(Home.selectedAction));
                Shape.Add(shape); 
                this.tableLayoutPanel2.Controls.Add(new ShapeUserControl(ref Shape, ref shape, depth + 2), 0, 1);
            }
            catch(NotImplementedException ex)
            {
                this.tableLayoutPanel2.RowCount--;
                MessageBox.Show($"{Shape.GetShape()} can not contain any other shape ");
            }catch(Exception ex)
            {
                this.tableLayoutPanel2.RowCount--;
                MessageBox.Show($"Something went wrong! \nFor more details : \n{ex.Message}");
            }
        }

        private void ShapeUserControl_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;

            switch (Shape.GetType())
            {
                case ShapeFactory.ShapeType.Circle:
                    DrawCircle();
                    break;
                case ShapeFactory.ShapeType.Square:
                    DrawSquare();
                    break;
                default:
                    break;
            }
        }
    }
}
