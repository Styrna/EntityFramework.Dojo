using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace WebApplication1.Log
{
    public class HttpLogger : DelegatingHandler
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _log.Debug($"[API] url:{request.RequestUri}");

            var stoper = new Stopwatch();
            stoper.Start();
            var response = await base.SendAsync(request, cancellationToken);
            
            _log.Debug($"[API] url:{request.RequestUri} status:{response.StatusCode} time:{stoper.ElapsedMilliseconds}ms");
            return response;
        }
    }
}