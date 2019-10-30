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

        public string ParentCode
        { get; set; }

        public TipoLocalidades TipoLocalidades { get; set; }
        public string TipoLocalidadesId { get; set; }
        public virtual Localidad Parent { get; set; }

    }
}
