using System;

namespace Builder
{
    public interface IWarrior
    {
        string Nazwa { get; set; }
        void OpiszSie();
    }
}