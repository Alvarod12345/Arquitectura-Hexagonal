using Autofac;
using Hangfire;
using Persistence.OxiServi.Job;

namespace API.Infrastructure.Jobs
{
    public class JobModule
    {
        public void Job(string connection)
        {
            RecurringJob.AddOrUpdate<OrdenJobRepository>(
               w => w.UpdateEstado(connection), Cron.Minutely);
        }
    }
}
