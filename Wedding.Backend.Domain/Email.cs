using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Backend.Domain
{
    public class Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public IEnumerable<string> Ccn { get; set; }
        public string Message { get; set; }
    }
}