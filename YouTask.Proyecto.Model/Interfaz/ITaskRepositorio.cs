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
        List<TaskEntidades> ObtenerUnaTarea(int idGrupo);

        TaskEntidades EliminarTarea(int id);

        TaskEntidades Modificartarea(TaskEntidades taskEntidad);

        TaskEntidades AgregaTarea(TaskEntidades taskEntidad);

        bool TaskCompletada(int id);
    }
}
