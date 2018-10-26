using DesginPattern_TP1.Actions;
using DesginPattern_TP1.Actions.Models;
using DesginPattern_TP1.Interfaces;
using DesginPattern_TP1.Models;
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


            IAction Music = ActionFactory.GetAction(ActionFactory.ActionType.Music);
            IAction Noise = ActionFactory.GetAction(ActionFactory.ActionType.Noise);

            List<IShape> shapes = new List<IShape>();

            shapes.Add(ShapeFactory.GetShape(ShapeFactory.ShapeType.Rectangle, Music));
            shapes.Add(ShapeFactory.GetShape(ShapeFactory.ShapeType.Circle, Noise));
            shapes.Add(ShapeFactory.GetShape(ShapeFactory.ShapeType.Square, Music));

            foreach (var shape in shapes)
            {
                Console.WriteLine();
                Console.WriteLine($"  * form : {shape.GetType()} ===>  {shape.Action.GetAction()}");
            }

            Console.ReadKey();
        }
    }
}
