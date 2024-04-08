﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using TestTaskForIntravision.Application.Exceptions;
using TestTaskForIntravision.Infrastructure.Web.Http;

namespace TestTaskForIntravision.Application.Web.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await WrapThrownExceptionJsonResponseAsync(context.Response, ex, HttpStatusCode.BadRequest);
            }
            catch (NotFoundException ex)
            {
                await WrapThrownExceptionJsonResponseAsync(context.Response, ex, HttpStatusCode.NotFound);
            }
        }

        private async Task WrapThrownExceptionJsonResponseAsync(HttpResponse response, Exception exception,
            HttpStatusCode httpStatusCode, CancellationToken cancellationToken = default)
        {
            var newResponseBody = new ApiResponse<object>(null, httpStatusCode, exception);
            var newResponseBodyText = JsonConvert.SerializeObject(newResponseBody);

            response.StatusCode = (int)httpStatusCode;

            await response.WriteAsync(newResponseBodyText, cancellationToken);
        }
    }
}
