using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTask.Proyecto.Model.Entidades;
using YouTask.Proyecto.Model.Interfaz;
using YouTask.Proyecto.Repositorio.DTO;

namespace YouTask.Proyecto.Repositorio.Repositorio
{
    public class PersonRepositorio:IPersonRepositorio
    {
        YouTaskDBContext DBContext = new YouTaskDBContext();
        GrupoRepositorio grupoRepositorio;

        private readonly IMapper _mapper;

        public PersonRepositorio(IMapper mapper)
        {
            this._mapper = mapper;
            this.grupoRepositorio = new GrupoRepositorio(mapper);
        }

        public PersonEntidades DeletePerson(int id)
        {
            personDTO person = this.DBContext.person.Find(id);
            if (person == null)
            {
                return null;
            }

            this.DBContext.person.Remove(person);
            //_ = Guardar();
            this.DBContext.SaveChanges();
            return this._mapper.Map<PersonEntidades>(person);
        }

        public List<PersonEntidades> GetPerson()
        {
            var ListaPerson = (from data in this.DBContext.person
                               select data).ToList();
            List<PersonEntidades> personEntidads = this._mapper.Map<List<PersonEntidades>>(ListaPerson);
            personEntidads.ForEach(f =>
            {
                f.Grupo = this.grupoRepositorio.ObtenerUnGrupoPorPerson(f);
            });
            return personEntidads;
        }

        public PersonEntidades GetPersonEmailPaswork(string email, string passwork)
        {
            foreach (var data in this.DBContext.person)
            {
                if (data.email_person.Equals(email) && data.passwork_person.Equals(passwork))
                {
                    PersonEntidades personEntidads = this._mapper.Map<PersonEntidades>(data);
                    personEntidads.Grupo = this.grupoRepositorio.ObtenerUnGrupoPorPerson(personEntidads);
                    return personEntidads;
                }
            }
            return null;
        }

        public PersonEntidades GetPersonID(int id)
        {
            personDTO person = this.DBContext.person.Find(id);
            if (person == null)
            {
                return null;
            }

            PersonEntidades personEntidads = this._mapper.Map<PersonEntidades>(person);
            personEntidads.Grupo = this.grupoRepositorio.ObtenerUnGrupoPorPerson(personEntidads);
            return personEntidads;
        }

        public PersonEntidades PostPerson(PersonEntidades personEntidades)
        {
            var valor = this.DBContext.person.SingleOrDefault(e => e.email_person == personEntidades.Email);

            if (valor != null) return null;

            personDTO person = this._mapper.Map<personDTO>(personEntidades);

            this.DBContext.person.Add(person);
            //_ = Guardar();
            this.DBContext.SaveChanges();

            var valorperson = this.DBContext.person.SingleOrDefault(e => e.email_person == personEntidades.Email);

            return this._mapper.Map<PersonEntidades>(valorperson);
        }

        public PersonEntidades PutPerson(PersonEntidades personEntidades)
        {
            var dataPerson = this.DBContext.person.FirstOrDefault(x => x.id_person == personEntidades.ID);

            if (dataPerson == null) return null;

            personDTO person = MapperPersonUpdate(personEntidades);
            //_ = Guardar();
            this.DBContext.SaveChanges();

            return new PersonEntidades();
        }

        private personDTO MapperPersonUpdate(PersonEntidades personEntidades)
        {
            var personDto = this.DBContext.person.FirstOrDefault(x => x.id_person == personEntidades.ID);

            personDto.id_person = personEntidades.ID;
            personDto.name_person = personEntidades.Nombre;
            personDto.lastname_person = personEntidades.Apellido;
            personDto.email_person = personEntidades.Email;
            personDto.passwork_person = personEntidades.Passwork;
            personDto.image_person = personEntidades.Imagen;
            personDto.description_person = personEntidades.Descripcion;
            return personDto;
        }
    }
}
