using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.ModelBinding;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OpenLeczna.Startup))]

namespace OpenLeczna
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
