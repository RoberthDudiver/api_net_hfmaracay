using System.Collections.Generic;
using HFMaracay.Entities;

namespace HFMaracay.Business.Process
{
    public interface INivelProcess
    {
        void DeletByID(int id);
        Nivel GetByDescripcion(string Descripcion);
        List<Nivel> ListAll();
        Nivel ListById(int id);
        Nivel Save(Nivel item);
    }
}