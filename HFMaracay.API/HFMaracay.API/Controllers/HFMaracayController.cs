﻿using System;
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
        private readonly IEventosProcess _eventosProcess;
        private readonly IBlogProcess _blogProcess;
        private readonly IGaleriaProcess _galeriaProcess;



        #endregion
        public HFMaracayController(IGaleriaProcess galeriaProcess, IBlogProcess blogProcess, IEventosProcess eventosProcess, IAreasProcess areasProcess, INivelProcess nivelProcess, IUsuariosProcess usuariosProcess, ITipoLocalidadesProcess tipoLocalidadesProcess, ILocalidadesProcess localidadesProcess)
        {
            _nivelProcess = nivelProcess;
            _areasProcess = areasProcess;
            _usuariosProcess = usuariosProcess;
            _tipoLocalidadesProcess = tipoLocalidadesProcess;
            _localidadesProcess = localidadesProcess;
            _eventosProcess = eventosProcess;
            _blogProcess = blogProcess;
            _galeriaProcess = galeriaProcess;
        }

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


        [HttpGet]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("getlevels")]
        public dynamic GetNiveles()
        {
            return Ok(_nivelProcess.ListAll());
        }
        
        [HttpDelete]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("deletelevels/{id}")]
        public dynamic DeleteNiveles(int id)
        {
            try
            {
                _nivelProcess.DeleteByID(id);
                return Ok("Sucess");
            }
            catch (Exception e)
            {
                throw;
            }
        }




        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("addlocations")]
        public dynamic Addlocations([FromBody]Localidad model)
        {
            return Ok(_localidadesProcess.Save(model));
        }


        [HttpGet]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("getlocations")]
        public dynamic Getlocations()
        {
            return Ok(_localidadesProcess.ListAll());
        }

        [HttpDelete]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("deletelocations/{id}")]
        public dynamic DeleteLocations(int id)
        {
            try
            {
                _localidadesProcess.DeleteByID(id);
                return Ok("Sucess");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("addtypelocations")]
        public dynamic Addlocations([FromBody]TipoLocalidades model)
        {
            return Ok(_tipoLocalidadesProcess.Save(model));
        }

        [HttpGet]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("gettypelocations")]
        public dynamic Gettypelocations()
        {
            return Ok(_tipoLocalidadesProcess.ListAll());
        }

        [HttpDelete]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("deletelocations/{id}")]
        public dynamic Deletetypelocations(int id)
        {
            try
            {
                _tipoLocalidadesProcess.DeleteByID(id);
                return Ok("Sucess");
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [HttpGet]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("getusers")]
        public dynamic Getusers()
        {
            return Ok(_usuariosProcess.ListAll());
        }
          [HttpGet]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("getusers/email/{email}")]
        public dynamic Getusers(string email)
        {
            return Ok(_usuariosProcess.GetUsersByEmail(email));
        }

        [HttpDelete]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("deleteuser/{id}")]
        public dynamic DeleteUser(int id)
        {
            try
            {
                _usuariosProcess.DeleteByID(id);
                return Ok("Sucess");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("deleteuser/email/{email}")]
        public dynamic DeleteUserByemail(string email)
        {
            try
            {
                _usuariosProcess.DeleteUserByEmail(email);
                return Ok("Sucess");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        ////////////////////////////////////////
        ///
        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("addgalery")]
        public dynamic AddGalery([FromBody]Galeria model)
        {
            return Ok(_galeriaProcess.Save(model));
        }


        [HttpGet]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("getgalery")]
        public dynamic GetGalery()
        {
            return Ok(_galeriaProcess.ListAll());
        }

        [HttpDelete]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("deletegalery/{id}")]
        public dynamic DeleteGalery(int id)
        {
            try
            {
                _galeriaProcess.DeleteByID(id);
                return Ok("Sucess");
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /////////////////////
        ///

        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("addlevents")]
        public dynamic AddEvents([FromBody]Eventos model)
        {
            return Ok(_eventosProcess.Save(model));
        }


        [HttpGet]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("getlevents")]
        public dynamic GetEvents()
        {
            return Ok(_eventosProcess.ListAll());
        }

        [HttpDelete]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("deleteevents/{id}")]
        public dynamic DeleteEvents(int id)
        {
            try
            {
                _eventosProcess.DeleteByID(id);
                return Ok("Sucess");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //////
        ///
        [HttpPost]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("addlBlog")]
        public dynamic AddBlog([FromBody]Blog model)
        {
            return Ok(_blogProcess.Save(model));
        }


        [HttpGet]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("getlBlog")]
        public dynamic GetBlog()
        {
            return Ok(_blogProcess.ListAll());
        }

        [HttpDelete]
        [AllowAnonymous] // esto deberia tenr seguridad pero por tiempo no lo hare 
        [Route("deletelBlog/{id}")]
        public dynamic DeleteBlog(int id)
        {
            try
            {
                _blogProcess.DeleteByID(id);
                return Ok("Sucess");
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}