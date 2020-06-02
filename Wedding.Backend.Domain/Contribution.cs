using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Backend.Domain
{
    public class Contribution
    {
        public int Id { get; set; }
        public int ContributorId { get; set; }
        public int PackageId { get; set; }
        public float ContributionValue { get; set; }
        public string Message { get; set; }
    }
}