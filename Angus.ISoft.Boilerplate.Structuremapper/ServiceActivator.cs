using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Angus.ISoft.Boilerplate.Structuremapper.Webapi
{
    public class ServiceActivator : IHttpControllerActivator
    {
        public ServiceActivator(HttpConfiguration configuration) { }
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return ObjectFactory.Container.GetInstance(controllerType) as IHttpController;
        }
    }

    public static class BootStrapStructureMapper
    {
        public static void Register<T>() where T : Registry, new()
        {
            ObjectFactory.Initialize<T>();
        }
    }
}
