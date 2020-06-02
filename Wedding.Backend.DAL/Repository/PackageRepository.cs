using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wedding.Backend.BLL.Generic;
using Wedding.Backend.DAL.Models;
using Wedding.Backend.Domain;

namespace Wedding.Backend.DAL.Repository
{
    public class PackageRepository : IReadAll<Domain.Package>
    {
        private readonly Context context;

        public PackageRepository(Context context)
        {
            this.context = context;
        }

        public IEnumerable<Domain.Package> GetAll()
        {
            var packages = context.Package.Select(i => new Domain.Package
            {
                _id = i.Id,
                TotalPrice = i.TotalPrice,
                Title = i.Title,
                Thumbnail = i.Thumbnail,
                Contributors = i.Contribution.Select(j => j.Contributor).Select(c => new Domain.Contributor { Email = c.Email }).ToList()
            }).ToList();

            return packages;
        }
    }
}