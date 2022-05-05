using InnovatricsDemo.SmartfaceClient;
using InnovatricsDemo.SmartfaceClient.Models;
using NLog;
using System.Collections.Generic;

namespace InnovatricsDemo.Services
{
    public interface IWatchlistMemberService
    {
        WatchlistMemberResponse CreateWatchListMember(string displayName, string fullName, string note = null);

        void LinkToWatchlist(string watchlistId, List<string> watchlistMembersIds);
        Face AddNewFace(string watchlistMembersId, string photo);
    }

    public class WatchlistMemberService : IWatchlistMemberService
    {
        private readonly Logger _logger;
        private readonly WatchlistMemberClient _client;

        public WatchlistMemberService(Logger logger)
        {
            _logger = logger;
            _client = new WatchlistMemberClient(_logger);
            
            _logger.Trace("WatchlistMemberService - ctor");
        }

        public Face AddNewFace(string watchlistMembersId, string photo)
        {
            _logger.Trace("AddNewFace - call");

            return _client.AddNewFace(watchlistMembersId, photo);
        }

        public WatchlistMemberResponse CreateWatchListMember(string displayName, string fullName, string note = null)
        {
            _logger.Trace("CreateWatchListMember - call");

            return _client.CreateWatchListMember(displayName, fullName, note);
        }

        public void LinkToWatchlist(string watchlistId, List<string> watchlistMembersIds)
        {
            _logger.Trace("LinkToWatchlist - call");

            _client.LinkToWatchlist(watchlistId, watchlistMembersIds);
        }
    }
}
