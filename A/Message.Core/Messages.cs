using System;
using System.Collections.Generic;
using System.Text;

namespace Message.Core
{
    public class Messages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string messageBody{ get; set; }
        public string Date { get; set; }
        public string comment { get; set; }
        public string commenter { get; set; }
        public int like { get; set; }
    }
}