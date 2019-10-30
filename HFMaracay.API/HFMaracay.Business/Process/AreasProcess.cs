using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFMaracay.Entities;
namespace HFMaracay.Business.Process
{
    public class AreasProcess : Process, IAreasProcess
    {
        public List<Areas> ListAll()
        {
            return Context.Areas.ToList();
        }

        public Areas ListById(int id)
        {
            return Context.Areas.FirstOrDefault(x => x.Id == id);
        }

        public Areas GetByDescripcion(string Descripcion)
        {
            return Context.Areas.FirstOrDefault(x => x.Descripcion == Descripcion);
        }

        public Areas Save(Areas item)
        {
            if (item.Id != null && item.Id!=0)
            {
                Context.Areas.Attach(item);
            }
            else
            {
                Context.Areas.Add(item);
            }
            Context.SaveChanges();
            return item;
        }

        public void DeleteByID(int id)
        {
            Context.Remove(Context.Areas.Single(a => a.Id == id));
            Context.SaveChanges();
        }
    }
}
