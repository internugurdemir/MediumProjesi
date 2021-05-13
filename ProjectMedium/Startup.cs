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
         * Servera göç sonucu oluþum
         * Package Manager Consoleda
         * Default package kýsmý önemli kontrol edilmeli
         * PM> install-package Microsoft.EntityFrameworkCore.Tools  yazýlýr
         * add-migration first   yazýlýr PM ye   Migration klasörü oluþtu
         * Migration up ve down ikili method barýndýrýr=>Migrattionda devamý :
         *                          C:\Users\ardah\source\Workspaces\Uður Demir Medium Blog Work\MVCProject\ProjectMedium\
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
                 *          Servisler bölümü =Modül=Kütüphane
                 *          Belirli iþlere odaklanmýþ olan servislerin(ödeme desteði gibi...)
                 *          modülün dahili için
               *  services.AddControllersWithViews(); Uygulama MVC mimarisi ile çalýþacaðýný biliyor
               *  
               */
            //services.AddDbContext<MediumDbContext2>(options => options.UseSqlServer("server=.; database=ProjectMediumV2; uid=sa; pwd=123"));
            //Benim context nesnemi kullan bu nesneyi ayaða kaldýr baðlantý için bu baðlantýyýsqlserverprovider üzerinden mssqlle iþ 
            #endregion
            services.AddControllersWithViews();

            services.AddDbContext<MediumDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("MediumDbConnection")));

            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));


            #region Byinternet
            //Metotlarý oluituruduðumuz generic repostitory'e yönlendirme için
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
            ////connection string adresinin yazmak için (use.sqlserver...nugetii) microsoft.efcore.sqlserver nugeti yüklendi 
            ////package manager console diye bir tool ile de yüklenebiloyr konsol aracýlýðýyla
            ////using micro 
            //#endregion


            ////services.AddDbContext<MediumDbContext>(options =>
            ////{
            ////    services.AddControllersWithViews();
            ////    services.AddDbContext<MediumDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EkibimizConnection")));

            ////    options.UseSqlServer("server=.; database=ProjectMedium; uid=sa; pwd=123");
            ////    //Microsoft.EntityFrameworkCore.Proxies nuget yüklendi
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

            /*Gelen isteðin rotasý bu middlewave sayesinde gelen isteðin hangi controllerlara gideceði
             *Bunlarda static kullandým deriz 
             */
            app.UseRouting();


            #region usestaticfiles

            /*wwwroot klosörünü açtýktan sonra kurduk-> proje çalýþtýðýnda sayfa açýlýrken okunur
             *          þunu söyler=>bu sayfada static doosyalar kullandým onu kullan
             *          
             */ 
            #endregion
            app.UseStaticFiles();
            app.UseSession();
            //app.UseAuthorization();


            //istek yaparken vvarýþ noktasýný yapýlan isteðin adresi URL'i
            #region Text için id=001;
            /*endpoints.MapDefaultControllerRoute(); diyorki : Adds endpoints for controller actions to the Microsoft.AspNetCore.Routing.IEndpointRouteBuilder
                    *                                            and adds the default route 
                    *                                            {controller=Home}        /       {action=Index}/{id?}.
                    *                   Default olan end poin þemasý
                    *                   Yapýlacak istekler bu þemaya uygun olmalý
                    *                   Hangi controller Hangi action(metodu)ý yapacak
                    *                   https://www...com/personel/getir          personel=Home olur  controller    /    getir=index olur action
                    *                   id? nullable
                    *                   
                    *                   controller ve action özeldir mimari bunu bilir
                    *                   
                    *                   {} parantezler içerisindeki parametrelerr tanýmlayabiliriz ama controller zaten ön tanýmlý
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
