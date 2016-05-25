using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KS.Common.Library.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static string GetHeaderValue(this HttpRequestMessage request, string headerName)
        {
            IEnumerable<string> headerValues;
            request.Headers.TryGetValues(headerName, out headerValues);
            if (headerValues == null) return string.Empty;

            var value = headerValues.FirstOrDefault();
            return value == null ? string.Empty : value.Trim();
        }

        public static bool IsContentGZip(this HttpRequestMessage request)
        {
            return request.Content.Headers.ContentEncoding.Contains("gzip") ||
                  (request.Content.Headers.ContentType != null &&
                    request.Content.Headers.ContentType.MediaType == "application/gzip");
        }


    }
}
