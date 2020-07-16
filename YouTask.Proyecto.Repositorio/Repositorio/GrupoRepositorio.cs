﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public GrupoRepositorio(IMapper mapper)
        {
            taskRepositorio = new TaskRepositorio(mapper);
            this._mapper = mapper;
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
                f.Task = this.taskRepositorio.ObtenerUnaTarea(f.ID);

                f.Administrador = ObtenerAdministrador(f, person);
            });

            return grupoEntidad;
        }

        public PersonEntidades ObtenerAdministrador(GrupoEntidades grupoEntidades, PersonEntidades personEntidades)
        {
            grupo_personDTO grupo_Person = this.DBContext.grupo_person.SingleOrDefault(e => e.id_grupo1 == grupoEntidades.ID && e.id_person1 == personEntidades.ID);

            return this._mapper.Map<PersonEntidades>(this.DBContext.person.Find(grupo_Person.id_person_administrador));
        }
    }
}
