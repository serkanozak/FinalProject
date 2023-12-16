//using Autofac;
//using Autofac.Core;
//using Autofac.Extensions.DependencyInjection;
//using Business.DependencyResolvers.Autofac;
//using Core.Utilities.IoC;
//using Core.Utilities.Security.Encryption;
//using Core.Utilities.Security.JWT;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;

//var builder = WebApplication.CreateBuilder(args);

////builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
////builder.Host.ConfigureContainer<ContainerBuilder>(
////builder => builder.RegisterModule(new AutofacBusinessModule()));

//// Add services to the container.

//builder.Services.AddControllers();

//var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidIssuer = tokenOptions.Issuer,
//            ValidAudience = tokenOptions.Audience,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
//        };
//    });
//ServiceTool.Create(services);


//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//builder.Host.ConfigureContainer<ContainerBuilder>(options =>
//{
//    options.RegisterModule(new AutofacBusinessModule());
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

//using Autofac;
//using Autofac.Extensions.DependencyInjection;
//using Business.Abstract;
//using Business.Concrete;
//using Business.DependencyResolvers.Autofac;
//using DataAccess.Abstract;
//using DataAccess.Concrete.EntityFramework;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.


//builder.Services.AddControllers();
////builder.Services.AddSingleton<IProductService, ProductManager>();
////builder.Services.AddSingleton<IProductDal, EfProductDal>();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
////Autofac
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//builder.Host.ConfigureContainer<ContainerBuilder>(options =>
//{
//    options.RegisterModule(new AutofacBusinessModule());
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //AutoFac Ekleme kýsmý
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(
        builder => builder.RegisterModule(new AutofacBusinessModule()));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddSingleton<IProductService,ProductManager>();
        //builder.Services.AddSingleton<IProductDal,EfProductDal>();
        //Autofac, Ninject,CastleWindsor, StructureMap, LightInject, DryInject --> IoC Container
        //AOP

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

