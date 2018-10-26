using DesginPattern_TP1.Interfaces;
using DesginPattern_TP1.Shapes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Models
{
    public class ShapeFactory
    {
        public enum ShapeType
        {
            Rectangle,
            Circle,
            Square
        }

        private ShapeFactory()
        {

        }

        public static IShape GetShape(ShapeType shapeType, IAction action)
        {
            switch (shapeType)
            {
                case ShapeType.Circle:
                    return new Circle(action);
                case ShapeType.Rectangle:
                    return new Rectangle(action);
                case ShapeType.Square:
                    return new Square(action);
                default: return null;
            }
        }
    }
}
