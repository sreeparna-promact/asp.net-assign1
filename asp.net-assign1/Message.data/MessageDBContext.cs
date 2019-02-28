using Message.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Message.data
{
   public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options)
            :base(options)
        {

        }
        public DbSet<Messages> Messages { get; set; }

    }
}
