using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFMaracay.Entities;
namespace HFMaracay.Business.Process
{
    public class EventosProcess : Process, IEventosProcess
    {
        public List<Eventos> ListAll()
        {
            return Context.Eventos.ToList();
        }

        public Eventos ListById(int id)
        {
            return Context.Eventos.FirstOrDefault(x => x.Id == id);
        }

        public Eventos Save(Eventos item)
        {
            if (item.Id != null && item.Id != 0)
            {
                Context.Eventos.Attach(item);
            }
            else
            {
                Context.Eventos.Add(item);
            }
            Context.SaveChanges();
            return item;
        }

        public void DeleteByID(int id)
        {
            Context.Remove(Context.Eventos.Single(a => a.Id == id));
            Context.SaveChanges();
        }


    }
}
