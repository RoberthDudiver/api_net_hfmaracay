using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HFMaracay.Business.Process;
using HFMaracay.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HFMaracay.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class HFMaracayController : ControllerBase
    {
        #region Interfaces
        /// <summary>
        /// Todo esto puede ser solo un proceso de una interfaz tipo Iprocess _proceso y asociar cada proceso a Process<AreasProcess>.funcion 
        /// Solo que es mas bastracto de ver 
        /// </summary>
        private readonly IAreasProcess _areasProcess;
        private readonly INivelProcess _nivelProcess;
        private readonly IUsuariosProcess _usuariosProcess;
        private readonly ITipoLocalidadesProcess _tipoLocalidadesProcess;
        private readonly ILocalidadesProcess _localidadesProcess;
        #endregion
        public HFMaracayController(IAreasProcess areasProcess,INivelProcess nivelProcess, IUsuariosProcess usuariosProcess, ITipoLocalidadesProcess tipoLocalidadesProcess, ILocalidadesProcess localidadesProcess)
        {
            _nivelProcess = nivelProcess;
            _areasProcess = areasProcess;
            _usuariosProcess = usuariosProcess;
            _tipoLocalidadesProcess = tipoLocalidadesProcess;
            _localidadesProcess = localidadesProcess;
        }


        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("adduser")]
        public dynamic AddUsers([FromBody]Usuarios model)
        {
            return  Ok(_usuariosProcess.Save(model));
        }


        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("addareas")]
        public dynamic AddAreas([FromBody]Areas model)
        {
            return Ok(_areasProcess.Save(model));
        }

        [HttpGet]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("getareas")]
        public dynamic GetAreas()
        {
            return Ok(_areasProcess.ListAll());
        }


        [HttpDelete]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("deleteareas/{id}")]
        public dynamic DeletetAreas(int id)
        {
            try
            {
             _areasProcess.DeleteByID(id);
                return Ok("Sucess");
            }catch(Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("addlevels")]
        public dynamic Addlevels([FromBody]Nivel model)
        {
            return Ok(_nivelProcess.Save(model));
        }
        
        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("addlocations")]
        public dynamic Addlocations([FromBody]Localidad model)
        {
            return Ok(_localidadesProcess.Save(model));
        }


        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("addtypelocations")]
        public dynamic Addlocations([FromBody]TipoLocalidades model)
        {
            return Ok(_tipoLocalidadesProcess.Save(model));
        }
    }
}