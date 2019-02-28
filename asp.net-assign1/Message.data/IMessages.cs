using System.Collections.Generic;
using System.Text;
using Message.Core;

namespace Message.data
{
    public  interface IMessages
    {
        
        IEnumerable<Messages> GetMessageByName(string searchValue);
         Messages GetById(int Id);
        Messages Update(Messages updateMessage);
        Messages UpdateLike(Messages updateLike);
       // Messages UpdateComment(Messages newComment);
        Messages  Add(Messages newMessage);
      //  Messages Like(Messages newLike);
        int Commit();
        
    }
}
