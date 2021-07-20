using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Domain.Settings
{
    public class RedisSettings
    {
        public string InstanceName { get; set; }
        public string Configuration { get; set; }
        public int AbsoluteExpirationRelativeToNowSeconds { get; set; }
        public int SlidingExpirationSeconds { get; set; }

        public DistributedCacheEntryOptions DistributedCacheEntryConfig { get; set; }
    }
}
