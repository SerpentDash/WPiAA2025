namespace Observer
{
    public interface IStudentObserver
    {
        string Name { get; }
        void Update(int grade);
    }
}