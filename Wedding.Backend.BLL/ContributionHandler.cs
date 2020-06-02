using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Backend.BLL.Generic;
using Wedding.Backend.Domain;

namespace Wedding.Backend.BLL
{
    public class ContributionHandler : IContributionHandler
    {
        private readonly IContributorHandler contributorHandler;
        private readonly IWrite<Contribution> contributionWriter;
        private readonly IEmailSender emailSender;
        private readonly IWeddingMailHandler weddingMailHandler;

        public ContributionHandler(
            IContributorHandler contributorHandler,
            IWrite<Domain.Contribution> contributionWriter,
            IEmailSender emailSender,
            IWeddingMailHandler emailBodyHandler)
        {
            this.contributorHandler = contributorHandler;
            this.contributionWriter = contributionWriter;
            this.emailSender = emailSender;
            this.weddingMailHandler = emailBodyHandler;
        }

        public Contribution Contribute(int packageId, string contributorEmail, string message, float contribuitionValue)
        {
            var contributor = contributorHandler.GetOrInsert(new Contributor
            {
                Email = contributorEmail
            });

            var contribute = new Contribution
            {
                ContributorId = contributor.Id,
                PackageId = packageId,
                Message = message,
                ContributionValue = contribuitionValue
            };

            var savedContribution = contributionWriter.Save(contribute);

            emailSender.Send(new Email
            {
                To = contributorEmail,
                Message = weddingMailHandler.Generate(),
                Ccn = weddingMailHandler.GenerateCcn(),
                From = weddingMailHandler.FromUser(),
                Subject = weddingMailHandler.GenerateSubject()
            });

            return savedContribution;
        }
    }
}