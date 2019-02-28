using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Message.Core;
using Message.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace MessageB.Pages.Message
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMessages message;
        public IEnumerable<Messages> Mess { get; set; }
        Messages m = new Messages();
        public static int count = 0;

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }
        public ListModel(IConfiguration config, IMessages message)
        {
            this.config = config;
            this.message = message;
        }



        public void OnGet(int messageId)
        {

            Mess = message.GetMessageByName(SearchValue);

        }


        public IActionResult OnPost(Messages Mess)
        {
            var m= message.UpdateLike(Mess);

            message.Commit();



            return RedirectToPage("./List",new { messageId = m.Id }) ;

        }
    }
}