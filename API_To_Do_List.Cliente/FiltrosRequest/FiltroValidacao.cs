﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace API_To_Do_List.Cliente.FiltrosRequest
{
    public class FiltroValidacao : IAsyncResultFilter
    {

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {

            if (!context.ModelState.IsValid)
            {
                var mensagens = context.ModelState.
                    SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();


                context.HttpContext.Response.StatusCode = 400;

                await context.HttpContext.Response.WriteAsJsonAsync(new { Erros = string.Join(" ", mensagens) });
                await context.HttpContext.Response.CompleteAsync();
            }

            await next();

        }
    }
}
