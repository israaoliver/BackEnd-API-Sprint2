using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Senai_Tarde
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Adiciona MVC ao Projeto
                .AddMvc()
                //Define a versão compativel do .NET Core compativel - 2.1
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })

            .AddJwtBearer("JwtBearer", options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   //Quem esta solicitando
                   ValidateIssuer = true,

                   //Quem ta Recebendo
                   ValidateAudience = true,

                   ValidateLifetime = true,

                   // Forma de criptografia
                   IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Filmes-chave-autenticacao")),

                   ClockSkew = TimeSpan.FromMinutes(30),

                   ValidIssuer = "Filmes.WebApi",

                   ValidAudience = "Filmes.WebApi"

               };

           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //define o uso da autenticação
            app.UseAuthentication();

            //Define o uso do MVC
            app.UseMvc();

        }
    }
}
