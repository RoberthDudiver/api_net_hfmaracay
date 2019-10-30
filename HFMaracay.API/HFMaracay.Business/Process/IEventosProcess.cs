using System.Collections.Generic;
using HFMaracay.Entities;

namespace HFMaracay.Business.Process
{
    public interface IEventosProcess
    {
        void DeleteByID(int id);
        List<Eventos> ListAll();
        Eventos ListById(int id);
        Eventos Save(Eventos item);
    }
}