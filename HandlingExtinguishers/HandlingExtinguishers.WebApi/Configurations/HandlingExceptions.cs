using HandlingExtinguishers.Core.Helpers;
using HandlingExtinguishers.DTO.Response;
using HandlingExtinguishers.WebApi.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace HandlingExtinguishers.WebApi.Configurations
{
    public static class HandlingExceptions
    {
        public static void UseAPIErrorHandling(IApplicationBuilder action)
        {
            action.Run(
                   async context =>
                   {
                       var ex = context.Features.Get<IExceptionHandlerFeature>();
                       context.Response.ContentType = "application/json";
                       var failedResponse = new FailedOperationResultDto
                       {
                           Title = "Error in the operation.",
                           Status = context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError,
                           TraceId = context.Request.HttpContext.TraceIdentifier
                       };

                       if (ex != null)
                       {
                           var errors = new List<string>();
                           if (ex.Error is GlobalException exception)
                           {
                               failedResponse.Status = context.Response.StatusCode = (int)exception.StatusCode;
                               errors.Add(exception.Message);
                           }
                           else
                           {
                               errors.Add(ex.Error.Message);
#if DEBUG
                               errors.Add(ex?.Error?.InnerException?.Message!);
#endif
                           }
                           failedResponse.Errors = errors;
                       }
                       

                       await context.Response.WriteAsync(JsonSerializer.Serialize(failedResponse, JsonHelper.GetSerializerOptions()));
                   });
        }
    }
}
