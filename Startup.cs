using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CaoLendario.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CaoLendario
{
    public class Startup
    {
        //o m�todo contrutor recebe a configura��o de dados carregada de appsettings.json
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        //Este metodo � usado para preparar os objetos compartilhados que ser�o usados
        //durante a aplica��o.Este compartilhamento � chamdo de Inje��o de
        //Depend�ncia.Por exemplo, quando um banco de dados depende das defini��es
        //de um modelo para ser criado.
        public void ConfigureServices(IServiceCollection services)
        {
            //configura os servi�os oferecidos pela Entity Framework Core para a classe contexto do banco de dados
            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(Configuration["Data:SportStoreProdutos:ConnectionString"]));
            //Associa o Reposit�rio EFProdutoRepositorio � interface IProdutoRepositorio
            //services.AddTransient<IProdutoRepositorio, EFProdutoRepositorio>();
            //services.AddTransient<IFabricanteRepositorio, EFFabricanteRepositorio>();
            //habilita o ASP.NET Core
            services.AddMvc();
        }

        //Este metodo � usado para preparar os componentes que recebem e processam
        //requisi��es HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Mostra detalhes das exce��es que ocorrem na aplica��o.
                app.UseDeveloperExceptionPage();
            }
            // Adiciona uma mensagem de resposta HTTP, como por exemplo 404 Not Found Responses.
            app.UseStatusCodePages();
            // habilita o suporte para arquivos contidos em wwwroot, como css e javascript
            app.UseStaticFiles();
            app.UseRouting();

            //definimos que a rota default ser� definida pela
            //invoca��o da action List que est� no controller Produto.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "Animal", action = "List" });
            });
            //ativa a popula��o do banco de dados quando a aplica��o for iniciada          
            //SeedData.EnsurePopulated(app);
        }
    }
}