using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wedding.Backend.Api.Models
{
    public abstract class Response
    {
        public bool Success { get; set; }
    }
}