using Application.OxiServi.Queries.Auth;
using Application.OxiServi.Queries.Cliente;
using Application.OxiServi.Queries.Cotizacion;
using Application.OxiServi.Queries.DetalleOrden;
using Application.OxiServi.Queries.Direccion;
using Application.OxiServi.Queries.Maestro;
using Application.OxiServi.Queries.Movimiento;
using Application.OxiServi.Queries.Orden;
using Application.OxiServi.Queries.Producto;
using Application.OxiServi.Queries.Provider;
using Application.OxiServi.Queries.User;
using Application.OxiServi.Queries.Factura;
using Autofac;
using Application.OxiServi.Queries.Recarga;
using Application.OxiServi.Queries.DetalleTipoProducto;
using Application.OxiServi.Queries.Distrito;
using Application.OxiServi.Queries.Implemento;
using Application.OxiServi.Queries.TipoProducto;

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
            builder.Register(c => new ClienteQueries(_queriesConnectionString))
                     .As<IClienteQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new AuthQueries(_queriesConnectionString))
                     .As<IAuthQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new  ProductoQueries(_queriesConnectionString))
                     .As<IProductoQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new CotizacionQueries(_queriesConnectionString))
                     .As<ICotizacionQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new OrdenQueries(_queriesConnectionString))
                     .As<IOrdenQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new DetalleOrdenQueries(_queriesConnectionString))
                     .As<IDetalleOrdenQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new MaestroQueries(_queriesConnectionString))
                     .As<IMaestroQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new ProviderQueries(_queriesConnectionString))
                     .As<IProviderQueries>()
                     .InstancePerLifetimeScope();
            builder.Register(c => new DireccionQueries(_queriesConnectionString))
                    .As<IDireccionQueries>()
                    .InstancePerLifetimeScope();
            builder.Register(c=> new MovimientoQueries(_queriesConnectionString))
                    .As<IMovimientoQueries>()
                    .InstancePerLifetimeScope();
            builder.Register(c => new FacturaQueries(_queriesConnectionString))
                    .As<IFacturaQueries>()
                    .InstancePerLifetimeScope();
            builder.Register(c => new RecargaQueries(_queriesConnectionString))
                   .As<IRecargaQueries>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new DetalleTipoProductoQueries(_queriesConnectionString))
                   .As<IDetalleTipoProductoQueries>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new DistritoQueries(_queriesConnectionString))
                   .As<IDistritoQueries>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new ImplementoQueries(_queriesConnectionString))
                   .As<IImplementoQueries>()
                   .InstancePerLifetimeScope();
            builder.Register(c => new TipoProductoQueries(_queriesConnectionString))
                   .As<ITipoProductoQueries>()
                   .InstancePerLifetimeScope();
        }
    } 
}