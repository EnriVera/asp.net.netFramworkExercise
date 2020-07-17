using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTask.Proyecto.Model.Entidades;
using YouTask.Proyecto.Model.Interfaz;
using YouTask.Proyecto.Repositorio.DTO;

namespace YouTask.Proyecto.Repositorio.Repositorio
{
    public class GrupoPersonRepositorio : IGrupoPersonRepositorio
    {
        YouTaskDBContext DBContext = new YouTaskDBContext();
        private readonly IMapper _mapper;

        public GrupoPersonRepositorio(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public bool AgregarGrupoPerson(GrupoPersonEntidades grupoPersonEntidades)
        {
            if (this.DBContext.grupo.Find(grupoPersonEntidades.IDGrupo) == null) return false;

            grupo_personDTO grupo_Person = new grupo_personDTO();
            grupo_Person = this._mapper.Map<grupo_personDTO>(grupoPersonEntidades);

            if (grupo_Person.id_person_administrador == 0)
            {
                // verificar si los datos pasados por parametros ya tiene el grupo solisitado
                grupo_personDTO grupo_Person1 = this.DBContext.grupo_person.SingleOrDefault(e => e.id_grupo1 == grupo_Person.id_grupo1 && e.id_person1 == grupo_Person.id_person1);
                if (grupo_Person1 != null) return false;

                // Agregar el administrador que que creo el grupo solisitado
                grupo_Person.id_person_administrador = this.DBContext.grupo_person.SingleOrDefault(e=>e.id_grupo1 == grupo_Person.id_grupo1 && e.id_person1 == e.id_person_administrador).id_person_administrador;
            }
            else
            {
                grupo_Person.id_person_administrador = grupoPersonEntidades.IDPersonAdministrador;
            }

            this.DBContext.grupo_person.Add(grupo_Person);
            this.DBContext.SaveChanges();

            return true;
        }

        public bool EliminarGrupoPerson(int IDGrupo, int IDPerson)
        {
            grupo_personDTO grupo_Person = this.DBContext.grupo_person.SingleOrDefault(e => e.id_grupo1 == IDGrupo && e.id_person1 == IDPerson);
            if (grupo_Person == null) return false;

            this.DBContext.grupo_person.Remove(grupo_Person);
            this.DBContext.SaveChanges();

            return true;
        }
    }
}
