using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wedding.Backend.BLL.Generic;
using Wedding.Backend.DAL.Models;

namespace Wedding.Backend.DAL.Repository
{
    public class ContributorRepository : IRead<Domain.Contributor, string>, IWrite<Domain.Contributor>
    {
        private readonly Context context;

        public ContributorRepository(Context context)
        {
            this.context = context;
        }

        public Domain.Contributor Read(string key)
        {
            var contributor = context.Contributor.FirstOrDefault(i => i.Email.ToUpper() == key.ToUpper());

            if (contributor == null)
                return null;

            return new Domain.Contributor
            {
                Email = contributor.Email,
                Id = contributor.Id
            };
        }

        public Domain.Contributor Save(Domain.Contributor obj)
        {
            var contributorDb = new Contributor
            {
                Email = obj.Email
            };

            context.Contributor.Add(contributorDb);
            context.SaveChanges();

            obj.Id = contributorDb.Id;

            return obj;
        }
    }
}