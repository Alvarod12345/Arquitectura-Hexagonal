﻿using Application.OxiServi.Commands.Movimiento;
using Application.OxiServi.Commands.Orden;
using Application.OxiServi.Commands.Producto;
using Application.OxiServi.Commands.Provider;
using Application.OxiServi.Commands.User;
using Application.OxiServi.Validations;
using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.IoC.OxiServi.AutofacModules
{
    public class ValidatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateUserValidation>()
                .As<AbstractValidator<CreateUserCommand>>()
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