using DesginPattern_TP1.Actions;
using DesginPattern_TP1.Actions.Models;
using DesginPattern_TP1.Interfaces;
using DesginPattern_TP1.Models;
using DesginPattern_TP1.Models.Shapes;
using DesginPattern_TP1.Repositories;
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

      //for (int i = 0; i < 1000; i++)
      //{
      //    logRepository.Insert(new Log()
      //    {
      //        Session = $"User {i}",
      //        Object = $"Object {i}",
      //        Action = $"Action {i}"
      //    });

      //    Console.WriteLine($" Object inserted with Connection Id  =>  { DbConnection.ConnectionId}");
      //}

      //var l = logRepository.Get();

      //Console.ReadKey();


      //TP2 ====> Faactory & Strategy 


      //IAction Music = ActionFactory.Build(ActionFactory.ActionType.Music);
      //IAction Noise = ActionFactory.Build(ActionFactory.ActionType.Noise);

      //List<IShape> shapes = new List<IShape>();

      //shapes.Add(ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, Music));
      //shapes.Add(ShapeFactory.Build(ShapeFactory.ShapeType.Circle, Noise));
      //shapes.Add(ShapeFactory.Build(ShapeFactory.ShapeType.Square, Music));

      //foreach (var shape in shapes)
      //{
      //    Console.WriteLine();
      //    Console.WriteLine($"  * form : {shape.GetShape()} ===>  {shape.Action.GetAction()}");
      //}
      
      // TP4 ====> Observateur

      //Observer ob = new Observer();
      //Subject subject = new Subject();
      //Observer1 ob1 = new Observer1();

      //subject.Add(ob.Update);

      //subject.Add(ob1.Update);

      //subject.Notify();

      //subject.Remove(ob.Update);
      //subject.Notify();

      Citation citation = new Citation(ActionFactory.Build(ActionFactory.ActionType.Music));
      
      Shape rectangle = ShapeFactory.Build(ShapeFactory.ShapeType.Rectangle, ActionFactory.Build(ActionFactory.ActionType.Noise),citation);
      Shape ellipse = ShapeFactory.Build(ShapeFactory.ShapeType.Circle, ActionFactory.Build(ActionFactory.ActionType.Noise),citation);
      Shape square = ShapeFactory.Build(ShapeFactory.ShapeType.Square, ActionFactory.Build(ActionFactory.ActionType.Music),citation);
      
      Console.WriteLine($" {rectangle.GetShape()} - {rectangle.Action.GetAction()}");
      Console.WriteLine($" {ellipse.GetShape()} - {ellipse.Action.GetAction()}");
      Console.WriteLine($" {square.GetShape()} - {square.Action.GetAction()}");
      
      Console.WriteLine();
      Console.WriteLine("========= Subscribe rectangle && square && ellipse");
      Console.WriteLine();

      citation.Subscribe(rectangle);
      citation.Subscribe(ellipse);
      citation.Subscribe(square);
      citation.Notify();
      Console.WriteLine($" {rectangle.GetShape()} - {rectangle.Action.GetAction()}");
      Console.WriteLine($" {ellipse.GetShape()} - {ellipse.Action.GetAction()}");
      Console.WriteLine($" {square.GetShape()} - {square.Action.GetAction()}");

      Console.WriteLine();
      Console.WriteLine("========= Unsubscribe rectangle && square");
      Console.WriteLine();

      citation.Unsubscribe(rectangle);
      citation.Unsubscribe(square);
      citation.Action = ActionFactory.Build(ActionFactory.ActionType.Noise);
      citation.Notify();
      Console.WriteLine($" {rectangle.GetShape()} - {rectangle.Action.GetAction()}");
      Console.WriteLine($" {ellipse.GetShape()} - {ellipse.Action.GetAction()}");
      Console.WriteLine($" {square.GetShape()} - {square.Action.GetAction()}");

      Console.ReadKey();
    }
  }
}
