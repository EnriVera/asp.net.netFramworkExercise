namespace YouTask.Proyecto.Repositorio.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.grupo")]
    public partial class grupoDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public grupoDTO()
        {
            grupo_person = new HashSet<grupo_personDTO>();
            grupo_task = new HashSet<grupo_taskDTO>();
        }

        [Key]
        public int id_grupo { get; set; }

        [Required]
        [StringLength(100)]
        public string title_grupo { get; set; }

        [StringLength(300)]
        public string description_grupo { get; set; }

        [MaxLength(2147483647)]
        public byte[] image_grupo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grupo_personDTO> grupo_person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grupo_taskDTO> grupo_task { get; set; }
    }
}
