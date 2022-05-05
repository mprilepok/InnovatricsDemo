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
    public class AddMemberModel : PageModel
    {
        private readonly IWatchlistMemberService _watchlistMemberService;
        private readonly IWatchlistService _watchlistService;
        private readonly Logger _logger;

        [BindProperty]
        public IFormFile Upload { get; set; }
        public List<SelectListItem> Options { get; set; }

        public AddMemberModel(Logger logger, IWatchlistMemberService watchlistMemberService, IWatchlistService watchlistService)
        {
            _logger = logger;
            _watchlistMemberService = watchlistMemberService;
            _watchlistService = watchlistService;

            GetWatchList();
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                var model = new MemberModel
                {
                    Name = Request.Form["Name"],
                    WatchListId = Request.Form["watchListId"],
                    Photo = ReadPhoto("uploads", Request.Form.Files[0])
                };

                try
                {
                    var member = _watchlistMemberService.CreateWatchListMember(model.Name, model.Name);

                    _watchlistMemberService.LinkToWatchlist(model.WatchListId, new List<string> { member.Id });

                    _watchlistMemberService.AddNewFace(member.Id, model.Photo);

                    ViewData["result"] = String.Format("Member added to {0} watch list.", GetWatchListName(model.WatchListId));

                    _logger.Info("Member added to watch list");

                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Create watch list member failed");
                    ViewData["result"] = String.Format("Failed to added member to {0} watch list.", GetWatchListName(model.WatchListId));
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

        private string GetWatchListName(string watchListId)
        {
            _logger.Trace("GetWatchListName - call");
            _logger.Debug("watchListId: {watchListId}", watchListId);

            return Options.Any() ? Options.First(i => i.Value == watchListId).Text : String.Empty;
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
        }

        #endregion
    }
}
