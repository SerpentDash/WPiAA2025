using System.Collections.Generic;

namespace Bridge
{
    public class WindowsSystem : ISystem
    {
        public IEnumerable<string> GetInstalledPrograms()
        {
            return new List<string>
            {
                "Explorer",
                "Notepad",
                "Edge",
                "Visual Studio",
                "PowerShell"
            };
        }
    }
}
