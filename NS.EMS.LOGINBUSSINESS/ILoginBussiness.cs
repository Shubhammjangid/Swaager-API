using NS.EMS.DATABASE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.EMS.LOGINBUSSINESS
{
    public interface ILoginBussiness
    {
        string GetLogin(Login login);
    }
}
