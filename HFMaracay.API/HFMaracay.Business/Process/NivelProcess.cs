using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFMaracay.Entities;
namespace HFMaracay.Business.Process
{
    public class NivelProcess : Process, INivelProcess
    {
        public List<Nivel> ListAll()
        {
            return Context.Niveles.ToList();
        }

        public Nivel ListById(int id)
        {
            return Context.Niveles.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public Nivel GetByDescripcion(string Descripcion)
        {
            return Context.Niveles.FirstOrDefault(x => x.Descripcion == Descripcion && !x.IsDeleted);
        }

        public Nivel Save(Nivel item)
        {
            if (item.Id != null && item.Id != 0)
            {
                Context.Niveles.Attach(item);
            }
            else
            {
                Context.Niveles.Add(item);
            }
            Context.SaveChanges();
            return item;
        }

        public void DeleteByID(int id)
        {
            Context.Remove(Context.Niveles.Single(a => a.Id == id));
            Context.SaveChanges();
        }

        public void SoftDeleteByID(Nivel item )
        {
            item.DateUpd = DateTime.Now;
        
                if (item.Id != 0)
                {
                    var Data = Context.Niveles.FirstOrDefault(x => x.Id == item.Id);
                Data.IsDeleted = true;
                }
     
            Context.SaveChanges();
        }
    }
}
