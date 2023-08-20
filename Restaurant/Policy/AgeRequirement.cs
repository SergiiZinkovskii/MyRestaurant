using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

public class AgeRequirement : IAuthorizationRequirement
{
    public int MinimumAge { get; }

    public AgeRequirement(int minimumAge)
    {
        MinimumAge = minimumAge;
    }
}