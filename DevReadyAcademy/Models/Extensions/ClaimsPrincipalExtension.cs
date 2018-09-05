using DevReadyAcademy.Models.Constants;
using System.Linq;
using System.Security.Claims;

namespace DevReadyAcademy.Models.Extensions
{
    public static class ClaimsPrincipalExtension
    {
         public static string GetFirstName(this ClaimsPrincipal principal)
        {
            var firstName = principal.Claims.FirstOrDefault(c => c.Type == ClaimType.FirstName);
            return firstName?.Value;
        }

        public static string GetLastName(this ClaimsPrincipal principal)
        {
            var lastName = principal.Claims.FirstOrDefault(c => c.Type == ClaimType.LastName);
            return lastName?.Value;
        }
    }
}