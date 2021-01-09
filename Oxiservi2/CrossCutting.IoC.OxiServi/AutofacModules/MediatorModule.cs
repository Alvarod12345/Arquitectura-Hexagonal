using Application.OxiServi.Behavios;
using Autofac;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CrossCutting.IoC.OxiServi.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.Register<SingleInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.Register<MultiInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();

                return t =>
                {
                    var resolved = (IEnumerable<object>)componentContext.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                    return resolved;
                };
            });

            //builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
