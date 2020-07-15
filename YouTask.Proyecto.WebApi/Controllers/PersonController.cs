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
    public class PersonController : ApiController
    {
        public IPersonRepositorio personRepositorio;

        public PersonController(IPersonRepositorio personRepositorio)
        {
            if (personRepositorio == null)
                throw new ArgumentNullException("repository error");
            this.personRepositorio = personRepositorio;
        }

        [HttpGet]
        [Route("api/people/getpeople")]
        public IHttpActionResult GetPerson()
        {
            return Ok(this.personRepositorio.GetPerson());
        }

        [HttpGet]
        [Route("api/people/get-person-por-datos")]
        public IHttpActionResult GetPersonEmailPaswork(string email, string passwork)
        {
            if (email == "" || passwork == "") return NotFound();
            var unperson = this.personRepositorio.GetPersonEmailPaswork(email, passwork);
            if (unperson == null) return NotFound();
            return Ok(unperson);
        }

        [HttpGet]
        [Route("api/people/getpeopleid")]
        public IHttpActionResult GetPersonID(int id)
        {
            if (id <= 0) return NotFound();
            var person = this.personRepositorio.GetPersonID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPut]
        [Route("api/people/putperson")]
        public IHttpActionResult PutPerson(PersonEntidades person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var putperon = this.personRepositorio.PutPerson(person);
            if (putperon == null) return NotFound();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("api/people/postperson")]
        public IHttpActionResult PostPerson(PersonEntidades person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultadoPersonModel = this.personRepositorio.PostPerson(person);

            if (resultadoPersonModel == null) return NotFound();

            return Ok(resultadoPersonModel);
        }

        [HttpDelete]
        [Route("api/people/deleteperson")]
        public IHttpActionResult Deleteperson(int id)
        {
            if (id == 0) return NotFound();
            var deletePerson = this.personRepositorio.DeletePerson(id);
            if (deletePerson == null) return NotFound();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
