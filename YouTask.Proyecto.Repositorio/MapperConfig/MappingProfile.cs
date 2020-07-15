using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using YouTask.Proyecto.Model.Entidades;
using YouTask.Proyecto.Repositorio.DTO;

namespace YouTask.Proyecto.Repositorio.MapperConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<personDTO, PersonEntidades>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id_person))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.name_person))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.lastname_person))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email_person))
                .ForMember(dest => dest.Passwork, opt => opt.MapFrom(src => src.passwork_person))
                .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src => src.image_person))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.description_person));


            CreateMap<PersonEntidades, personDTO>()
                .ForMember(dest => dest.id_person, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.name_person, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.lastname_person, opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.email_person, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.passwork_person, opt => opt.MapFrom(src => src.Passwork))
                .ForMember(dest => dest.image_person, opt => opt.MapFrom(src => src.Imagen))
                .ForMember(dest => dest.description_person, opt => opt.MapFrom(src => src.Descripcion));


            CreateMap<TaskEntidades, taskDTO>()
                .ForMember(dest => dest.title_task, opt => opt.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.description_task, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.date_creating_task, opt => opt.MapFrom(src => src.FechaCreacion))
                .ForMember(dest => dest.state_task, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.date_start_task, opt => opt.MapFrom(src => src.FechaComienzo))
                .ForMember(dest => dest.complete_task, opt => opt.MapFrom(src => src.Completado))
                .ForMember(dest => dest.image_task, opt => opt.MapFrom(src => src.Imagen))
                .ForMember(dest => dest.id_person2, opt => opt.MapFrom(src => src.IDPerson));

            CreateMap<taskDTO, TaskEntidades>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id_task))
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.title_task))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.description_task))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.date_creating_task))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.state_task))
                .ForMember(dest => dest.FechaComienzo, opt => opt.MapFrom(src => src.date_start_task))
                .ForMember(dest => dest.Completado, opt => opt.MapFrom(src => src.complete_task))
                .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src => src.image_task))
                .ForMember(dest => dest.IDPerson, opt => opt.MapFrom(src => src.id_person2));

            CreateMap<grupoDTO, GrupoEntidades>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.id_grupo))
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.title_grupo))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.description_grupo))
                .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src => src.image_grupo));


            CreateMap<GrupoEntidades, grupoDTO>()
                .ForMember(dest => dest.id_grupo, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.title_grupo, opt => opt.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.description_grupo, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.image_grupo, opt => opt.MapFrom(src => src.Imagen));

            CreateMap<GrupoTaskEntidades, grupo_taskDTO>()
                .ForMember(dest => dest.id_grupo2, opt => opt.MapFrom(src => src.IDGrupo))
                .ForMember(dest => dest.id_task1, opt => opt.MapFrom(src => src.IDTask))
                .ForMember(dest => dest.id_person_colocador, opt => opt.MapFrom(src => src.IDPersonColocador));

            CreateMap<grupo_taskDTO, GrupoTaskEntidades>()
                .ForMember(dest => dest.IDGrupo, opt => opt.MapFrom(src => src.id_grupo2))
                .ForMember(dest => dest.IDTask, opt => opt.MapFrom(src => src.id_task1))
                .ForMember(dest => dest.IDPersonColocador, opt => opt.MapFrom(src => src.id_person_colocador));
        }
    }
}
