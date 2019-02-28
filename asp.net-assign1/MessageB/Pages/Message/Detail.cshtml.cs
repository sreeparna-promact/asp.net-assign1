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
    public class DetailModel : PageModel
    {
        private readonly IMessages messageData;
       

        public Messages Messages { get; set; }
        public DetailModel(IMessages messageData)
        {
            this.messageData = messageData;
        }
        public IActionResult OnGet(int messageId)
        {
            Messages = messageData.GetById(messageId);
            if(Messages==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
            
        }
        public IActionResult OnPost()
        {
            Messages.like += 1;
            var m = messageData.Update(Messages);
            messageData.Commit();

            
           






            return RedirectToPage("./Detail", new { messageId = m.Id });

        }

    }
}