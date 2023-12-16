using Furion.ConfigurableOptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Core.Const
{
    public class AppInfoOptions : IConfigurableOptions
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }
    }

}
