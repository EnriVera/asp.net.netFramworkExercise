using AutoMapper.Configuration.Annotations;
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
    public class TaskController : ApiController
    {
        public ITaskRepositorio taskRepositorio;

        public TaskController(ITaskRepositorio taskRepositorio)
        {
            if (taskRepositorio == null)
                throw new ArgumentNullException("repository error");
            this.taskRepositorio = taskRepositorio;
        }

        [HttpGet]
        [Route("api/task/getTask")]
        public IHttpActionResult GetTask(int grupo)
        {
            List<TaskEntidades> task = this.taskRepositorio.ObtenerTareasDeUnGrupo(grupo);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        [Route("api/task/postTask")]
        public IHttpActionResult PostTask(TaskEntidades taskEntidad)
        {
            var taskValor = this.taskRepositorio.AgregaTarea(taskEntidad);
            if (taskValor == null) return NotFound();
            return Ok(taskValor);
        }

        [HttpPut]
        [Route("api/task/modificarTask")]
        public IHttpActionResult ModificarTask(TaskEntidades taskEntidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskValor = this.taskRepositorio.Modificartarea(taskEntidad);
            if (taskValor == null) return NotFound();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPatch]
        [Route("api/task/modificarTitulotask")]
        public IHttpActionResult ModificarTituloTask(int id, string titulo)
        {
            var resultadoTask = this.taskRepositorio.ModificarTitulo(id, titulo);

            if (resultadoTask == false) return NotFound();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPatch]
        [Route("api/task/completado")]
        public IHttpActionResult TaskCompletada(int id)
        {
            var taskValor = this.taskRepositorio.TaskCompletada(id);
            if (taskValor == false) return NotFound();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("api/task/eliminartask")]
        public IHttpActionResult EliminarTask(int id)
        {
            var taskValor = this.taskRepositorio.EliminarTarea(id);
            if (taskValor == null) return NotFound();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
