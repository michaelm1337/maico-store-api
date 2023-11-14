using Application.Fakes;
using Application.Product;
using Application.Product.Ports;
using Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Adapters;
using Infrastructure.Adapters.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IoC
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(FakeMappingProfile));
            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(FakeValidations)));
            services.AddFluentValidationAutoValidation();
            services.AddDbContext<MaicoStoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("WriteDb")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}