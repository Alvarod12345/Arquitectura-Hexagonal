using Autofac;
using CrossCutting.Services.OxiServi.SmtpServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.IoC.OxiServi.AutofacModules
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<SmtpServices>().As<ISmtpServices>().InstancePerLifetimeScope();
        }
    }
}
