using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudOperationWith_Entity.Startup))]
namespace CrudOperationWith_Entity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
