namespace YouTask.Proyecto.Repositorio.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.task")]
    public partial class taskDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taskDTO()
        {
            grupo_task = new HashSet<grupo_taskDTO>();
        }

        [Key]
        public int id_task { get; set; }

        [Required]
        [StringLength(100)]
        public string title_task { get; set; }

        [StringLength(300)]
        public string description_task { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_creating_task { get; set; }

        public int? state_task { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_start_task { get; set; }

        public bool? complete_task { get; set; }

        [MaxLength(2147483647)]
        public byte[] image_task { get; set; }

        public int? id_person2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grupo_taskDTO> grupo_task { get; set; }
    }
}
