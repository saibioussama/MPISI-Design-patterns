using DesginPattern_TP1.Interfaces;
using DesginPattern_TP1.Models.Shapes;
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

        public static Shape Build(ShapeType shapeType, IAction action, Citation citation)
        {
            switch (shapeType)
            {
                case ShapeType.Circle:
                    return new Circle(action,citation);
                case ShapeType.Rectangle:
                    return new Rectangle(action,citation);
                case ShapeType.Square:
                    return new Square(action,citation);
                default: return null;
            }
        }

        public static Shape Build(ShapeType shapeType , IAction action, List<Shape> Shapes, Citation citation)
        {
            switch (shapeType)
            {
                case ShapeType.Circle:
                    return new Circle(action, citation);
                case ShapeType.Rectangle:
                    return new Rectangle(action, Shapes, citation);
                case ShapeType.Square:
                    return new Square(action, citation);
                default: return null;
            }
        }
    }
}
