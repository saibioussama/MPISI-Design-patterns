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
            LogRepository logRepository = new LogRepository();

            for (int i = 0; i < 1000; i++)
            {
                logRepository.Insert(new Log()
                {
                    Session = $"User {i}",
                    Object = $"Object {i}",
                    Action = $"Action {i}"
                });

                Console.WriteLine($" Object inserted with Connection Id  =>  { DbConnection.ConnectionId}");
            }

            var l = logRepository.Get();

            Console.ReadKey();
        }
    }
}
