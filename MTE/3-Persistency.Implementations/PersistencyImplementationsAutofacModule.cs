using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using _4_Persistency.Mappings;
using static System.Reflection.IntrospectionExtensions;

namespace _3_Persistency.Implementations
{
    public class PersistencyImplementationsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(PersinstencyMappings).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Mapping")).AsImplementedInterfaces();
        }
    }
}
