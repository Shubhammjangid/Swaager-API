using NS.EMS.DATABASE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.EMS.LOGINREPO
{
    public interface ILoginRepo
    {
        string GetLogin(Login login);
    }
}
