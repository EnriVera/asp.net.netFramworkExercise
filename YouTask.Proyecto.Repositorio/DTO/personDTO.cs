namespace YouTask.Proyecto.Repositorio.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.person")]
    public partial class personDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personDTO()
        {
            grupo_person = new HashSet<grupo_personDTO>();
        }

        [Key]
        public int id_person { get; set; }

        [Required]
        [StringLength(10)]
        public string name_person { get; set; }

        [Required]
        [StringLength(20)]
        public string lastname_person { get; set; }

        [Required]
        [StringLength(100)]
        public string email_person { get; set; }

        [Required]
        [StringLength(50)]
        public string passwork_person { get; set; }

        [MaxLength(2147483647)]
        public byte[] image_person { get; set; }

        [StringLength(300)]
        public string description_person { get; set; }

        public int? id_task2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grupo_personDTO> grupo_person { get; set; }
    }
}
