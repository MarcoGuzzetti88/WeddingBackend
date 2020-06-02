using System;
using System.Collections.Generic;

namespace Wedding.Backend.DAL.Models
{
    public partial class Package
    {
        public Package()
        {
            Contribution = new HashSet<Contribution>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public float TotalPrice { get; set; }
        public float TotalPaid { get; set; }
        public string Thumbnail { get; set; }

        public virtual ICollection<Contribution> Contribution { get; set; }
    }
}
