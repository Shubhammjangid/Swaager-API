using NS.EMS.DATABASE.Entities;
using NS.EMS.LOGINREPO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.EMS.LOGINBUSSINESS
{
    public class LoginBussiness: ILoginBussiness
    {
        private readonly ILoginRepo _LoginRepo;
        public LoginBussiness(ILoginRepo LoginRepo)
        {
            _LoginRepo = LoginRepo;
        }
        public string GetLogin(Login login)
        {
            
            return _LoginRepo.GetLogin(login);
        }
    }
}
