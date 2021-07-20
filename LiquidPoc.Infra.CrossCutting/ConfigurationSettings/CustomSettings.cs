using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Infra.CrossCutting.ConfigurationSettings
{
    [ConfigurationName("MyCustomSettings")]
    public class CustomSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Liquid.Core.Tests.Configuration.Entities.CustomSetting"/> is prop1.
        /// </summary>
        /// <value>
        ///   <c>true</c> if prop1; otherwise, <c>false</c>.
        /// </value>
        public bool Prop1 { get; set; }

        /// <summary>
        /// Gets or sets the prop2.
        /// </summary>
        /// <value>
        /// The prop2.
        /// </value>
        public string Prop2 { get; set; }

        /// <summary>
        /// Gets or sets the prop3.
        /// </summary>
        /// <value>
        /// The prop3.
        /// </value>
        public int Prop3 { get; set; }

        /// <summary>
        /// Gets or sets the prop4.
        /// </summary>
        /// <value>
        /// The prop4.
        /// </value>
        public DateTime Prop4 { get; set; }

        /// <summary>
        /// Gets or sets the prop5.
        /// </summary>
        /// <value>
        /// The prop5.
        /// </value>
        public string Prop5 { get; set; }

        /// <summary>
        /// Gets or sets the prop6.
        /// </summary>
        /// <value>
        /// The prop6.
        /// </value>
        public string Prop6 { get; set; }
    }
}
