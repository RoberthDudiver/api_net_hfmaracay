using System;
using System.Collections.Generic;
using System.Text;
using HFMaracay.Data;
namespace HFMaracay.Business.Process
{
    public class Process
    {
        Context _context;
        public Context Context
        {
            get
            {

                if (_context == null)
                {
                    _context = new Context();
                }
                return _context;
            }
        }
    }
}
