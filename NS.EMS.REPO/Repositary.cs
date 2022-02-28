using NS.EMS.DATABASE.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NS.EMS.MODEL;
using Microsoft.EntityFrameworkCore;

namespace NS.EMS.REPO
{
    public class Repositary: IRepositary
    {
        public List<Information> GetInformation()
        {
            var InfoList = new List<Information>();
            using (var context = new UPSContext())
            {
                InfoList = context.Information.ToList();
            }

            return InfoList;
        }
        public Information DetailId(int id)
        {
            var Info = new Information();
            using (var context = new UPSContext())
            {
                Info = context.Information.Find(id);
            }
            return Info;
        }

        public bool AddInformation(Model model)
        {
            using(var context = new UPSContext())
            {
                Information information =new Information();
                information.Name = model.Name;
                information.Email = model.Email;
                information.Gender=model.Gender;
                context.Information.Add(information);
                context.SaveChanges();
            }

            return true;
        }

        public bool Update(Information info)
        {
            using (var context = new UPSContext())
            {
                context.Entry(info).State = EntityState.Modified;
                context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int id)
        {
            using(var context = new UPSContext())
            {
                Information information = new Information();
                information = context.Information.Where(x => x.Id == id).FirstOrDefault();
                context.Information.Remove(information);
            }
            return true;
        }
    }

    
}
