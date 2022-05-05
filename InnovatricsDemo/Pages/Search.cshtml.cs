using InnovatricsDemo.Models;
using InnovatricsDemo.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InnovatricsDemo.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IWatchlistService _watchlistService;
        private readonly Logger _logger;

        [BindProperty]
        public IFormFile Upload { get; set; }

        public IList<SelectListItem> Options { get; set; } = new List<SelectListItem>();
        public IList<ResultModel> Results { get; set; } = new List<ResultModel>();

        public SearchModel(Logger logger, IWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
            _logger = logger;

            GetWatchList();
        }

        public void OnPost()
        {
            _logger.Trace("OnPost -call");

            if (ModelState.IsValid)
            {
                try
                {
                    var model = new SearchRequestModel
                    {
                        WatchlistId = Request.Form["watchlistId"],
                        Threshold = Convert.ToInt32(Request.Form["threshold"]),
                        MinFaceSize = Convert.ToInt32(Request.Form["minFaceSize"]),
                        MaxFaceSize = Convert.ToInt32(Request.Form["maxFaceSize"]),
                        Photo = ReadPhoto("uploads", Request.Form.Files[0])
                    };


                    var result = _watchlistService.Search(model.WatchlistId, model.Photo, model.Threshold, model.MinFaceSize, model.MaxFaceSize);
                    Results = result.Results;

                    _logger.Info("Got search results.");
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Search in watchlist failed");
                    ViewData["result"] = String.Format("Failed to search.");
                }
            }
            else
            {
                ViewData["result"] = "Data are invalid.";
            }
        }

        #region private methods
        private string ReadPhoto(string folder, IFormFile formFile)
        {
            _logger.Trace("ReadPhoto - call");
            _logger.Debug("folder: {folder}, formfile {@formFile}", folder, formFile);

            string faceImage = string.Empty;
            try
            {
                using var memoryStrean = new MemoryStream();
                formFile.CopyTo(memoryStrean);

                faceImage = Convert.ToBase64String(memoryStrean.ToArray());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to read image");

            }
            return faceImage;
        }

        private void GetWatchList()
        {
            _logger.Trace("GetWatchList - call");

            var items = _watchlistService.GetWatchlists();

            Options = items.Select(a => new SelectListItem
            {
                Value = a.Id,
                Text = a.FullName
            }).OrderBy(i => i.Text).ToList();

            Options.Insert(0, new SelectListItem { Value = "all", Text = "All" });
        }

        #endregion
    }
}
