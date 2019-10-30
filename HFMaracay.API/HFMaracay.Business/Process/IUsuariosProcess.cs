using System.Collections.Generic;
using HFMaracay.Entities;

namespace HFMaracay.Business.Process
{
    public interface IUsuariosProcess
    {
        void DeleteUserByEmail(string email);
        void DeleteUserByID(int id);
        Usuarios GetUsersByEmail(string email);
        Usuarios GetUsersByName(string name);
        List<Usuarios> ListAllUsers();
        Usuarios ListUsersById(int id);
        Usuarios Save(Usuarios usuario);
    }
}