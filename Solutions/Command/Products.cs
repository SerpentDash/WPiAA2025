namespace Command
{
    public interface IProduct
    {
        string Name { get; }
    }

    public class Toy : IProduct
    {
        public string Name { get; }
        public Toy(string name) => Name = name;
        public override string ToString() => $"Toy: {Name}";
    }

    public class Rod : IProduct
    {
        public string Name { get; }
        public Rod() => Name = "Rózga";
        public override string ToString() => $"Rod: {Name}";
    }
}
