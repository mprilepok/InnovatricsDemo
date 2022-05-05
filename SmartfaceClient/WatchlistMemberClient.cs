using InnovatricsDemo.SmartfaceClient.Models;
using Newtonsoft.Json;
using NLog;
using RestSharp;
using SmartfaceClient;
using System;
using System.Collections.Generic;

namespace InnovatricsDemo.SmartfaceClient
{
    public class WatchlistMemberClient : BaseClient
    {
        public WatchlistMemberClient(Logger logger) : base(logger)
        {

            _logger.Trace("WatchlistMemberClient - ctor");
        }

        public WatchlistMemberResponse CreateWatchListMember(string displayName, string fullName, string note)
        {
            _logger.Trace("GetWatchlists - call");
            _logger.Debug("dispalayName: {dispalayName}, fullName: {fullName}, note {note}", displayName, fullName, note);

            WatchlistMemberResponse result;
            try
            {
                var body = new WatchlistMemberRequest { DisplayName = displayName, FullName = fullName, Note = note };
                var jsonBody = JsonConvert.SerializeObject(body);

                var request = new RestRequest("api/v1/WatchlistMembers", Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddBody(jsonBody, "application/json");

                _logger.Debug("Request {@request}", request);

                var response = _client.ExecuteAsync(request).Result;

                if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    result = JsonConvert.DeserializeObject<WatchlistMemberResponse>(response.Content);

                    _logger.Info("Created watchlist member");

                    return result;
                }
                else
                {
                    _logger.Error("CreateWatchListMember - {code} - {problem}", response.StatusCode, response.Content);

                    throw new Exception($"CreateWatchListMember -{response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "CreateWatchListMember - error occured");

                throw new Exception("Error occured during creating watchlist member", ex);
            }
        }

        public Face AddNewFace(string watchlistMembersId, string photo)
        {
            _logger.Trace("AddNewFace - call");
            _logger.Debug("watchlistMembersId: {watchlistMembersId}, photo: {@photo}", watchlistMembersId, photo);

            Face result;
            try
            {
                var body = new AddNewFaceRequest();
                body.ImageData.Data = photo;

                var jsonBody = JsonConvert.SerializeObject(body);

                var request = new RestRequest($"/api/v1/WatchlistMembers/{watchlistMembersId}/AddNewFace", Method.Post);
                request.AddHeader("accept", "*/*");
                request.AddBody(jsonBody, "application/json");
                request.Timeout = -1;

                _logger.Debug("Request {@request}", request);

                var response = _client.ExecuteAsync(request).Result;

                if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    _logger.Info("Add new face done");
                    result = JsonConvert.DeserializeObject<Face>(response.Content);
                    return result;
                }
                else
                {
                    _logger.Error("AddNewFace - {code} - {problem}", response.StatusCode, response.Content);

                    throw new Exception($"AddNewFace - {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "AddNewFace - error occured");

                throw new Exception("Error occured during adding new face", ex);
            }
        }

        public void LinkToWatchlist(string watchlistId, List<string> watchlistMembersIds)
        {
            _logger.Trace("LinkToWatchlist - call");
            _logger.Debug("watchlistId: {watchlistId}, watchlistMembersIds: {@watchlistMembersIds}", watchlistId, watchlistMembersIds);

            try
            {
                var body = new WatchlistMembersLinkRequest { WatchlistId = watchlistId, WatchlistMembersIds = watchlistMembersIds };
                var jsonBody = JsonConvert.SerializeObject(body);

                var request = new RestRequest("api/v1/WatchlistMembers/LinkToWatchlist", Method.Post);
                request.AddHeader("accept", "*/*");
                request.AddBody(jsonBody, "application/json");

                _logger.Debug("Request {@request}", request);

                var response = _client.ExecuteAsync(request).Result;

                if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    _logger.Info("Link to watchlist done");
                    return;
                }
                else
                {
                    _logger.Error("LinkToWatchlist - {code} - {problem}", response.StatusCode, response.Content);

                    throw new Exception($"LinkToWatchlist - {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "LinkToWatchlist - error occured");

                throw new Exception("Error occured during linking to watchlist", ex);
            }
        }
    }
}
