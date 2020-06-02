using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wedding.Backend.BLL.Generic;
using Wedding.Backend.DAL.Models;
using Wedding.Backend.Domain;

namespace Wedding.Backend.DAL.Repository
{
    public class ContributionRepository : IReadAll<Domain.Contribution>, IWrite<Domain.Contribution>
    {
        private readonly Context context;

        public ContributionRepository(Context context)
        {
            this.context = context;
        }

        public IEnumerable<Domain.Contribution> GetAll()
        {
            var contribution = context.Contribution.Select(c => new Domain.Contribution
            {
                ContributionValue = c.Contribution1,
                ContributorId = c.ContributorId,
                Id = c.Id,
                Message = c.Message,
                PackageId = c.PackageId
            }).ToList();

            return contribution;
        }

        public Domain.Contribution Save(Domain.Contribution obj)
        {
            var contributionDb = new Models.Contribution
            {
                Contribution1 = obj.ContributionValue,
                ContributorId = obj.ContributorId,
                Message = obj.Message,
                PackageId = obj.PackageId
            };

            context.Contribution.Add(contributionDb);
            context.SaveChanges();

            obj.Id = contributionDb.Id;

            return obj;
        }
    }
}