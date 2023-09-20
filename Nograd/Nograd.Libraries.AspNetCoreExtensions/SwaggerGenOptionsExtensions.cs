using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nograd.Libraries.AspNetCoreExtensions;

public static class SwaggerGenOptionsExtensions
{
    public static void HideEndpointsFromOtherAssemblies(this SwaggerGenOptions options, Type programType)
    {
        options.DocInclusionPredicate((_, apiDescription) =>
        {
            var fullMethodPath = apiDescription.ActionDescriptor.DisplayName;
            var assemblyName = programType.Assembly.GetName().Name;

            if (string.IsNullOrEmpty(fullMethodPath))
                throw new Exception($"{nameof(fullMethodPath)} can't be empty");
            if (string.IsNullOrEmpty(assemblyName)) throw new Exception($"{nameof(assemblyName)} can't be empty");

            return fullMethodPath.Contains(assemblyName);
        });
    }
}