using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Core.Constant
{
    public class ControllerNames
    {
        private readonly IConfiguration _config;
        public ControllerNames(IConfiguration config)
        {
            _config = config;
        }
        public List<string> ControllersName()
        {
            var i = _config.GetSection("TableNames").Get<List<string>>();
            return i;
        }
    }
}
