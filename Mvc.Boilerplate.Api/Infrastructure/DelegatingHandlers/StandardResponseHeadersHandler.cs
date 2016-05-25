using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Mvc.Boilerplate.Api.Infrastructure.DelegatingHandlers
{
    //Message handlers in Web API provide you the opportunity to process, edit, or decline an incoming request before it reaches the HttpControllerDispatcher. 
    //All message handlers derive from the class HttpMessageHandler. So as DelegatingHandler

    public class StandardResponseHeadersHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ////var response = new HttpResponseMessage(HttpStatusCode.OK)
            ////{
            ////    Content = new StringContent("Inside the IDG message handler...")
            ////};

            ////var task = new TaskCompletionSource<HttpResponseMessage>();
            ////task.SetResult(response);
            ////return await task.Task;


            //calling the base SendAsync - ensures that you are willing to progess with the current request.

            return await base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                task.Result.Headers.Add("custom-header", "hello");
                return task.Result;
            }, cancellationToken);
        }
    }
}