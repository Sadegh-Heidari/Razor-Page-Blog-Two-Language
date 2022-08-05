namespace Two.Infrastructure
{
    public static class ExtentionMiddlewares
    {
        public static IApplicationBuilder CustomStaticFiles(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomStaticFileMiddleware>();
        }

        public static IApplicationBuilder CustomCookiMiddlerware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CookiCulture>();
        }
    }

}
