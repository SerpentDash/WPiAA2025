using System;

namespace Proxy
{
    public interface IFile
    {
        string Name { get; }
        string GetData();
    }
}
