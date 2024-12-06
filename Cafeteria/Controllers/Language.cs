using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

public class CultureController : Controller
{
    public IActionResult SetCulture(string culture, string returnUrl)
    {
        if (!string.IsNullOrWhiteSpace(culture))
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
        }

        return LocalRedirect(returnUrl);
    }
}
