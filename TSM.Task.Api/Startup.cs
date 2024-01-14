
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TSM.Task.Infrastructure.Extensions;

namespace Test;
public class Startup
{
    public void ConfigureServices(
		IServiceCollection services,
		string conectionString)
        => services.AddInfrastructureReferences(conectionString);

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}