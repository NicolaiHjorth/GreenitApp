using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Auth;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeAdmin", a =>
                a.RequireAuthenticatedUser().RequireClaim("Role", "admin"));
            
            options.AddPolicy("MustBeLoggedIn", a =>
                a.RequireAuthenticatedUser());
            
            options.AddPolicy("Age18OrAbove", a =>
                a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim? ageClaim = context.User.FindFirst(claim => claim.Type.Equals("Age"));
                    if (ageClaim == null) return false;
                    return int.Parse(ageClaim.Value) >= 18;
                }));
        });
    }
}