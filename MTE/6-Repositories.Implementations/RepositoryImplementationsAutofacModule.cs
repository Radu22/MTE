﻿using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace _6_Repositories.Implementations
{
    public class RepositoryImplementationsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(RepositoriesImplementation).GetTypeInfo().Assembly)
                .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
        }
    }
}
