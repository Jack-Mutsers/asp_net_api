using System;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace API.Filters
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            try
            {
                Guid ParsedData = Guid.Parse(potentialApiKey);
                AccessValidation accessValidation = new AccessValidation(ParsedData);

                var valid = accessValidation.GetValidation();

                /*
                var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                var apiKey = configuration.GetValue<string>("ApiKey");

                if (!apiKey.Equals(potentialApiKey))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                //*/

                if (valid)
                {
                    await next();
                }
                else
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

        }
    }
}
