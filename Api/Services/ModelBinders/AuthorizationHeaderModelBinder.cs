using Backend.Api.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Backend.Api.Services.ModelBinders;

public class AuthorizationHeaderModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        //bindingContext.HttpContext.Request.Cookies[]
        var isAuthGotten = bindingContext.HttpContext.Request.Headers.TryGetValue("Authinfo", out var authorizationFromHeader);
        if (!isAuthGotten)
            throw new BadHttpRequestException(statusCode: 401, message: "Нету заголовка с данными аутентификации");

        var authInfo = JsonConvert.DeserializeObject<UserAuthInfo>(authorizationFromHeader!);
        if (authInfo is null)
            throw new BadHttpRequestException(statusCode: 422, message: "Неправильный формат заголовка аутентификации");

        bindingContext.Result = ModelBindingResult.Success(authInfo);
        return Task.CompletedTask;
    }
}

public class AuthorizationHeaderModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        return context.Metadata.ModelType == typeof(UserAuthInfo) ? new AuthorizationHeaderModelBinder() : null;
    }
}