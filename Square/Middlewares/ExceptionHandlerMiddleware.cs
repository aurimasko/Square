using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Square.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Square.Middlewares
{
    public static class ExceptionHandlerMiddleware
    { 
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        try
                        {
                            using (var scope = app.ApplicationServices.CreateScope())
                            {
                                // error messages should be logged in database, but it is a demo app, no errors log exists
                                await context.Response.WriteAsync(new Response("An internal error occured, error message: " + contextFeature.Error).ToString());
                            }
                        }
                        catch (Exception)
                        {
                            await context.Response.WriteAsync(new Response("An internal error occured").ToString());
                        }
                    }

                });
            });
        }
    }
}
