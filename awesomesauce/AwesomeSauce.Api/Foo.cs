using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeSauce.Api{
    public class Foo{
        //optional
        public void ConfigureServices(IServiceCollection services){
            services.AddSingleton<IComponent,ComponentB>();
        }

        //required
        public void Configure(IApplicationBuilder app, IComponent component){
            app.Use(async (context,next) => {
                if(context.Request.Path == "/foo"){
                    await context.Response.WriteAsync($"Welcome to Foo");
                }
                else{
                    await next();
                }
            });
            app.Use(async (context,next) => {
                if(context.Request.Path == "/bar"){
                    await context.Response.WriteAsync($"Welcome to Bar");
                }
                else{
                    await next();
                }
            });
            app.Run(async(context) => 
                await context.Response.WriteAsync($"Welcome to default"));
                
            app.Run(async (context)=>
                await context.Response.WriteAsync($"Name is {component.Name}"));
        }
    }
}