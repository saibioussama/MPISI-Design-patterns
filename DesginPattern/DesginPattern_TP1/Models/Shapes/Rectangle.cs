using DesginPattern_TP1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Shapes.Models
{
    public class Rectangle : IShape
    {
        List<IShape> Shapes = new List<IShape>();

        #region Constratctors

        public Rectangle(IAction _Action)
        {
            Action = _Action;
        }

        public Rectangle(IAction _Action,List<IShape> shapes)
        {
            Action = _Action;
            Shapes = new List<IShape>(shapes);
        }

        #endregion

        #region Operations

        public override void Add(IShape shape)
        {
            this.Shapes.Add(shape);
        }

        public override void Remove(IShape shape)
        {
            this.Shapes.Remove(shape);
        }

        public override string Details(int depth = 2)
        {
            string result = new string('-',depth) + $" {GetShape()}\n";
            foreach (var shape in Shapes)
                result += $"{shape.Details(depth+4)}\n";
            return result;
        }

        #endregion

        public override string GetShape()
        {
            return nameof(Rectangle);
        }
    }
}
