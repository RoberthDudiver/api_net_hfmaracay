using System;
using System.Collections.Generic;
using System.Text;

namespace HFMaracay.Entities
{
    public class Blog : EntitiesBitacora
    {
        public int Id
        { get; set; }
        public string Titulo
        { get; set; }      
        public string Imagen
        { get; set; }
        public string Descripción
        { get; set; }
    }
}
