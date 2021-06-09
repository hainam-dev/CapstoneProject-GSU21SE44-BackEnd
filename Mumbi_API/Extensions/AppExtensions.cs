using Microsoft.AspNetCore.Builder;

namespace Mumbi_API.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mumbi Web API");
            });
        }

        //public static void UseErrorHandlingMidlleware(this IApplicationBuilder app)
        //{
        //    app.UseMiddleware<ErrorHandlerMiddleware>();
        //}
    }
}
