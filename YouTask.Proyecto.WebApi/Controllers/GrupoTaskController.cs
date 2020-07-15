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
    public class GrupoTaskController : ApiController
    {
        public IGrupoTaskRepositorio GrupoTaskRepositorio;

        public GrupoTaskController(IGrupoTaskRepositorio GrupoTaskRepositorio)
        {
            if (GrupoTaskRepositorio == null)
                throw new ArgumentNullException("repository error");
            this.GrupoTaskRepositorio = GrupoTaskRepositorio;
        }


        [HttpPost]
        [Route("api/grupoTask")]
        public IHttpActionResult PostGrupoTask(int IDGrupo, int IDTask, int IDPersonColocador)
        {
            GrupoTaskEntidades grupoTaskEntidad = new GrupoTaskEntidades();
            grupoTaskEntidad.IDGrupo = IDGrupo;
            grupoTaskEntidad.IDTask = IDTask;
            grupoTaskEntidad.IDPersonColocador = IDPersonColocador;

            this.GrupoTaskRepositorio.AgregarGrupoTask(grupoTaskEntidad);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
