namespace YouTask.Proyecto.Repositorio.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.grupo_person")]
    public partial class grupo_personDTO
    {
        [Key]
        public int id_grupo_person { get; set; }

        public int? id_grupo1 { get; set; }

        public int? id_person1 { get; set; }

        public int? id_person_administrador { get; set; }

        public virtual grupoDTO grupo { get; set; }

        public virtual personDTO person { get; set; }
    }
}
