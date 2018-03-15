using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore.Middlewares
{
    public class AuthenticationMiddleware
    {

        AuthorizedPath[] AuthenticatedRoutes = new AuthorizedPath[] 
        {
            new AuthorizedPath{ Method = "DELETE", Path = "/api/User" },
            new AuthorizedPath{ Method = "GET", Path = "/api/User" },
            new AuthorizedPath{ Method = "POST", Path = "/api/3DN" },
            new AuthorizedPath{ Method = "PUT", Path = "/api/3DN" },
            new AuthorizedPath{ Method = "DELETE", Path = "/api/3DN" }
        };

        private readonly RequestDelegate next;

        public AuthenticationMiddleware(RequestDelegate Next)
        {
            next = Next;
        }

        public async Task Invoke(HttpContext Context)
        {

            if (!RequiresAuthentication(Context.Request.Method, Context.Request.Path))
            {
                await next.Invoke(Context);
                return;
            }

            string authHeader = Context.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string headerValue = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                int seperatorIndex = headerValue.IndexOf(':');

                var loginName = headerValue.Substring(0, seperatorIndex);
                var password = headerValue.Substring(seperatorIndex + 1);

                var user = DbManager.FindUser(loginName, password);

                if (user != null)
                {
                    Context.Request.Headers.Add("UserName", user.UserName);
                    Context.Request.Headers.Add("LoginName", user.LoginName);
                    Context.Request.Headers.Add("Password", user.Password);
                    Context.Request.Headers.Add("Admin", user.Admin.ToString());
                    await next.Invoke(Context);
                }
                else
                {
                    Context.Response.StatusCode = 401;
                    return;
                }
            }
            else
            {
                Context.Response.StatusCode = 401;
                return;
            }
        }

        private bool RequiresAuthentication(string Method, string Path)
        {
            return AuthenticatedRoutes.Any(r => r.Method == Method && r.Path == Path);
        }

        class AuthorizedPath
        {
            public string Method { get; set; }
            public string Path { get; set; }
        }
    }
}
