using StructureMap;
using System;
using System.Threading;

namespace Angus.ISoft.Boilerplate.Structuremapper
{
	public class ObjectFactory
	{
		private static readonly Lazy<Container> _containerBuilder;

		private static Container _container;

		public static IContainer Container
		{
			get
			{
				return ObjectFactory._containerBuilder.Value;
			}
		}

		static ObjectFactory()
		{
			ObjectFactory._containerBuilder = new Lazy<Container>(new Func<Container>(ObjectFactory.defaultContainer), LazyThreadSafetyMode.ExecutionAndPublication);
			ObjectFactory._container = new Container();
		}

		private static Container defaultContainer()
		{
			return ObjectFactory._container;
		}

		public static void Initialize<T>() where T : Registry, new()
		{
			ObjectFactory._container.Configure(delegate(ConfigurationExpression x)
			{
				x.AddRegistry<T>();
			});
		}
	}
}
