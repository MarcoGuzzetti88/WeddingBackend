using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Backend.BLL.Generic
{
    public interface IRead<T, K>
    {
        T Read(K key);
    }
}