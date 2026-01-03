using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Strategy
{
    public interface IImageSearchStrategy
    {
        Task<IEnumerable<ImageResult>> SearchAsync(string category, int perPage = 10, CancellationToken ct = default);
    }
}