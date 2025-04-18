using Microsoft.AspNetCore.Diagnostics;
using Entities.ErrorModel;

using Services.Contracts;
using System.Net;
using Entities.Exceptions;

namespace WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        // global hata yönetimi için middleware uzantısı
        public static void ConfigureExceptionHandler(this WebApplication app ,ILoggerService logger)
        {
            app.UseExceptionHandler(appError=>
            {
                appError.Run(async context=>
                {
                    
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); // fırlatılan hatayı yakalar
                    if(contextFeature is not null)  // hata varsa 
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                             NotFoundException => StatusCodes.Status404NotFound,
                            _=>StatusCodes.Status500InternalServerError
                        };
                        logger.LogError($"Something went wrong:{contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });

        }
    }
}
