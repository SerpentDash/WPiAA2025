using Newtonsoft.Json;

namespace Prototype
{
    public class Ork
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }

        public Ork(string name, int strength, int health)
        {
            Name = name;
            Strength = strength;
            Health = health;
        }

        public Ork Clone()
        {
            string json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Ork>(json)!;
        }

        public override string ToString()
        {
            return $"Ork: {Name}, Strength: {Strength}, Health: {Health}";
        }
    }
}