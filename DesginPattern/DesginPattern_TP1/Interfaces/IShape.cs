using DesginPattern_TP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern_TP1.Interfaces
{
    public abstract class IShape
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public IAction Action { get; set; }

        public abstract string GetShape();

        public virtual void Add(IShape shape)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(IShape shape)
        {
            throw new NotImplementedException();
        }

        public virtual string Details(int depth = 2) =>new string('-',depth) + $" {GetShape()}";

        public abstract new ShapeFactory.ShapeType GetType();
    }
}
