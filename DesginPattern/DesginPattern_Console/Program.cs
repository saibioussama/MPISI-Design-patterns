using DesignPatternCL.Actions;
using DesignPatternCL.Actions.Models;
using DesignPatternCL.Interfaces;
using DesignPatternCL.Models;
using DesignPatternCL.Models.Actions;
using DesignPatternCL.Models.Shapes;
using DesignPatternCL.Models.Shapes.Decorators;
using DesignPatternCL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern
{
  class Program
  {
    static void Main(string[] args)
    {
      // TP1 ===> Singleton
      //LogRepository logRepository = new LogRepository();

      //for (int i = 0; i < 100; i++)
      //{
      //  logRepository.Insert(new Log()
      //  {
      //    Session = $"User {i}",
      //    Object = $"Object {i}",
      //    Action = $"Action {i}"
      //  });

      //  Console.WriteLine($" Object inserted with Connection Id  =>  { DbConnection.ConnectionId}");
      //}

      //var l = logRepository.Get();

      //Console.ReadKey();
      //**************************************************************************

      //TP2 ====> Faactory & Strategy 


      //IAction Music = ActionFactory.Build(ActionFactory.ActionType.Music);
      //IAction Noise = ActionFactory.Build(ActionFactory.ActionType.Noise);
      //IAction Message = ActionFactory.Build(ActionFactory.ActionType.Message);

      //List<Shape> shapes = new List<Shape>();
      //Citation c = new Citation();
      //shapes.Add(ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, Music,c));
      //shapes.Add(ShapeFactory.Build(ShapeFactory.ShapeType.Circle, Noise,c));
      //shapes.Add(ShapeFactory.Build(ShapeFactory.ShapeType.Square, Message,c));

      //foreach (var shape in shapes)
      //{
      //  Console.WriteLine();
      //  Console.WriteLine($"  * form : {shape.GetShape()} ===>  {shape.Action.GetAction()}");
      //}
      //******************************************************************
      // TP4 ====> Observateur


      //Citation citation = new Citation(ActionFactory.Build(ActionFactory.ActionType.Music));

      //Shape rectangle = ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, ActionFactory.Build(ActionFactory.ActionType.Noise), citation);
      //Shape ellipse = ShapeFactory.Build(ShapeFactory.ShapeType.Circle, ActionFactory.Build(ActionFactory.ActionType.Noise), citation);
      //Shape square = ShapeFactory.Build(ShapeFactory.ShapeType.Square, ActionFactory.Build(ActionFactory.ActionType.Music), citation);

      //Console.WriteLine($" {rectangle.GetShape()} - {rectangle.Action.GetAction()}");
      //Console.WriteLine($" {ellipse.GetShape()} - {ellipse.Action.GetAction()}");
      //Console.WriteLine($" {square.GetShape()} - {square.Action.GetAction()}");

      //Console.WriteLine();
      //Console.WriteLine("========= Subscribe rectangle && square && ellipse");
      //Console.WriteLine();

      //citation.Subscribe(rectangle);
      //citation.Subscribe(ellipse);
      //citation.Subscribe(square);
      //citation.Notify();
      //Console.WriteLine($" {rectangle.GetShape()} - {rectangle.Action.GetAction()}");
      //Console.WriteLine($" {ellipse.GetShape()} - {ellipse.Action.GetAction()}");
      //Console.WriteLine($" {square.GetShape()} - {square.Action.GetAction()}");

      //Console.WriteLine();
      //Console.WriteLine("========= Unsubscribe rectangle && square");
      //Console.WriteLine();

      //citation.Unsubscribe(rectangle);
      //citation.Unsubscribe(square);
      //citation.Action = ActionFactory.Build(ActionFactory.ActionType.Noise);
      //citation.Notify();
      //Console.WriteLine($" {rectangle.GetShape()} - {rectangle.Action.GetAction()}");
      //Console.WriteLine($" {ellipse.GetShape()} - {ellipse.Action.GetAction()}");
      //Console.WriteLine($" {square.GetShape()} - {square.Action.GetAction()}");


      //**************************************

      Shape rectangle = ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, ActionFactory.Build(ActionFactory.ActionType.Music), new Citation());

      Shape c = new BackgroundColor(rectangle);
      Shape r1 = new BackgroundColor(c);
      r1 = ShapeFactory.Build(ShapeFactory.ShapeType.Circle, ActionFactory.Build(ActionFactory.ActionType.Noise), new Citation());
      Shape r2 = new BackgroundColor(r1);
      r1 = new BackgroundColor(r1);
      r1 = new BorderColor(r1);
      Console.WriteLine($"{rectangle.GetShape()} - {rectangle.GetPoid()}");
      Console.WriteLine($"{c.GetShape()} - {c.GetPoid()}");

      c = new BorderColor(c);

      Console.WriteLine($"{r1.GetShape()} - {r1.GetPoid()}");
      Console.WriteLine($"{c.GetShape()} - {c.GetPoid()}");


      Console.ReadKey();
    }
  }
}
