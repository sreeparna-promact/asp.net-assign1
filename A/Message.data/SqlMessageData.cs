using System.Collections.Generic;
using Message.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Message.data
{
    public class SqlMessageData : IMessages
    {
        private readonly MessageDbContext db;
        private readonly Messages com;
        public SqlMessageData(MessageDbContext db)
        {
            this.db = db;
        }
        public Messages Add(Messages newMessage)
        {
            db.Add(newMessage);
            return newMessage;
        }

        public int Commit()
        {
            return db.SaveChanges();

        }

        public Messages GetById(int Id)
        {
            return db.Messages.Find(Id);
        }

        public IEnumerable<Messages> GetMessageByName(string searchValue)
        {
            var query = from m in db.Messages
                        where m.Name.StartsWith(searchValue)
                  || string.IsNullOrEmpty(searchValue)
                        select m;
            return query;
        }

        public Messages Like(Messages newLike)
        {
            throw new System.NotImplementedException();
        }

        public Messages Update(Messages updateMessage)
        {
            var entity = db.Messages.Attach(updateMessage);
            entity.State = EntityState.Modified;
            return updateMessage;
        }

        

        public Messages UpdateLike(Messages updateLike)
        {
            throw new System.NotImplementedException();
        }
    }
}
