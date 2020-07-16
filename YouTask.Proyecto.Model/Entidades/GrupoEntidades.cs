using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTask.Proyecto.Model.Entidades
{
    public class GrupoEntidades
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public PersonEntidades Administrador { get; set; }
        public List<TaskEntidades> Task { get; set; }
    }
}
