using System;

namespace Proxy
{
    public class FileProxy : IFile
    {
        private readonly IFile _file;
        public string Name => _file.Name;

        public FileProxy(IFile file)
        {
            _file = file;
        }

        public bool TryGetData(string password, out string result)
        {
            if (_file is IProtected protectedFile)
            {
                if (protectedFile.CheckPassword(password))
                {
                    result = _file.GetData();
                    return true;
                }

                result = null!;
                return false;
            }

            result = _file.GetData();
            return true;
        }

        public string GetData()
        {
            if (_file is IProtected)
                throw new UnauthorizedAccessException("Unauthorized access detected.");

            return _file.GetData();
        }
    }
}
