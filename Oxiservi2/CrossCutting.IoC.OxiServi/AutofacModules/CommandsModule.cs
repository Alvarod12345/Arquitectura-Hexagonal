
using Application.OxiServi.Commands.Supplier;
using Application.Northwind.Commands.Supplier;
using Application.Northwind.Commands.Category;
using Application.Northwind.Commands.Product;

using Autofac;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CrossCutting.IoC.OxiServi.AutofacModules
{
    public class CommandsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CreateSupplierCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(UpdateSupplierCommand).GetTypeInfo().Assembly)
           .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteSupplierCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(CreateProductCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(UpdateCategoryCommand).GetTypeInfo().Assembly)
           .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteCategoryCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(CreateProductCommad).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(UpdateProductCommand).GetTypeInfo().Assembly)
           .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(DeleteProductCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));
        }
    }
}
