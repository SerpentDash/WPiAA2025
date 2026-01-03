using System.Collections.Generic;

namespace Observer
{
    public interface ILecturer
    {
        void Register(IStudentObserver student);
        void Unregister(IStudentObserver student);
        void AnnounceResults(Dictionary<string,int> results);
    }
}