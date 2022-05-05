using InnovatricsDemo.Models;
using InnovatricsDemo.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;
using System;

namespace InnovatricsDemo.Pages
{
    public class AddWatchListModel : PageModel
    {
        private readonly Logger _logger;
        private readonly IWatchlistService _watchlistService;

        public AddWatchListModel(Logger logger, IWatchlistService watchlistService)
        {
            _logger = logger;
            _watchlistService = watchlistService;
        }

        public void OnPost()
        {
            _logger.Trace("OnPost - call");

            if (ModelState.IsValid)
            {
                try
                {
                    WachlistModel model = new WachlistModel
                    {
                        DisplayName = Request.Form["DisplayName"],
                        FullName = Request.Form["FullName"],
                        Threshold = Convert.ToInt32(Request.Form["Threshold"]),
                        PreviewColor = Request.Form["PreviewColor"]
                    };

                    _watchlistService.AddWatchlist(model);

                    ViewData["result"] = "Watchlist added";

                    _logger.Info("Watchlist added");
                }
                catch (Exception ex)
                {
                    ViewData["result"] = "Failed to add watchlist";
                    
                    _logger.Error(ex, "Failed to add watchlist");
                    _logger.Info("Failed to add watchlist");
                }


            }
            else
            {
                ViewData["result"] = "Data are invalid.";
            }
        }
    }
}
