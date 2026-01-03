using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Strategy
{
    public class PexelsSearchStrategy : IImageSearchStrategy
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public PexelsSearchStrategy(HttpClient http, string apiKey)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));

            // Pexels expects the key in the Authorization header
            if (!_http.DefaultRequestHeaders.Contains("Authorization"))
            {
                _http.DefaultRequestHeaders.Add("Authorization", _apiKey);
            }
        }

        public async Task<IEnumerable<ImageResult>> SearchAsync(string category, int perPage = 10, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(category)) throw new ArgumentException("category required", nameof(category));
            var url = $"https://api.pexels.com/v1/search?query={Uri.EscapeDataString(category)}&per_page={perPage}";
            using var resp = await _http.GetAsync(url, ct);
            resp.EnsureSuccessStatusCode();
            var stream = await resp.Content.ReadAsStreamAsync(ct);

            using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: ct);
            var root = doc.RootElement;
            var list = new List<ImageResult>();
            if (root.TryGetProperty("photos", out var photos))
            {
                foreach (var photo in photos.EnumerateArray())
                {
                    var id = photo.GetProperty("id").GetRawText();
                    var photographer = photo.GetProperty("photographer").GetString() ?? string.Empty;
                    var src = photo.GetProperty("src");
                    var thumb = src.GetProperty("medium").GetString() ?? string.Empty;
                    var full = src.GetProperty("original").GetString() ?? string.Empty;

                    list.Add(new ImageResult
                    {
                        Id = id,
                        Photographer = photographer,
                        ThumbnailUrl = thumb,
                        FullUrl = full,
                        Source = "Pexels"
                    });
                }
            }

            return list;
        }
    }
}