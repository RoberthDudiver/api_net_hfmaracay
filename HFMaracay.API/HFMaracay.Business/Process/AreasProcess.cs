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
            return Context.Areas.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public Areas GetByDescripcion(string Descripcion)
        {
            return Context.Areas.FirstOrDefault(x => x.Descripcion == Descripcion && !x.IsDeleted);
        }

        public Areas Save(Areas item)
        {
            item.DateUpd = DateTime.Now;
            if (item.Id != null && item.Id != 0)
            {
                Context.Areas.Attach(item);
            }
            else
            {
                item.DateAdd = DateTime.Now;

                Context.Areas.Add(item);
            }
            Context.SaveChanges();
            return item;
        }
        public void SoftDeleteByID(Areas item)
        {
            item.DateUpd = DateTime.Now;
            if (item != null && item.Id != null && item.Id != 0)
            {
                Context.Areas.Attach(item);
                item.IsDeleted = true;
            }
            else
            {
                if (item.Id != 0)
                {
                    var Area = Context.Areas.FirstOrDefault(x => x.Id == item.Id);
                    Area.IsDeleted = true;
                }
            }
            Context.SaveChanges();
        }
        public void DeleteByID(int id)
        {
            Context.Remove(Context.Areas.Single(a => a.Id == id));
            Context.SaveChanges();
        }
    }
}
