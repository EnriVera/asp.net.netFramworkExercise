using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTask.Proyecto.Model.Entidades;

namespace YouTask.Proyecto.Model.Interfaz
{
    public interface IGrupoRepositorio
    {
        List<GrupoEntidades> ObtenerUnGrupoPorPerson(PersonEntidades person);

        bool AgregarGrupo(GrupoEntidades grupoEntidades);

        bool EliminarGrupo(int IDGrupo, int IDPerson);

        bool ModificarGrupo(GrupoEntidades grupoEntidades);
    }
}
