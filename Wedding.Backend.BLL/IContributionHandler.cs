namespace Wedding.Backend.BLL
{
    public interface IContributionHandler
    {
        Domain.Contribution Contribute(int packageId, string contributorEmail, string message, float contribuitionValue);
    }
}