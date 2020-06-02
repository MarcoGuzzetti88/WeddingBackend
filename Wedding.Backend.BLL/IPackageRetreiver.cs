using System.Collections.Generic;

namespace Wedding.Backend.BLL
{
    public interface IPackageRetreiver
    {
        IEnumerable<Domain.Package> GetAll();
    }
}