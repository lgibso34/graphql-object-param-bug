using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;

namespace github_object_bug
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      IRequestExecutorBuilder server = services.AddGraphQLServer();

      server
          // .AddAuthorization()
          .AddQueryType(d => d.Name("Query"))
          .AddMutationType(d => d.Name("Mutation"));

      server.AddType<MyQueries>();
      server.AddType<MyMutations>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        // By default the GraphQL server is mapped to /graphql
        // This route also provides you with our GraphQL IDE. In order to configure the
        // the GraphQL IDE use endpoints.MapGraphQL().WithToolOptions(...).
        endpoints.MapGraphQL().WithOptions(
            new GraphQLServerOptions()
            {
              Tool = {
                Enable = true,
              },
            }
        );
      });
    }
  }
}
