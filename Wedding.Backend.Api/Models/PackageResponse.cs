using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wedding.Backend.Domain;

namespace Wedding.Backend.Api.Models
{
    public class PackageResponse : Response
    {
        public IEnumerable<Package> Data { get; set; }
    }
}