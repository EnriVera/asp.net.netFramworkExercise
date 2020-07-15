using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTask.Proyecto.Model.Entidades
{
    public class TaskEntidades
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaComienzo { get; set; }
        public bool Completado { get; set; }
        public byte[] Imagen { get; set; }
        public PersonEntidades IDPerson { get; set; }
    }
}
