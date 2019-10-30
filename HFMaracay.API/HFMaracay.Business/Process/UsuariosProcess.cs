using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFMaracay.Entities;
namespace HFMaracay.Business.Process
{
    public class UsuariosProcess : Process, IUsuariosProcess
    {
        public List<Usuarios> ListAllUsers()
        {
            return Context.Usuarios.ToList();
        }

        public Usuarios ListUsersById(int id)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public Usuarios GetUsersByName(string name)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Nombre == name);
        }

        public Usuarios GetUsersByEmail(string email)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Email == email);
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

        public void DeleteUserByID(int id)
        {
            Context.Remove(Context.Usuarios.Single(a => a.Id == id));
            Context.SaveChanges();
        }

        public void DeleteUserByEmail(string email)
        {
            Context.Remove(Context.Usuarios.Single(a => a.Email == email));
            Context.SaveChanges();
        }
    }
}
