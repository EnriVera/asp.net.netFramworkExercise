using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTask.Proyecto.Model.Entidades;

namespace YouTask.Proyecto.Model.Interfaz
{
    public interface IGrupoTaskRepositorio
    {
        void AgregarGrupoTask(GrupoTaskEntidades grupoTaskEntidad);
        GrupoTaskEntidades EliminarTask(int id);
    }
}
