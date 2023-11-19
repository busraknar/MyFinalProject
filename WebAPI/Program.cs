using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Identity.Client;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        
        
        builder.Services.AddSingleton<IProductService, ProductManager>();
        builder.Services.AddSingleton<IProductDal, EfProductDal>();
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
}