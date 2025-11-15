namespace Proxy
{
    public class PublicFile : IFile
    {
        public string Name { get; }
        private readonly string _contents;

        public PublicFile(string name, string contents)
        {
            Name = name;
            _contents = contents;
        }

        public string GetData()
        {
            return _contents;
        }
    }
}
