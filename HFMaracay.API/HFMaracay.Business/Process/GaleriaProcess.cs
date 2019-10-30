using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFMaracay.Entities;
namespace HFMaracay.Business.Process
{
    public class GaleriaProcess : Process, IGaleriaProcess
    {
        public List<Galeria> ListAll()
        {
            return Context.Galeria.ToList();
        }

        public Galeria ListById(int id)
        {
            return Context.Galeria.FirstOrDefault(x => x.Id == id);
        }

        public Galeria Save(Galeria item)
        {
            if (item.Id != null && item.Id != 0)
            {
                Context.Galeria.Attach(item);
            }
            else
            {
                Context.Galeria.Add(item);
            }
            Context.SaveChanges();
            return item;
        }

        public void DeleteByID(int id)
        {
            Context.Remove(Context.Galeria.Single(a => a.Id == id));
            Context.SaveChanges();
        }


    }
}
