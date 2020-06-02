using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Backend.BLL.Generic;
using Wedding.Backend.Domain;

namespace Wedding.Backend.BLL
{
    public class ContributorHandler : IContributorHandler
    {
        private readonly IRead<Contributor, string> contributorReader;
        private readonly IWrite<Contributor> contributorWriter;

        public ContributorHandler(IRead<Domain.Contributor, string> contributorReader, IWrite<Domain.Contributor> contributorWriter)
        {
            this.contributorReader = contributorReader;
            this.contributorWriter = contributorWriter;
        }

        public Contributor GetOrInsert(Contributor contributor)
        {
            var contributorSaved = contributorReader.Read(contributor.Email);
            if (contributorSaved is null)
                contributorSaved = contributorWriter.Save(contributor);

            return contributorSaved;
        }
    }
}