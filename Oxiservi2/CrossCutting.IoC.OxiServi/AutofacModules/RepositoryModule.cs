
using Autofac;
using Domain.OxiServi.AggregatesModel.SuppliersAggregate;
using Domain.OxiServi.AggregatesModel.CategoryAggregate;
using Domain.Northwind.AggregatesModel.ProductAggregate;
using Persistence.OxiServi.Repository;
using System;
using System.Collections.Generic;
using System.Text;

using Persistence.Northwind.Repository;

namespace CrossCutting.IoC.OxiServi.AutofacModules
{
    public class RepositoryModule : Autofac.Module
    {
        private string connectionString;
        public RepositoryModule(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SupplierRepository(connectionString))
                   .As<ISupplierRepository>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new CategoryRepository(connectionString))
                   .As<ICategoryRepository>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new ProductRepository(connectionString))
                   .As<IProductRepository>()
                   .InstancePerLifetimeScope();
        }
    }
}
