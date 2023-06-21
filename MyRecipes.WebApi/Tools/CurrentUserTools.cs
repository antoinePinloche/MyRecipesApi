using System.Security.Claims;

namespace MyRecipes.WebApi.Tools
{
    public static class CurrentUserTools
    {
        public static bool CheckCurrentUserAccess(ClaimsIdentity user, int id)
        {
            if (user != null)
            {
                var claims = user.Claims;
                var userId = claims.FirstOrDefault(c => c.Type == "userId");
                var userAccess = claims.FirstOrDefault(c => c.Type == "admin");
                if ((userId is not null && userId.Value == id.ToString()) ||
                    (userAccess is not null && userAccess.Value == "true"))
                    return true;
            }
            return false;
        }
    }
}
