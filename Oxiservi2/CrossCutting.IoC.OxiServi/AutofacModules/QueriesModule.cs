using Application.OxiServi.Queries.Auth;
using Application.OxiServi.Queries.User;
using Application.OxiServi.Queries.Supplier;
using Application.Northwind.Queries.Category;
using Application.Northwind.Queries.Product;
using Autofac;

namespace CrossCutting.IoC.OxiServi.AutofacModules
{
    public class QueriesModule : Autofac.Module
    {
        public string _queriesConnectionString { get; }
        public QueriesModule(string queriesConnectionString)
        {
            _queriesConnectionString = queriesConnectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UserQueries(_queriesConnectionString))
                     .As<IUserQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new AuthQueries(_queriesConnectionString))
                     .As<IAuthQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new SupplierQueries(_queriesConnectionString))
                    .As<ISupplierQueries>()
                    .InstancePerLifetimeScope();
            builder.Register(c => new CategoryQueries(_queriesConnectionString))
                    .As<ICategoryQueries>()
                    .InstancePerLifetimeScope();
            builder.Register(c => new ProductQueries(_queriesConnectionString))
                    .As<IProductQueries>()
                    .InstancePerLifetimeScope();

        }
    } 
}