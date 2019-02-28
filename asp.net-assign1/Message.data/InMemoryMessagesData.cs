using System;
using System.Collections.Generic;
using System.Linq;
using Message.Core;

namespace Message.data
{
    public class InMemoryMessagesData : IMessages
    {
        readonly List<Messages> messages;
        public InMemoryMessagesData()
        {
            messages = new List<Messages>
            {
                new Messages {Id=1,Name="Sreeparna",messageBody="I hate you",Date="11th August"},
                new Messages {Id=2,Name="Pia Wurtzbach",messageBody="Miss Universe 2015",Date="12th August"}
            };
        }
      /*  public Messages UpdateComment( Messages newComment)
        {
            var message = messages.SingleOrDefault(m => m.Id == newComment.Id);
            if (message != null)
            {
                message.comment = newComment.comment;
                message.commenter = newComment.commenter;

            }
            return message;
        }*/
        public Messages Add(Messages newMessage)
        {
            messages.Add(newMessage);
            newMessage.Id = messages.Max(m => m.Id)+1;
            return newMessage;
        }
        /* public int Like(Messages newLike)
         {


         }*/
        public Messages UpdateLike(Messages updateLike)
        {
            var message = messages.SingleOrDefault(m => m.Id == updateLike.Id);
            if (message != null)
            {
                message.like+= 1;

            }
            return message;
        }
        public Messages Update(Messages updateMessage)
        {
            var message = messages.SingleOrDefault(m => m.Id == updateMessage.Id);
            if (message != null)
            {
                message.Name = updateMessage.Name;
                message.messageBody = updateMessage.messageBody;
                message.Date = updateMessage.Date;
                
            }
            return message;
        }
        public IEnumerable<Messages> GetMessageByName(string Name)
        {
            return from m in messages
                   where string.IsNullOrEmpty(Name) || m.Name.StartsWith(Name)
                   
                   select m;
        }
        public Messages GetById(int Id)
        {
            return messages.SingleOrDefault(m => m.Id == Id);
        }

       

        public int Commit()
        {
            return 0;
        }

        public Messages Like(Messages newLike)
        {
            throw new NotImplementedException();
        }

        public Messages UpdateComment(Messages newComment)
        {
            throw new NotImplementedException();
        }
    }
}
