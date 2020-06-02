using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wedding.Backend.Api.Models
{
    public class ContributionModel
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public float Contribution { get; set; }
    }
}