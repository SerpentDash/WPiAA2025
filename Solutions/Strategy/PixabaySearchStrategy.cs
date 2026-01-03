using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Strategy
{
    public class PixabaySearchStrategy : IImageSearchStrategy
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public PixabaySearchStrategy(HttpClient http, string apiKey)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public async Task<IEnumerable<ImageResult>> SearchAsync(string category, int perPage = 10, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(category)) throw new ArgumentException("category required", nameof(category));
            var url = $"https://pixabay.com/api/?key={Uri.EscapeDataString(_apiKey)}&q={Uri.EscapeDataString(category)}&per_page={perPage}";
            using var resp = await _http.GetAsync(url, ct);
            resp.EnsureSuccessStatusCode();
            var stream = await resp.Content.ReadAsStreamAsync(ct);

            using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: ct);
            var root = doc.RootElement;
            var list = new List<ImageResult>();
            if (root.TryGetProperty("hits", out var hits))
            {
                foreach (var hit in hits.EnumerateArray())
                {
                    var id = hit.GetProperty("id").GetRawText();
                    var user = hit.GetProperty("user").GetString() ?? string.Empty;
                    var thumb = hit.GetProperty("webformatURL").GetString() ?? string.Empty;
                    var full = hit.TryGetProperty("largeImageURL", out var large) ? large.GetString() ?? string.Empty : string.Empty;

                    list.Add(new ImageResult
                    {
                        Id = id,
                        Photographer = user,
                        ThumbnailUrl = thumb,
                        FullUrl = full,
                        Source = "Pixabay"
                    });
                }
            }

            return list;
        }
    }
}