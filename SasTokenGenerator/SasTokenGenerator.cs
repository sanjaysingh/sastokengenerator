using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.IO;
using System.Net.Http.Headers;

namespace SasTokenGenerator
{
    /// <summary>
    /// Sas Token Generator azure function class
    /// </summary>
    public static class SasTokenGenerator
    {
        /// <summary>
        /// Runs on the GET of function
        /// </summary>
        /// <param name="req">htttp request</param>
        /// <param name="log">log writer</param>
        /// <returns>http response</returns>
        [FunctionName("SasTokenGenerator")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "")]HttpRequestMessage req, TraceWriter log, ExecutionContext context)
        {
            log.Info("C# HTTP trigger function processing a request.");

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var indexPage = Path.Combine(context.FunctionDirectory, "index.html");
            var stream = new FileStream(indexPage, FileMode.Open, FileAccess.Read, FileShare.Read);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            return await Task.FromResult(response);
        }
    }
}
