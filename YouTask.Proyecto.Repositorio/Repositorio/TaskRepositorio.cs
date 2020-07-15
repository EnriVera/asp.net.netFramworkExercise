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
    public class TaskRepositorio:ITaskRepositorio
    {
        YouTaskDBContext DBContext = new YouTaskDBContext();
        GrupoTaskRepositorio grupoTaskRepositorio;

        private readonly IMapper _mapper;

        public TaskRepositorio(IMapper mapper)
        {
            this._mapper = mapper;
            this.grupoTaskRepositorio = new GrupoTaskRepositorio(mapper);
        }
        public List<TaskEntidades> ObtenerUnaTarea(int idGrupo)
        {
            var data = (from valor in this.DBContext.grupo_task
                        where valor.id_grupo2 == idGrupo
                        from valorTask in this.DBContext.task
                        where valorTask.id_task == valor.id_task1
                        select valorTask).ToList();

            List<TaskEntidades> taskEntidad = this._mapper.Map<List<TaskEntidades>>(data);
            return taskEntidad;
        }

        public TaskEntidades EliminarTarea(int id)
        {
            var task = this.DBContext.task.Find(id);

            if (task == null) return null;

            this.grupoTaskRepositorio.EliminarTask(id);

            this.DBContext.task.Remove(task);

            this.DBContext.SaveChanges();
            return new TaskEntidades();
        }

        public TaskEntidades Modificartarea(TaskEntidades taskEntidad)
        {
            var dataTask = this.DBContext.task.FirstOrDefault(x => x.id_task == taskEntidad.ID);

            if (dataTask == null) return null;

            taskDTO person = MapperTaskUpdate(taskEntidad);
            //_ = Guardar();
            this.DBContext.SaveChanges();
            return new TaskEntidades();
        }

        public TaskEntidades AgregaTarea(TaskEntidades taskEntidad)
        {
            taskDTO task = this._mapper.Map<taskDTO>(taskEntidad);
            this.DBContext.task.Add(task);

            //_ = Guardar();
            this.DBContext.SaveChanges();

            //return AgregarTaskAGrupo(IDGrupo, IDPersonColocador);
            return this._mapper.Map<TaskEntidades>(task);
        }

        public bool TaskCompletada(int id)
        {
            taskDTO task = this.DBContext.task.Find(id);

            if (task == null) return false;

            if (task.complete_task == false)
                task.complete_task = true;
            else
                task.complete_task = false;

            this.DBContext.SaveChanges();

            return true;
        }








        private async Task Guardar()
        {
            await this.DBContext.SaveChangesAsync();
        }

        private taskDTO MapperTaskUpdate(TaskEntidades taskEntidad)
        {
            var taskDTO = this.DBContext.task.FirstOrDefault(x => x.id_task == taskEntidad.ID);

            taskDTO.id_task = taskEntidad.ID;
            taskDTO.title_task = taskEntidad.Titulo;
            taskDTO.description_task = taskEntidad.Descripcion;
            taskDTO.date_creating_task = taskEntidad.FechaCreacion;
            taskDTO.state_task = taskEntidad.Estado;
            taskDTO.date_start_task = taskEntidad.FechaComienzo;
            taskDTO.complete_task = taskEntidad.Completado;
            taskDTO.image_task = taskEntidad.Imagen;
            taskDTO.id_person2 = null;
            return taskDTO;
        }
    }
}
