namespace YouTask.Proyecto.Repositorio.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.grupo_task")]
    public partial class grupo_taskDTO
    {
        [Key]
        public int id_grupo_task { get; set; }

        public int? id_grupo2 { get; set; }

        public int? id_task1 { get; set; }

        public int? id_person_colocador { get; set; }

        public virtual grupoDTO grupo { get; set; }

        public virtual taskDTO task { get; set; }
    }
}
