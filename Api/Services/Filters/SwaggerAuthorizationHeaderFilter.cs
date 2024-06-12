using System.Diagnostics.CodeAnalysis;

using Backend.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Backend.Api.Services.Filters;

public class SwaggerAuthorizationHeaderFilter : IOperationFilter
{
    [SuppressMessage("Minor Code Smell", "S6605:Collection-specific \"Exists\" method should be used instead of the \"Any\" extension", Justification = "<Ожидание>")]
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var parametersOfFunction = context.MethodInfo.GetParameters();
        var hasAuthInfoParameter = parametersOfFunction.Any(p => p.CustomAttributes.Any(attr => attr.AttributeType == typeof(FromHeaderAttribute)) && p.ParameterType == typeof(UserAuthInfo));

        if (hasAuthInfoParameter)
        {
            operation.Parameters.Remove(operation.Parameters.First(param => param.Name == "authInfo"));
            var openApiParameter = new OpenApiParameter
            {
                Name = "AuthInfo",
                In = ParameterLocation.Header,
                Description = "Custom authentication header",
                Schema = new OpenApiSchema { Format = "json", Example = OpenApiAnyFactory.CreateFromJson("{\"id\": 1, \"userType\": 0}") },
                Required = true
            };
            operation.Parameters.Add(openApiParameter);
        }
    }
}