﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HFMaracay.Entities
{
   public class Nivel : EntitiesBitacora
    {
        public int Id
        { get; set; }  

        public string Descripcion
        { get; set; }

        public List<Usuarios> Usuarios { get; set; }
    }
}
