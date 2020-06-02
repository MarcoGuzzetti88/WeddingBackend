using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Backend.BLL
{
    public class WeddingMailHandler : IWeddingMailHandler
    {
        public WeddingMailHandler()
        {
        }

        public string FromUser()
        {
            return "marco.guzzetti88@gmail.com";
        }

        public string Generate()
        {
            return "TEST";
        }

        public IEnumerable<string> GenerateCcn()
        {
            return new List<string>();
        }

        public string GenerateSubject()
        {
            return "TEST";
        }
    }
}