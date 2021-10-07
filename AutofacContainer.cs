using System.Net.Http;
using System.Reflection;
using Autofac;
using FirestoreExample.Firestore;

namespace FirestoreExample
{
    internal class AutofacContainer
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly())
                .InstancePerDependency()
                .AsImplementedInterfaces();
            
            var configProvider = new ConfigProvider();
            builder.Register(c => configProvider).As<IConfigProvider>().SingleInstance();

            builder.Register(c => new FirestoreDatabaseProvider(configProvider)).As<IFirestoreDatabaseProvider>().SingleInstance();

            builder.Register(c => new HttpClient()).SingleInstance();

            return builder.Build();
        }
    }
}