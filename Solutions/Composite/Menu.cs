using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public class Menu : MenuComponent
    {
        private readonly List<MenuComponent> _children = new List<MenuComponent>();

        public Menu(string name, string? description = null)
            : base(name, description)
        { }

        public override void Add(MenuComponent component)
        {
            _children.Add(component);
        }

        public override void Remove(MenuComponent component)
        {
            _children.Remove(component);
        }

        public override MenuComponent GetChild(int index)
        {
            return _children[index];
        }

        public IEnumerable<MenuComponent> Children => _children.AsReadOnly();

        public override void Print(int indent = 0)
        {
            var ind = new string(' ', indent * 2);
            Console.WriteLine($"{ind}{Name} ({Description})");
            foreach (var child in _children)
                child.Print(indent + 1);
        }

        public Menu? FindMenuByName(string name)
        {
            if (string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
                return this;

            foreach (var c in _children.OfType<Menu>())
            {
                var found = c.FindMenuByName(name);
                if (found != null)
                    return found;
            }

            return null;
        }
    }
}
