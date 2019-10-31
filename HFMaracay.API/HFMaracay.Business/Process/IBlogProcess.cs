using System.Collections.Generic;
using HFMaracay.Entities;

namespace HFMaracay.Business.Process
{
    public interface IBlogProcess
    {
        void DeleteByID(int id);
        List<Blog> ListAll();
        Blog ListById(int id);
        Blog Save(Blog item);
        void SoftDeleteByID(Blog item);
    }
}