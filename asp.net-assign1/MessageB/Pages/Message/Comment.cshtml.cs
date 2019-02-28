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
    public class CommentModel : PageModel
    {
        private readonly IMessages messageDatas;

        [BindProperty]
        public Messages M { get; set; }


        public CommentModel(IMessages messageDatas)
        {
            this.messageDatas = messageDatas;
        }
       public IActionResult OnGet(int  messageId)
        {
           
                M = messageDatas.GetById(messageId);
            
         
            if (M == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }

        public IActionResult OnPost()
        {

            var m= messageDatas.Update(M);
            messageDatas.Commit();


            
            
            

            return RedirectToPage("./Detail", new { messageId = M.Id });

        }
        
    }
}