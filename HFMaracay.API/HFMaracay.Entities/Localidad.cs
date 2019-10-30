using System;
using System.Collections.Generic;
using System.Text;

namespace HFMaracay.Entities
{
   public class Localidad
    {
        public int Id
        { get; set; }
        public string IsoCode
        { get; set; }
   

        public string Nombre
        { get; set; }

        public virtual TipoLocalidades TipoLocalidades { get; set; }

        public virtual Localidad Parent { get; set; }

    }
}
