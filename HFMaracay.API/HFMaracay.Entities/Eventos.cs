using System;
using System.Collections.Generic;
using System.Text;

namespace HFMaracay.Entities
{
    public class Eventos
    {
        public int Id
        { get; set; }
        public string Nombre
        { get; set; }

        public long FechaEpoch
        { get; set; }
        public DateTime Fecha
        { get; set; }
        public string Hora
        { get; set; }

        public string Lugar
        { get; set; }

        public string Imagen
        { get; set; }
        public string Descripción
        { get; set; }


    }
}
