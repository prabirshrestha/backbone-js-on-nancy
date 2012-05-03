namespace BackboneJsOnNancy.Web.Extensions
{
    using Nancy.ViewEngines.Razor;

    public static class HtmlHelperExtensions
    {
        public static bool IsAuthenticated<T>(this  HtmlHelpers<T> htmlHelper)
        {
            return htmlHelper.RenderContext.Context.CurrentUser != null;
        }
    }
}