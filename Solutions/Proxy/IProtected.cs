namespace Proxy
{
    public interface IProtected
    {
        bool CheckPassword(string password);
    }
}
