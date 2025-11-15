using System;

namespace CodeSmells
{
    public class Car
    {
        public Engine GetEngine()
        {
            return new Engine();
        }

        public string GetCylinderSize()
        {
            return GetEngine().GetCylinder().GetSize();
        }
    }

    public class Engine
    {
        public Cylinder GetCylinder()
        {
            return new Cylinder();
        }
    }

    public class Cylinder
    {
        public string GetSize()
        {
            return "2.0L";
        }
    }
}
