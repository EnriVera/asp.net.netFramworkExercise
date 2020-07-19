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
    public class GrupoRepositorio:IGrupoRepositorio
    {
        YouTaskDBContext DBContext = new YouTaskDBContext();

        TaskRepositorio taskRepositorio;
        GrupoPersonRepositorio grupoPersonRepositorio;

        private readonly IMapper _mapper;

        public GrupoRepositorio(IMapper mapper)
        {
            this._mapper = mapper;
            taskRepositorio = new TaskRepositorio(mapper);
            this.grupoPersonRepositorio = new GrupoPersonRepositorio(mapper);
        }
        public List<GrupoEntidades> ObtenerUnGrupoPorPerson(PersonEntidades person)
        {
            var valor = (from data in this.DBContext.grupo_person
                         where data.id_person1 == person.ID
                         from datGrupo in this.DBContext.grupo
                         where datGrupo.id_grupo == data.id_grupo1
                         select datGrupo).ToList();

            List<GrupoEntidades> grupoEntidad = this._mapper.Map<List<GrupoEntidades>>(valor);
            grupoEntidad.ForEach(f =>
            {
                f.Task = this.taskRepositorio.ObtenerTareasDeUnGrupo(f.ID);

                f.Administrador = ObtenerAdministrador(f, person);
            });

            return grupoEntidad;
        }

        public PersonEntidades ObtenerAdministrador(GrupoEntidades grupoEntidades, PersonEntidades personEntidades)
        {
            grupo_personDTO grupo_Person = this.DBContext.grupo_person.SingleOrDefault(e => e.id_grupo1 == grupoEntidades.ID && e.id_person1 == personEntidades.ID);

            return this._mapper.Map<PersonEntidades>(this.DBContext.person.Find(grupo_Person.id_person_administrador));
        }



        public bool AgregarGrupo(GrupoEntidades grupoEntidades)
        {
            grupoDTO grupo = this._mapper.Map<grupoDTO>(grupoEntidades);
            this.DBContext.grupo.Add(grupo);
            this.DBContext.SaveChanges();

            GrupoPersonEntidades grupoPerson = new GrupoPersonEntidades();
            grupoPerson.IDGrupo = grupo.id_grupo;
            grupoPerson.IDPerson = grupoEntidades.Administrador.ID;
            grupoPerson.IDPersonAdministrador = grupoEntidades.Administrador.ID;

            return this.grupoPersonRepositorio.AgregarGrupoPerson(grupoPerson);
        }

        public bool EliminarGrupo(int IDGrupo, int IDPerson)
        {
            grupoDTO grupo = this.DBContext.grupo.Find(IDGrupo);
            if (grupo == null) return false;

            var valor = this.grupoPersonRepositorio.EliminarGrupoPerson(IDGrupo, IDPerson);

            if (valor == false) return false;


            this.DBContext.grupo.Remove(grupo);
            this.DBContext.SaveChanges();

            return true;
        }


        public bool ModificarGrupo(GrupoEntidades grupoEntidades)
        {
            var dataGrupo = this.DBContext.grupo.Find(grupoEntidades.ID);

            if (dataGrupo == null) return false;

            grupoDTO grupo = MapperGrupoUpdate(grupoEntidades);
            this.DBContext.SaveChanges();

            return true;
        }

        private grupoDTO MapperGrupoUpdate(GrupoEntidades grupo)
        {
            var grupoDTO = this.DBContext.grupo.Find(grupo.ID);

            grupoDTO.id_grupo = grupo.ID;
            grupoDTO.title_grupo = grupo.Titulo;
            grupoDTO.description_grupo = grupo.Descripcion;
            grupoDTO.image_grupo = grupo.Imagen;
            return grupoDTO;
        }
    }
}
