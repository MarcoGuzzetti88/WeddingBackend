using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Backend.BLL.Generic
{
    public interface IWrite<T>
    {
        T Save(T obj);
    }
}