using InnovatricsDemo.SmartfaceClient.Models;
using InnovatricsDemo.SmartfaceClient.Models.Requests;
using Newtonsoft.Json;
using NLog;
using RestSharp;
using SmartfaceClient;
using System;
using System.Collections.Generic;

namespace InnovatricsDemo.SmartfaceClient
{
    public class WatchlistClient : BaseClient
    {
        public WatchlistClient(Logger logger) : base(logger)
        {
            _logger.Trace("WatchlistClient - ctor");
        }

        public WatchlistPagedCollectionResponse GetAllWatchlists()
        {
            _logger.Trace("GetWatchlists - call");

            WatchlistPagedCollectionResponse result;
            try
            {
                var request = new RestRequest("api/v1/Watchlists", Method.Get);
                request.AddHeader("Content-Type", "application/json");
                var response = _client.ExecuteAsync(request).Result;

                if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<WatchlistPagedCollectionResponse>(response.Content);

                    _logger.Info("Got watchlists");

                    return result;
                }
                else
                {
                    _logger.Error("GetWatchlists - {code} - {problem}", response.StatusCode, response.Content);

                    throw new Exception($"GetWatchlists - {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "GetWatchlists - error occured");

                throw new Exception("Error occured during init autenticating", ex);
            }
        }

        public WatchlistResponse AddWatchlist(string displayName, string fullName, int threshold, string previewColor = null)
        {
            _logger.Trace("AddWatchlist - call");
            _logger.Debug("displayName: {displayName}, fullName: {fullName}, threshold {threshold}, previewColor: {previewColor}", displayName, fullName, threshold, previewColor);

            WatchlistResponse result;
            try
            {
                var body = new WatchlistRequests { DisplayName = displayName, FullName = fullName, Threshold = threshold };
                body.PreviewColor = string.IsNullOrEmpty(previewColor) ? null : previewColor;
                var jsonBody = JsonConvert.SerializeObject(body);

                var request = new RestRequest("api/v1/Watchlists", Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddBody(jsonBody, "application/json");

                _logger.Debug("Request {@request}", request);

                var response = _client.ExecuteAsync(request).Result;

                if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    result = JsonConvert.DeserializeObject<WatchlistResponse>(response.Content);

                    _logger.Info("Added watchlist");

                    return result;
                }
                else
                {
                    _logger.Error("AddWatchlist - {code} - {problem}", response.StatusCode, response.Content);

                    throw new Exception($"AddWatchlist - {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "AddWatchlist - error occured");

                throw new Exception("Error occured during adding watchlist", ex);
            }
        }

        public List<SearchInWatchlistResponse> Search(string watchlistId, string photo, int threshold = 40, int minFaceSize = 35, int maxFaceSize = 600)
        {
            _logger.Trace("Search - call");
            _logger.Debug("watchlistId: {watchlistId}, threshold: {threshold}, minFaceSize {minFaceSize}, maxFaceSize: {maxFaceSize}, photo {photo}", watchlistId, threshold, minFaceSize, maxFaceSize, photo);

            List<SearchInWatchlistResponse> result;
            try
            {
                var body = new SearchInWatchlistRequest();
                body.Image.Data = photo;                
                body.Threshold = threshold;
                body.FaceDetectorConfig.MinFaceSize = minFaceSize;
                body.FaceDetectorConfig.MaxFaceSize = maxFaceSize;

                if (watchlistId != "all")
                {
                    body.WatchlistIds.Add(watchlistId);
                }

                var jsonBody = JsonConvert.SerializeObject(body);

                var request = new RestRequest("/api/v1/Watchlists/Search", Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddBody(jsonBody, "application/json");

                _logger.Debug("Request {@request}", request);

                var response = _client.ExecuteAsync(request).Result;

                if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<List<SearchInWatchlistResponse>>(response.Content);

                    _logger.Info("Got search in watchlist result");

                    return result;
                }
                else
                {
                    _logger.Error("Search - {code} - {problem}", response.StatusCode, response.Content);

                    throw new Exception($"Search - {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Search - error occured");

                throw new Exception("Error occured during search");
            }
        }
    }
}
