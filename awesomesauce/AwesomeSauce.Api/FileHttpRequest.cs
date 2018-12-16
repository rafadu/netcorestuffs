using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AwesomeSauce.Api
{
    public class FileHttpRequest : HttpRequest
    {
        public FileHttpRequest(HttpContext context,string path){
            var lines = File.ReadAllText(path).Split('\n');
            var request = lines[0].Split(' ');
            this.Method = request[0];
            this.Path = request[1];
            this.HttpContext = context;
        }

        public override string Method {get; set;}
        public override PathString Path {get; set;}
        public override string Scheme {get; set;} = "file";
        public override HttpContext HttpContext {get;}
        public override bool IsHttps { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override HostString Host { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override PathString PathBase { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override QueryString QueryString { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override IQueryCollection Query { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override string Protocol { get; set;}

        public override IHeaderDictionary Headers => new HeaderDictionary();

        public override IRequestCookieCollection Cookies { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override long? ContentLength { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override string ContentType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override Stream Body { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override bool HasFormContentType => throw new System.NotImplementedException();

        public override IFormCollection Form { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}