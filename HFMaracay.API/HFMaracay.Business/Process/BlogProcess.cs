using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFMaracay.Entities;
namespace HFMaracay.Business.Process
{
    public class BlogProcess : Process, IBlogProcess
    {
        public List<Blog> ListAll()
        {
            return Context.Blogs.ToList();
        }

        public Blog ListById(int id)
        {
            return Context.Blogs.FirstOrDefault(x => x.Id == id);
        }

        public Blog Save(Blog item)
        {
            if (item.Id != null && item.Id != 0)
            {
                Context.Blogs.Attach(item);
            }
            else
            {
                Context.Blogs.Add(item);
            }
            Context.SaveChanges();
            return item;
        }

        public void DeleteByID(int id)
        {
            Context.Remove(Context.Blogs.Single(a => a.Id == id));
            Context.SaveChanges();
        }


    }
}
