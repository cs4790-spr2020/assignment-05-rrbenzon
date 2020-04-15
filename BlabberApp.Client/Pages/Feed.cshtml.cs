using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlabberApp.Domain.Entities;
using BlabberApp.Services;
using System.IO;

namespace BlabberApp.Client.Pages
{
    public class FeedModel : PageModel
    {
        private readonly IBlabService _serviceBlab;
        private readonly IUserService _serviceUser;
        public FeedModel(IBlabService serviceBlab, IUserService serviceUser)
        {
            _serviceBlab = serviceBlab;
            _serviceUser = serviceUser;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var email = Request.Form["emailaddress"];
            var message = Request.Form["message"];
            try
            {
                User user = _serviceUser.FindUser(email);
                Blab blab = _serviceBlab.CreateBlab(message, user);
                _serviceBlab.AddBlab(blab);
                return new RedirectToPageResult("Feed");

            }
            catch(Exception ex)
            {
                //throw new Exception("FeedModel::OnPost: " + ex.ToString());

                string path = Directory.GetCurrentDirectory();
                path = path + "/Pages/Shared";
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "ErrorLog.txt"), true))
                {
                    outputFile.WriteLine(DateTime.Now + "- FeedModel::OnPost: " + ex.ToString());
                }

                return new RedirectToPageResult("Feed");
            }
        }
    }
}