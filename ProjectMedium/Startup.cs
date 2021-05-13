using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectMedium.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectMedium
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /* Migration 475219233Part1
         * Servera g�� sonucu olu�um
         * Package Manager Consoleda
         * Default package k�sm� �nemli kontrol edilmeli
         * PM> install-package Microsoft.EntityFrameworkCore.Tools  yaz�l�r
         * add-migration first   yaz�l�r PM ye   Migration klas�r� olu�tu
         * Migration up ve down ikili method bar�nd�r�r=>Migrattionda devam� :
         *                          C:\Users\ardah\source\Workspaces\U�ur Demir Medium Blog Work\MVCProject\ProjectMedium\
         *                                                                              Migrations\20210325071058_first.cs
         */

        /* This method gets called by the runtime. Use this method to add services to the container.
            For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        */

        public void ConfigureServices(IServiceCollection services)
        {

            #region Bilgi
            /*MVC servis olarak gelir
                 * ConfigureServices
                 *          Servisler b�l�m� =Mod�l=K�t�phane
                 *          Belirli i�lere odaklanm�� olan servislerin(�deme deste�i gibi...)
                 *          mod�l�n dahili i�in
               *  services.AddControllersWithViews(); Uygulama MVC mimarisi ile �al��aca��n� biliyor
               *  
               */
            //services.AddDbContext<MediumDbContext2>(options => options.UseSqlServer("server=.; database=ProjectMediumV2; uid=sa; pwd=123"));
            //Benim context nesnemi kullan bu nesneyi aya�a kald�r ba�lant� i�in bu ba�lant�y�sqlserverprovider �zerinden mssqlle i� 
            #endregion
            services.AddControllersWithViews();

            services.AddDbContext<MediumDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("MediumDbConnection")));

            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));


            #region Byinternet
            //Metotlar� oluiturudu�umuz generic repostitory'e y�nlendirme i�in
            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x=>
                {
                    x.LoginPath = "/Login/Index";
                });
            //services.AddMvc(config=>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //                    .RequireAuthenticatedUser()
            //                    .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});
            #endregion



            #region Deneme
            //#region Bilgi
            ////connection string adresinin yazmak i�in (use.sqlserver...nugetii) microsoft.efcore.sqlserver nugeti y�klendi 
            ////package manager console diye bir tool ile de y�klenebiloyr konsol arac�l���yla
            ////using micro 
            //#endregion


            ////services.AddDbContext<MediumDbContext>(options =>
            ////{
            ////    services.AddControllersWithViews();
            ////    services.AddDbContext<MediumDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EkibimizConnection")));

            ////    options.UseSqlServer("server=.; database=ProjectMedium; uid=sa; pwd=123");
            ////    //Microsoft.EntityFrameworkCore.Proxies nuget y�klendi
            ////    options.UseLazyLoadingProxies(true);

            ////}); 
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            /*Gelen iste�in rotas� bu middlewave sayesinde gelen iste�in hangi controllerlara gidece�i
             *Bunlarda static kulland�m deriz 
             */
            app.UseRouting();


            #region usestaticfiles

            /*wwwroot klos�r�n� a�t�ktan sonra kurduk-> proje �al��t���nda sayfa a��l�rken okunur
             *          �unu s�yler=>bu sayfada static doosyalar kulland�m onu kullan
             *          
             */ 
            #endregion
            app.UseStaticFiles();
            app.UseSession();
            //app.UseAuthorization();


            //istek yaparken vvar�� noktas�n� yap�lan iste�in adresi URL'i
            #region Text i�in id=001;
            /*endpoints.MapDefaultControllerRoute(); diyorki : Adds endpoints for controller actions to the Microsoft.AspNetCore.Routing.IEndpointRouteBuilder
                    *                                            and adds the default route 
                    *                                            {controller=Home}        /       {action=Index}/{id?}.
                    *                   Default olan end poin �emas�
                    *                   Yap�lacak istekler bu �emaya uygun olmal�
                    *                   Hangi controller Hangi action(metodu)� yapacak
                    *                   https://www...com/personel/getir          personel=Home olur  controller    /    getir=index olur action
                    *                   id? nullable
                    *                   
                    *                   controller ve action �zeldir mimari bunu bilir
                    *                   
                    *                   {} parantezler i�erisindeki parametrelerr tan�mlayabiliriz ama controller zaten �n tan�ml�
                    * return text;                                           
                    */
            #endregion
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
            #region byinternet...
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");

            //}); 
            #endregion
        }
    }
}
