using System.Collections.Generic;
using HFMaracay.Entities;

namespace HFMaracay.Business.Process
{
    public interface ITipoLocalidadesProcess
    {
        void DeleteByID(int id);
        TipoLocalidades GetByNombre(string nombre);
        List<TipoLocalidades> ListAll();
        TipoLocalidades ListById(int id);
        TipoLocalidades Save(TipoLocalidades item);
        void SoftDeleteByID(TipoLocalidades item);

    }
}