using System;
using System.Collections.Generic;
using System.Text;

namespace HFMaracay.Entities
{
    public class TipoLocalidades
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Localidad> Localidades { get; set; }
    }
}
