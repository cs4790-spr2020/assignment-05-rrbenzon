using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlabberApp.Services;
using BlabberApp.Domain.Entities;
using System.IO;


namespace BlabberApp.Client.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _service;
        public RegisterModel(IUserService service)
        {
            _service = service;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var email = Request.Form["emailaddress"];
            try
            {
                _service.AddNewUser(email);
                return new RedirectToPageResult("Users");
            }catch(Exception ex)
            {
                //throw new Exception(e.ToString());
                string path = Directory.GetCurrentDirectory();
                path = path + "/Pages/Shared";
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "ErrorLog.txt"), true))
                {
                    outputFile.WriteLine(DateTime.Now + "- FeedModel::OnPost: " + ex.ToString());
                }

                return new RedirectToPageResult("Register");
            }
        }
    }
}