using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTask.Proyecto.Model.Entidades;

namespace YouTask.Proyecto.Model.Interfaz
{
    public interface ITaskRepositorio
    {
        List<TaskEntidades> ObtenerTareasDeUnGrupo(int idGrupo);

        TaskEntidades EliminarTarea(int id);

        TaskEntidades Modificartarea(TaskEntidades taskEntidad);

        bool ModificarTitulo(int id, string titulo);

        TaskEntidades AgregaTarea(TaskEntidades taskEntidad);

        bool TaskCompletada(int id);
    }
}
