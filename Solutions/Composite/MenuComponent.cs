using System;
using System.Collections.Generic;
namespace Composite
{
    public abstract class MenuComponent
    {
        public string Name { get; protected set; }
        public string? Description { get; protected set; }

        protected MenuComponent(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }

        public virtual void Add(MenuComponent component) => throw new NotSupportedException();
        public virtual void Remove(MenuComponent component) => throw new NotSupportedException();
        public virtual MenuComponent GetChild(int index) => throw new NotSupportedException();

        public abstract void Print(int indent = 0);
    }
}
