using System.Collections.Generic;
using HFMaracay.Entities;

namespace HFMaracay.Business.Process
{
    public interface ILocalidadesProcess
    {
        void DeleteByID(int id);
        Localidad GetByDescripcion(string nombre);
        List<Localidad> ListAll();
        Localidad ListById(int id);
        Localidad Save(Localidad item);
        void SoftDeleteByID(Localidad item );

    }
}