using Application.OxiServi.Commands.Movimiento;
using Application.OxiServi.Commands.Orden;
using Application.OxiServi.Commands.Producto;
using Application.OxiServi.Commands.Provider;
using Application.OxiServi.Commands.User;
using Application.OxiServi.Validations;
using Application.Northwind.Validations;
using Application.OxiServi.Commands.Supplier;
using Application.Northwind.Commands.Supplier;
using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Northwind.Commands.Category;

namespace CrossCutting.IoC.OxiServi.AutofacModules
{
    public class ValidatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateUserValidation>()
                .As<AbstractValidator<CreateUserCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterType<CreateSupplierValidation>()
                .As<AbstractValidator<CreateSupplierCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterType<UpdateSupplierValidation>()
                .As<AbstractValidator<UpdateSupplierCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterType<DeleteSupplierValidation>()
                .As<AbstractValidator<DeleteSupplierCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterType<CreateCategoryValidation>()
                .As<AbstractValidator<CreateCategoryCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterType<UpdateCategoryValidation>()
                .As<AbstractValidator<UpdateCategoryCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterType<DeleteCategoryValidation>()
               .As<AbstractValidator<DeleteCategoryCommand>>()
               .AsImplementedInterfaces();

            //builder.RegisterType<CreateProviderValidation>()
            //    .As<AbstractValidator<CreateProviderCommand>>()
            //    .AsImplementedInterfaces();
            //builder.RegisterType<UpdateProviderValidation>()
            //    .As<AbstractValidator<UpdateProviderCommand>>()
            //    .AsImplementedInterfaces();
            //builder.RegisterType<CreateProductoValidation>()
            //    .As<AbstractValidator<CreateProductoCommand>>()
            //    .AsImplementedInterfaces();
            //builder.RegisterType<UpdateProductoValidation>()
            //        .As<AbstractValidator<UpdateProductoCommand>>()
            //        .AsImplementedInterfaces();
            //builder.RegisterType<UpdateOrdenValidation>()
            //    .As<AbstractValidator<UpdateEstadoOrdenCommand>>()
            //    .AsImplementedInterfaces();
            //builder.RegisterType<CreateMovimientoValidation>()
            //    .As<AbstractValidator<CreateMovimientoCommand>>()
            //    .AsImplementedInterfaces();
        }
    }
}
