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
    public class GrupoTaskRepositorio:IGrupoTaskRepositorio
    {

        YouTaskDBContext DBContext = new YouTaskDBContext();
        private readonly IMapper _mapper;

        public GrupoTaskRepositorio(IMapper mapper)
        {
            this._mapper = mapper;
        }


        private async Task Guardar()
        {
            await this.DBContext.SaveChangesAsync();
        }

        public void AgregarGrupoTask(GrupoTaskEntidades grupoTaskEntidad)
        {
            taskDTO dd = this.DBContext.task.OrderByDescending(e => e.id_task).FirstOrDefault();
            grupoTaskEntidad.IDTask = dd.id_task;
            this.DBContext.grupo_task.Add(this._mapper.Map<grupo_taskDTO>(grupoTaskEntidad));
            this.DBContext.SaveChanges();
        }

        public GrupoTaskEntidades EliminarTask(int id)
        {
            var GrupoTask = this.DBContext.grupo_task.SingleOrDefault(s => s.id_task1 == id);

            return Eliminar(GrupoTask);
        }

        public GrupoTaskEntidades Eliminar(grupo_taskDTO GrupoTask)
        {
            if (GrupoTask == null) return null;
            this.DBContext.grupo_task.Remove(GrupoTask);
            this.DBContext.SaveChanges();
            return new GrupoTaskEntidades();
        }

    }
}
