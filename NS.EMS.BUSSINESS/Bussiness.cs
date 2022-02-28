using NS.EMS.DATABASE.Entities;
using NS.EMS.MODEL;
using NS.EMS.REPO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.EMS.BUSSINESS
{
    public class Bussiness:IBussiness
    {
        private readonly IRepositary _Repositary;
        public Bussiness(IRepositary Repositary)
        {
            _Repositary = Repositary;
        }
        public List<Information> GetInformation()
        {
            return _Repositary.GetInformation();
        }

        public Information DetailId(int id)
        {
            return _Repositary.DetailId(id);
        }

        public bool AddInformation(Model model)
        {
            return _Repositary.AddInformation(model);
        }

        public bool Update(Information info)
        {
            return _Repositary.Update( info);
        }

        public bool Delete(int id)
        {
            return _Repositary.Delete(id);
        }
    }
}
