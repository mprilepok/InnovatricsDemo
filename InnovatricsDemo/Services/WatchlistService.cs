using InnovatricsDemo.Models;
using InnovatricsDemo.SmartfaceClient;
using NLog;
using System.Collections.Generic;
using System.Linq;

namespace InnovatricsDemo.Services
{
    public interface IWatchlistService
    {
        List<WachlistModel> GetWatchlists();
        void AddWatchlist(WachlistModel watchlist);
        SearchResultModel Search(string watchlistId, string photo, int threshold, int minFaceSize, int maxFaceSize);
    }

    public class WatchlistService : IWatchlistService
    {
        private readonly Logger _logger;
        private readonly WatchlistClient _client;

        public WatchlistService(Logger logger)
        {
            _logger = logger;
            _client = new WatchlistClient(_logger);

            _logger.Trace("WatchlistService - ctor");
        }

        public void AddWatchlist(WachlistModel watchlist)
        {
            _logger.Trace("AddWatchlist - call");

            _client.AddWatchlist(watchlist.DisplayName, watchlist.FullName, watchlist.Threshold, watchlist.PreviewColor);
        }

        public List<WachlistModel> GetWatchlists()
        {
            _logger.Trace("GetWatchlists - call");

            var data = _client.GetAllWatchlists();

            return data.Items.Select(item => new WachlistModel() { Id = item.Id, DisplayName = item.DisplayName, FullName = item.FullName, PreviewColor = item.PreviewColor, Threshold = item.Threshold }).ToList();
        }

        public SearchResultModel Search(string watchlistId, string photo, int threshold = 40, int minFaceSize = 35, int maxFaceSize = 600)
        {
            _logger.Trace("Search - call");

            var searchResult = _client.Search(watchlistId, photo, threshold, minFaceSize, maxFaceSize);

            var result = new SearchResultModel();

            foreach (var sr in searchResult)
            {
                foreach (var match in sr.MatchResults)
                {
                    result.Results.Add(new ResultModel(sr, match.FullName, match.WatchlistFullName));
                }
            }

            return result;
        }
    }
}
