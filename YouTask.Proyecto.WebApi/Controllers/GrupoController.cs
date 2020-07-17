using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YouTask.Proyecto.Model.Entidades;
using YouTask.Proyecto.Model.Interfaz;

namespace YouTask.Proyecto.WebApi.Controllers
{
    public class GrupoController : ApiController
    {
        public IGrupoRepositorio grupoRepositorio;

        public GrupoController(IGrupoRepositorio grupoRepositorio)
        {
            if (grupoRepositorio == null)
                throw new ArgumentNullException("repository error");
            this.grupoRepositorio = grupoRepositorio;
        }


        [HttpPost]
        [Route("api/grupo/potsgrupo")]
        public IHttpActionResult AgregarGrupo(GrupoEntidades grupoEntidades)
        {
            bool valor = this.grupoRepositorio.AgregarGrupo(grupoEntidades);

            if (valor == false) return NotFound();

            return StatusCode(HttpStatusCode.Created);
        }


        [HttpDelete]
        [Route("api/grupo/deletegrupo")]
        public IHttpActionResult EliminarGrupo(int IDGrupo, int IDPerson)
        {
            bool valor = this.grupoRepositorio.EliminarGrupo(IDGrupo, IDPerson);

            if (valor == false) return NotFound();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("api/grupo/putgrupo")]
        public IHttpActionResult ModificarGrupo(GrupoEntidades grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var putgrupo = this.grupoRepositorio.ModificarGrupo(grupo);
            if (putgrupo == false) return NotFound();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
