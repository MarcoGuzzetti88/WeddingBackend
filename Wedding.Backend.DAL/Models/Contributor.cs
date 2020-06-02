using System;
using System.Collections.Generic;

namespace Wedding.Backend.DAL.Models
{
    public partial class Contributor
    {
        public Contributor()
        {
            Contribution = new HashSet<Contribution>();
        }

        public int Id { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Contribution> Contribution { get; set; }
    }
}
