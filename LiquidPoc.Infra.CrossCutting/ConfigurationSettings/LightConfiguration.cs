using Liquid.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Infra.CrossCutting.ConfigurationSettings
{
    public class LightConfiguration<T> : ILightConfiguration<T> where T : class, new()
    {
        protected readonly IConfiguration _configuration;

        public LightConfiguration(IOptions<T> options, IConfiguration configuration)
        {
            _configuration = configuration;

            Settings = _configuration.GetSection("Liquid:" + GetSectionName(typeof(T))).Get<T>() ?? options.Value;

            if (Settings.Equals(default(T)))
                throw new ArgumentNullException(nameof(T));
        }

        public T Settings { get; private set; }

        private string GetSectionName(Type type)
        {
            var collectionNameAttribute = type.GetCustomAttribute<ConfigurationNameAttribute>();

            return collectionNameAttribute?.Name ?? type.Name;
        }
    }
}
