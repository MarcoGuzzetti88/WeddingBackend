using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Backend.BLL.Generic
{
    public interface IReadAll<T>
    {
        IEnumerable<T> GetAll();
    }
}