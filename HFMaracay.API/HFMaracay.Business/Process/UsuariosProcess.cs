using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFMaracay.Entities;
namespace HFMaracay.Business.Process
{
    public class UsuariosProcess : Process, IUsuariosProcess
    {
        public List<Usuarios> ListAll()
        {
            return Context.Usuarios.ToList();
        }

        public Usuarios ListUsersById(int id)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public Usuarios GetUsersByName(string name)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Nombre == name && !x.IsDeleted);
        }

        public Usuarios GetUsersByEmail(string email)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Email == email && !x.IsDeleted);
        }

        public Usuarios Save(Usuarios usuario)
        {
            if (usuario.Id != null && usuario.Id != 0)
            {
                Context.Usuarios.Attach(usuario);
            }
            else
            {
                Context.Usuarios.Add(usuario);
            }
            Context.SaveChanges();
            return usuario;
        }

        public void DeleteByID(int id)
        {
            Context.Remove(Context.Usuarios.Single(a => a.Id == id));
            Context.SaveChanges();
        }

        public void DeleteUserByEmail(string email)
        {
            Context.Remove(Context.Usuarios.Single(a => a.Email == email));
            Context.SaveChanges();
        }
        public void SoftDeleteByEmail(Usuarios item )
        {
            item.DateUpd = DateTime.Now;
            if (item != null && item.Id != null && item.Id != 0)
            {
                Context.Usuarios.Attach(item);
                item.IsDeleted = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(item.Email))
                {
                    var Area = Context.Usuarios.FirstOrDefault(x => x.Email == item.Email);
                    Area.IsDeleted = true;
                }
            }
            Context.SaveChanges();
        }
        public void SoftDeleteByID(Usuarios item = null, int id = 0)
        {
            item.DateUpd = DateTime.Now;
            if (item != null && item.Id != null && item.Id != 0)
            {
                Context.Usuarios.Attach(item);
                item.IsDeleted = true;
            }
            else
            {
                if (id != 0)
                {
                    var Area = Context.Usuarios.FirstOrDefault(x => x.Id == id);
                    Area.IsDeleted = true;
                }
            }
            Context.SaveChanges();
        }
    }
}
