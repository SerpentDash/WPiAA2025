using System.Collections.Generic;

namespace Bridge
{
    // Represents OS specific functionality
    public interface ISystem
    {
        IEnumerable<string> GetInstalledPrograms();
    }
}
