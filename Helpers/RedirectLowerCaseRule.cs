using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System.Linq;
using System.Net;

namespace ASPNETCoreSEOTemplate.Helpers
{
    public class RedirectLowerCaseRule : IRule
    {
        public int StatusCode { get; } = (int)HttpStatusCode.MovedPermanently;
        public void ApplyRule(RewriteContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            PathString path = context.HttpContext.Request.Path;
            PathString pathbase = context.HttpContext.Request.PathBase;
            HostString host = context.HttpContext.Request.Host;

            if ((path.HasValue && path.Value.Any(char.IsUpper)) || (host.HasValue && host.Value.Any(char.IsUpper)) || (pathbase.HasValue && pathbase.Value.Any(char.IsUpper)))
            {
                HttpResponse response = context.HttpContext.Response;
                response.StatusCode = StatusCode;
                response.Headers[HeaderNames.Location] = (request.Scheme + "://" + host.Value + request.PathBase + request.Path).ToLower() + request.QueryString;
                context.Result = RuleResult.EndResponse;
            }
            else
            {
                context.Result = RuleResult.ContinueRules;
            }
        }
    }

    public class RedirectEndingSlashCaseRule : IRule
    {
        public int StatusCode { get; } = (int)HttpStatusCode.MovedPermanently;
        public void ApplyRule(RewriteContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            HostString host = context.HttpContext.Request.Host;
            string path = request.Path.ToString();

            if (path.Length > 1 && path.EndsWith("/"))
            {
                request.Path = path.Remove(path.Length - 1, 1);
                HttpResponse response = context.HttpContext.Response;
                response.StatusCode = StatusCode;
                response.Headers[HeaderNames.Location] = (request.Scheme + "://" + host.Value + request.PathBase + request.Path).ToLower() + request.QueryString;
                context.Result = RuleResult.EndResponse;
            }
            else
            {
                context.Result = RuleResult.ContinueRules;
            }
        }
    }
}
