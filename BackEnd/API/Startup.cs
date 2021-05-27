using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Repository.Repositorys;
using Repository.Interfaces;
using Business;
using Business.Interface;
using Business.Excecoes;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR", false);

            //REPOSITORYS
            
            //Entity Framework
            services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase("Categoria_Produto"));
            services.AddScoped<ApiContext, ApiContext>();
            //services.AddTransient<ICategoriaRepository, CategoriaRepositoryEntity>();
            //services.AddTransient<IProdutoRepository, ProdutoRepositoryEntity>();


            //Dapper Framework
            var conexaoBanco = new InMemoryDatabase();
            services.AddTransient(provider => new Func<IDbConnection>(() => { return conexaoBanco.Connection; }));
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryDapper>();
            services.AddTransient<IProdutoRepository, ProdutoRepositoryDapper>();

            //USE CASES
            //Categoria
            services.AddTransient<ICategoriaGetAllUseCase, CategoriaGetAllUseCase>();
            services.AddTransient<ICategoriaGetByIdUseCase, CategoriaGetByIdUseCase>();
            services.AddTransient<ICategoriaGetByDescriptionUseCase, CategoriaGetByDescriptionUseCase>();
            services.AddTransient<ICategoriaPostUseCase, CategoriaPostUseCase>();
            services.AddTransient<ICategoriaUpdateUseCase, CategoriaUpdateUseCase>();
            services.AddTransient<ICategoriaDeleteUseCase, CategoriaDeleteUseCase>();
            //Produto
            services.AddTransient<IProdutoGetAllUseCase,ProdutoGetAllUseCase>();
            services.AddTransient<IProdutoGetByIdUseCase, ProdutoGetByIdUseCase>();
            services.AddTransient<IProdutoGetByDescriptionUseCase, ProdutoGetByDescriptionUseCase>();
            services.AddTransient<IProdutoPostUseCase, ProdutoPostUseCase>();
            services.AddTransient<IProdutoUpdateUseCase, ProdutoUpdateUseCase>();
            services.AddTransient<IProdutoDeleteUseCase, ProdutoDeleteUseCase>();

            //CORs
            services.AddCors();
            
                services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            //CORS
            app.UseCors(
                builder =>
                {
                    builder
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        // .SetIsOriginAllowed((host) => true);
                        .SetIsOriginAllowed(isOriginAllowed: _ => true);
                });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use(async (context, next) =>
            { 
                try
                { 
                    await next(); 
                }
                catch (BusinessException ex) 
                {
                    context.Response.ContentType = "text/plain"; 
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
                    await context.Response.WriteAsync(ex.Message); 
                } 
            });

        }
    }
}
