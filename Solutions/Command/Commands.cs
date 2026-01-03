namespace Command
{
    public interface ICommand { }

    public class MakeToyCommand : ICommand
    {
        public string ToyName { get; }
        public MakeToyCommand(string toyName) => ToyName = toyName;
    }

    public class MakeRodCommand : ICommand { }
}
