using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTask.Proyecto.Model.Entidades
{
    public class PersonEntidades
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Passwork { get; set; }
        public byte[] Imagen { get; set; }
        public string Descripcion { get; set; }
        public List<GrupoEntidades> Grupo { get; set; }
    }
}
