namespace BackboneJsOnNancy.Web.Extensions
{
    using System;
    using System.Linq;
    using Nancy.Validation;
    using Nancy.ViewEngines.Razor;

    public static class HtmlHelperExtensions
    {
        public static bool IsAuthenticated<T>(this  HtmlHelpers<T> htmlHelper)
        {
            return htmlHelper.RenderContext.Context.CurrentUser != null;
        }

        public static IHtmlString ErrorClassFor<T>(this HtmlHelpers<T> htmlHelper, string name)
        {
            var errors = htmlHelper.RenderContext.Context.ViewBag.errors;

            if (errors.HasValue)
            {
                var result = errors.Value as ModelValidationResult;

                if (result == null)
                    return NonEncodedHtmlString.Empty;

                if (result.Errors.Any(error => error.MemberNames.Any(n => n.Equals(name, StringComparison.OrdinalIgnoreCase))))
                    return new NonEncodedHtmlString("error");
            }

            return NonEncodedHtmlString.Empty;
        }
    }
}