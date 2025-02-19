﻿using DesignPatternCL.Interfaces;
using DesignPatternCL.Models;
using DesignPatternCL.Models.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Models.Shapes
{
  class NewShape : Shape
  {
    private Citation citation;

    public NewShape(IAction action, Citation citation)
    {
      Action = action;
      this.citation = citation;
    }

    public override int GetPoid()
    {
      throw new NotImplementedException();
    }

    public override string GetShape()
    {
      return nameof(NewShape);
    }

    public override ShapeFactory.ShapeType GetType()
    {
      return ShapeFactory.ShapeType.NewShape;
    }
  }
}
