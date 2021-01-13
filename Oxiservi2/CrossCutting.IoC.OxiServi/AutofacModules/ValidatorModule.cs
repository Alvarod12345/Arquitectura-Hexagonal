
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
using Application.Northwind.Commands.Product;

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
                .As<AbstractValidator<CreateProductCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterType<UpdateCategoryValidation>()
                .As<AbstractValidator<UpdateCategoryCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterType<DeleteCategoryValidation>()
               .As<AbstractValidator<DeleteCategoryCommand>>()
               .AsImplementedInterfaces();

            builder.RegisterType<CreateProductValidation>()
                .As<AbstractValidator<CreateProductCommad>>()
                .AsImplementedInterfaces();

            builder.RegisterType<UpdateProductValidation>()
                .As<AbstractValidator<UpdateProductCommand>>()
                .AsImplementedInterfaces();

            builder.RegisterType<DeleteProductValidation>()
               .As<AbstractValidator<DeleteProductCommand>>()
               .AsImplementedInterfaces();
        }
    }
}
