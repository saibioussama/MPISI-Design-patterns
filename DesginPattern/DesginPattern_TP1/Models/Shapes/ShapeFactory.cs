﻿using DesginPattern_TP1.Models.Shapes;
using DesignPatternCL.Interfaces;
using DesignPatternCL.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCL.Models
{
  public class ShapeFactory
  {
    public enum ShapeType
    {
      Rectangle,
      Circle,
      Square,
      NewShape
    }

    private ShapeFactory() { }

    public static Shape Build(ShapeType shapeType, IAction action, Citation citation, int _Poid = 1)
    {
      switch (shapeType)
      {
        case ShapeType.Circle:
          return new Circle(action, citation);
        case ShapeType.Rectangle:
          return new Rectangle(action, citation);
        case ShapeType.Square:
          return new Square(action, citation);
        case ShapeType.NewShape:
          return new NewShape(action, citation);
        default: return null;
      }
    }
    
  }
}
