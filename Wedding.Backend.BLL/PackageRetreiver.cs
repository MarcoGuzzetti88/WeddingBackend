using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wedding.Backend.BLL.Generic;
using Wedding.Backend.Domain;

namespace Wedding.Backend.BLL
{
    public class PackageRetreiver : IPackageRetreiver
    {
        private readonly IReadAll<Package> packageReader;
        private readonly IReadAll<Contribution> contributionReader;

        public PackageRetreiver(IReadAll<Domain.Package> packageReader, IReadAll<Contribution> contributionReader)
        {
            this.packageReader = packageReader;
            this.contributionReader = contributionReader;
        }

        public IEnumerable<Package> GetAll()
        {
            var repositoryPackages = packageReader.GetAll();
            var contributions = contributionReader.GetAll();

            foreach (var package in repositoryPackages)
            {
                var packageContribution = contributions.Where(i => i.PackageId == package._id).ToList();
                package.TotalPaid = packageContribution.Sum(i => i.ContributionValue);
                package.Median = new List<float> { 0, package.TotalPrice - package.TotalPaid }.Average();
                package.Rest = package.TotalPrice - package.TotalPaid;
                package.Soldout = package.TotalPaid == package.TotalPrice;
            }

            return repositoryPackages;
        }
    }
}