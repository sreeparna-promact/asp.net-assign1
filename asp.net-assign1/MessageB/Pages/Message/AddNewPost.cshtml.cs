using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Message.Core;
using Message.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessageB.Pages.Message
{
    public class AddNewPostModel : PageModel
    {
        private readonly IMessages messageDatas;

        [BindProperty]
        public Messages M { get; set; }


        public AddNewPostModel(IMessages messageDatas)
        {
            this.messageDatas = messageDatas;
        }
        public IActionResult OnGet(int? messageId)
        {
            if (messageId.HasValue)
            {
                M = messageDatas.GetById(messageId.Value);
            }
            else
            {
                M = new Messages();
            }
            if(M==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }

        public IActionResult OnPost()
        {   if (M.Id > 0)
            {
                M = messageDatas.Update(M);
            }
            else
            {
                M = messageDatas.Add(M);
            }
            messageDatas.Commit();
            
            return RedirectToPage("./Detail",new { messageId = M.Id }) ;

        }
    }
}