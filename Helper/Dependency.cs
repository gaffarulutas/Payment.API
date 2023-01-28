using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Payment.API.EndPoints;
using Payment.API.Services;
using System.Text.Unicode;

namespace Payment.API.Helper
{
    public static class Dependency
    {
        public static void MapDependency(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapPaymentEndpoints();

            app.Run();

        }
        public static IServiceCollection MapServices(this IServiceCollection services)
        {
            services.AddAntiforgery(o => o.HeaderName = "CSRF-TOKEN");
            services.AddWebEncoders(o => {
                o.TextEncoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);
            });
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBankService, BankService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddRazorPages();

            services.Configure<FormOptions>(x =>
            {
                x.ValueCountLimit = int.MaxValue;
            });

            return services;
        }
    }
}
