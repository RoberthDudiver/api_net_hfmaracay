using System;

namespace HFMaracay.Entities
{
    public class Usuarios: EntitiesBitacora
    {

        public int Id
        { get; set; }

        public string Nombre
        {
            get;
            set;
        }

        public string Apellido
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string FechaDeNacimiento
        {
            get;
            set;
        }

        public int CiudadId { get; set; }


        public int PaisId { get; set; }
  

        public int EstadoId { get; set; }

        public Areas Area { get; set; }
        public int AreaId
        {
            get;
            set;
        }
        public Nivel Nivel { get; set; }
        public int NivelId
        {
            get;
            set;
        }
        /// <summary>
        ///  Todo esto de aca abajo puede ser una tabla  llamada SocialMedia Maestro detalle  y asi asociar a un usuario N Cantidad 
        ///  de redes disponibles , por factor tiempo no lo hare asi 
        /// </summary>
        /// 
        public string Telefono
        {
            get;
            set;
        }

        public string Linkedin
        {
            get;
            set;
        }
        public string Facebook
        {
            get;
            set;
        }
        public string Twitter
        {
            get;
            set;
        }
        public string Instagram
        {
            get;
            set;
        }
    }
}
