namespace YouTask.Proyecto.Repositorio.DTO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class YouTaskDBContext : DbContext
    {
        public YouTaskDBContext()
            : base("name=YouTaskDBContext")
        {
        }

        public virtual DbSet<grupoDTO> grupo { get; set; }
        public virtual DbSet<grupo_personDTO> grupo_person { get; set; }
        public virtual DbSet<grupo_taskDTO> grupo_task { get; set; }
        public virtual DbSet<personDTO> person { get; set; }
        public virtual DbSet<taskDTO> task { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<grupoDTO>()
                .HasMany(e => e.grupo_person)
                .WithOptional(e => e.grupo)
                .HasForeignKey(e => e.id_grupo1);

            modelBuilder.Entity<grupoDTO>()
                .HasMany(e => e.grupo_task)
                .WithOptional(e => e.grupo)
                .HasForeignKey(e => e.id_grupo2);

            modelBuilder.Entity<personDTO>()
                .HasMany(e => e.grupo_person)
                .WithOptional(e => e.person)
                .HasForeignKey(e => e.id_person1);

            modelBuilder.Entity<taskDTO>()
                .HasMany(e => e.grupo_task)
                .WithOptional(e => e.task)
                .HasForeignKey(e => e.id_task1);
        }
    }
}
