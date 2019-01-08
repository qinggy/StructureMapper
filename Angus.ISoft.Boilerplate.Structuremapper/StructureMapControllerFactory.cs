using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Angus.ISoft.Boilerplate.Structuremapper.MVC
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {

            if (requestContext == null || controllerType == null) return null;

            return (Controller)ObjectFactory.Container.GetInstance(controllerType);
        }
    }

    public static class BootStrapStructureMapper
    {
        public static void Register<T>() where T : Registry, new()
        {
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            ObjectFactory.Initialize<T>();
        }
    }
}
