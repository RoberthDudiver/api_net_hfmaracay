﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFMaracay.Entities;
namespace HFMaracay.Business.Process
{
    public class TipoLocalidadesProcess : Process, ITipoLocalidadesProcess
    {
        public List<TipoLocalidades> ListAll()
        {
            return Context.TipoLocalidades.ToList();
        }

        public TipoLocalidades ListById(int id)
        {
            return Context.TipoLocalidades.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public TipoLocalidades GetByNombre(string nombre)
        {
            return Context.TipoLocalidades.FirstOrDefault(x => x.Nombre == nombre && !x.IsDeleted);
        }

        public TipoLocalidades Save(TipoLocalidades item)
        {
            if (item.Id != null && item.Id != 0)
            { 
                Context.TipoLocalidades.Attach(item);
            }
            else
            {
                Context.TipoLocalidades.Add(item);
            }
            Context.SaveChanges();
            return item;
        }
        public void SoftDeleteByID(TipoLocalidades item )
        {
            item.DateUpd = DateTime.Now;
            if (item != null && item.Id != null && item.Id != 0)
            {
                Context.TipoLocalidades.Attach(item);
                item.IsDeleted = true;
            }
            else
            {
                if (item.Id != 0)
                {
                    var Area = Context.TipoLocalidades.FirstOrDefault(x => x.Id == item.Id);
                    Area.IsDeleted = true;
                }
            }
            Context.SaveChanges();
        }
        public void DeleteByID(int id)
        {
            Context.Remove(Context.TipoLocalidades.Single(a => a.Id == id));
            Context.SaveChanges();
        }
    }
}
