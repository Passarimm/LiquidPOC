using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Infra.CrossCutting.ConfigurationSettings
{
    public sealed class ConfigurationNameAttribute : Attribute
    {
        public string Name { get; set; }

        public ConfigurationNameAttribute(string name)
        {
            Name = name;
        }
    }
}
