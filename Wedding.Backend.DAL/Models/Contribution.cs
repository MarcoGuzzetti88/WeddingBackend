using System;
using System.Collections.Generic;

namespace Wedding.Backend.DAL.Models
{
    public partial class Contribution
    {
        public int Id { get; set; }
        public int ContributorId { get; set; }
        public int PackageId { get; set; }
        public float Contribution1 { get; set; }
        public string Message { get; set; }

        public virtual Contributor Contributor { get; set; }
        public virtual Package Package { get; set; }
    }
}
