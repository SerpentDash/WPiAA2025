namespace Proxy
{
    public class ProtectedFile : IFile, IProtected
    {
        public string Name { get; }
        private readonly string _contents;
        private readonly string _password;

        public ProtectedFile(string name, string contents, string password)
        {
            Name = name;
            _contents = contents;
            _password = password;
        }
        
        public string GetData()
        {
            return _contents;
        }

        public bool CheckPassword(string password)
        {
            return _password == password;
        }
    }
}
