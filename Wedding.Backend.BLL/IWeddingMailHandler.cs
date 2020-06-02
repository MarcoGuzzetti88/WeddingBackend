using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Backend.BLL
{
    public interface IWeddingMailHandler
    {
        string Generate();

        IEnumerable<string> GenerateCcn();

        string GenerateSubject();

        string FromUser();
    }
}