using System.Collections.Generic;
using HFMaracay.Entities;

namespace HFMaracay.Business.Process
{
    public interface IAreasProcess
    {
        void DeleteByID(int id);
        Areas GetByDescripcion(string Descripcion);
        List<Areas> ListAll();
        Areas ListById(int id);
        Areas Save(Areas item);
    }
}