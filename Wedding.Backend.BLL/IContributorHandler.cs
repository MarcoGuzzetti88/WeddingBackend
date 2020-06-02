namespace Wedding.Backend.BLL
{
    public interface IContributorHandler
    {
        Domain.Contributor GetOrInsert(Domain.Contributor contributor);
    }
}