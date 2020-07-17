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
    public class GrupoPersonController : ApiController
    {
        public IGrupoPersonRepositorio grupoPersonRepositorio;

        public GrupoPersonController(IGrupoPersonRepositorio grupoPersonRepositorio)
        {
            if (grupoPersonRepositorio == null)
                throw new ArgumentNullException("repository error");
            this.grupoPersonRepositorio = grupoPersonRepositorio;
        }

        [HttpPost]
        [Route("api/grupoPerson/postGrupoPerson")]
        public IHttpActionResult AgregarPersonAGrupo(int IDGrupo, int IDPerson)
        {
            GrupoPersonEntidades grupoPersonEntidades = new GrupoPersonEntidades();
            grupoPersonEntidades.IDGrupo = IDGrupo;
            grupoPersonEntidades.IDPerson = IDPerson;
            var resultado = this.grupoPersonRepositorio.AgregarGrupoPerson(grupoPersonEntidades);
            if (resultado == false) return NotFound();

            return StatusCode(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("api/grupoPerson/deleteGrupoPerson")]
        public IHttpActionResult EliminarPersonGrupo(int IDGrupo, int IDPerson)
        {
            var resultado = this.grupoPersonRepositorio.EliminarGrupoPerson(IDGrupo, IDPerson);

            if (resultado == false) return NotFound();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
