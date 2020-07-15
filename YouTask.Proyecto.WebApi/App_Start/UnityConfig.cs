using AutoMapper;
using CommonServiceLocator;
using System.Web.Http;
using Unity;
using Unity.ServiceLocation;
using Unity.WebApi;
using YouTask.Proyecto.Model.Interfaz;
using YouTask.Proyecto.Repositorio.MapperConfig;
using YouTask.Proyecto.Repositorio.Repositorio;

namespace YouTask.Proyecto.WebApi
{
    public static class UnityConfig
    {
        private static IUnityContainer container;
        public static void RegisterComponents()
        {
            container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IPersonRepositorio, PersonRepositorio>();
            container.RegisterType<ITaskRepositorio, TaskRepositorio>();
            container.RegisterType<IGrupoRepositorio, GrupoRepositorio>();
            container.RegisterType<IGrupoTaskRepositorio, GrupoTaskRepositorio>();

            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            IMapper mapper = config.CreateMapper();

            container.RegisterInstance(mapper);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static IUnityContainer GetUnityContainer()
        {
            return container;
        }
    }
}