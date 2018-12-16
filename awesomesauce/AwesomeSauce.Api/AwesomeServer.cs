using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;

namespace AwesomeSauce.Api
{
    public class AwesomeServer : IServer
    {
        public AwesomeServer(IOptions<AwesomeServerOptions> options){
            Features.Set<IHttpRequestFeature>(new HttpRequestFeature());
            Features.Set<IHttpResponseFeature>(new HttpResponseFeature());

            var serverAddressesFeatures = new ServerAddressesFeature();
            serverAddressesFeatures.Addresses.Add(options.Value.FolderPath);
            Features.Set<IServerAddressesFeature>(serverAddressesFeatures);
        }

        public IFeatureCollection Features {get;} = new FeatureCollection();

        public void Dispose()
        {
        }

        public Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
        {
            return Task.Run(() =>{
                var watcher = new AwesomeFolderWatcher<TContext>(application,Features);
                watcher.Watch();
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}