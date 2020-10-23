using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Application.Library
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                // exemplo de um middleware de exceções
                // poderia ser colocado um logger aqui
                throw ex;
            }
        }
    }
}
