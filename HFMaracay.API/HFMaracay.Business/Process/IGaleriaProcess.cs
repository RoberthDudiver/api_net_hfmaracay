using System.Collections.Generic;
using HFMaracay.Entities;

namespace HFMaracay.Business.Process
{
    public interface IGaleriaProcess
    {
        void DeleteByID(int id);
        List<Galeria> ListAll();
        Galeria ListById(int id);
        Galeria Save(Galeria item);
    }
}