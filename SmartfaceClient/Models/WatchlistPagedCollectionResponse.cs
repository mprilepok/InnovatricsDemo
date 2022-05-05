using Newtonsoft.Json;
using System.Collections.Generic;

namespace InnovatricsDemo.SmartfaceClient.Models
{
    public class WatchlistPagedCollectionResponse
    {
        [JsonProperty("totalItemsCount")]
        public int? TotalItemsCount { get; set; }
        
        [JsonProperty("items")]
        public List<WatchlistResponse> Items { get; set; } = new List<WatchlistResponse> { };
        
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }
        
        [JsonProperty("previousPage")]
        public string PreviousPage { get; set; }

        [JsonProperty("nextPage")]
        public string NextPage { get; set; }
    }
}
