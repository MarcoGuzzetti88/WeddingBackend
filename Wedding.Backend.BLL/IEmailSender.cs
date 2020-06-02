using System;
using System.Collections.Generic;
using System.Text;
using Wedding.Backend.Domain;

namespace Wedding.Backend.BLL
{
    public interface IEmailSender
    {
        void Send(Email email);
    }
}