using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using KS.Common.Library.Extensions;

namespace Mvc.Boilerplate.Api.Infrastructure.DelegatingHandlers
{
    public class GZipToJsonHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.IsContentGZip())
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var output = new MemoryStream();
            await request.Content.ReadAsStreamAsync().ContinueWith(t =>
            {
                var input = t.Result;
                using (var gzipStream = new GZipStream(input, CompressionMode.Decompress))
                {
                    gzipStream.CopyTo(output);
                    output.Flush();
                }
                output.Position = 0;
            }, cancellationToken);

            request.Content = new StreamContent(output);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await base.SendAsync(request, cancellationToken);
        }
    }
}