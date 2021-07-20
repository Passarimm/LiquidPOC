using Liquid.Core.Telemetry;
using Liquid.Repository.EntityFramework;

namespace LiquidPoc.Infra.Data.Base
{
    public class SampleRepository : EntityFrameworkDataContext<DataContext>
    {

        public SampleRepository(ILightTelemetryFactory telemetryFactory, IEntityFrameworkDataContext<TEntity> dataContext)
                : base(telemetryFactory, dataContext)
        {
        }

    }
}
