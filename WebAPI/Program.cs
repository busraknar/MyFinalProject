using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolves.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Identity.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(
            builder => builder.RegisterModule(new AutofacBusinessModule()));

        // Add services to the container.

        builder.Services.AddControllers();
        
        
        //builder.Services.AddSingleton<IProductService, ProductManager>();
        //builder.Services.AddSingleton<IProductDal, EfProductDal>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        void ConfigureServices(IServiceCollection services)
        {   //AOP imkaný sunuyor - Autofac
            //Autofac, Ninject, CastleWindsor,StructureMap, LightInject, DryInject -->IoC Container, bu iþi yapar.
            builder.Services.AddControllers();
            builder.Services.AddSingleton<IProductService, ProductManager>();
            //Eðer baðýmlýlýk görürsen >karþýlýðý manager
            builder.Services.AddSingleton<IProductDal, EfProductDal>();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }


    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory( new AutofacServiceProviderFactory())
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Program>();
        });
}