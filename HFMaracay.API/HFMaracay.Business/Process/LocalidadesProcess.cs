using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFMaracay.Entities;
namespace HFMaracay.Business.Process
{
    public class LocalidadesProcess : Process, ILocalidadesProcess
    {
        public List<Localidad> ListAll()
        {
            return Context.Localidades.ToList();
        }

        public Localidad ListById(int id)
        {
            return Context.Localidades.FirstOrDefault(x => x.Id == id);
        }

        public Localidad GetByDescripcion(string nombre)
        {
            return Context.Localidades.FirstOrDefault(x => x.Nombre == nombre);
        }

        public Localidad Save(Localidad item)
        {
            if (item.Id != null && item.Id != 0)
            {
                Context.Localidades.Attach(item);
            }
            else
            {
                Context.Localidades.Add(item);
            }
            Context.SaveChanges();
            return item;
        }

        public void DeleteByID(int id)
        {
            Context.Remove(Context.Localidades.Single(a => a.Id == id));
            Context.SaveChanges();
        }
    }
}
