using System.Collections.Generic;

namespace Bridge
{
    public class LinuxSystem : ISystem
    {
        public IEnumerable<string> GetInstalledPrograms()
        {
            return new List<string>
            {
                "bash",
                "vim",
                "firefox",
                "code",
                "docker"
            };
        }
    }
}
