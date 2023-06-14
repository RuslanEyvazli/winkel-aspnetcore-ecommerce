using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Middleware;
using WINKEL_ECOMMERCE.Models;


        Microsoft.VisualStudio.Web.CodeGeneration.Design.Program.Main(args);
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession(options => {
            options.IdleTimeout = TimeSpan.FromMinutes(20);
            options.Cookie.IsEssential = true;
        });


        builder.Services.AddDbContext<WINKEL_ApplicationDbContext>(options => 
            {
                options.UseLazyLoadingProxies();
<<<<<<< HEAD
                options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:Production")); 
=======
                options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:Default")); 
>>>>>>> b9795eb545a5c97e33d4e33e1211f5ef04577782
            });
        builder.Services
        .AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<WINKEL_ApplicationDbContext>()
                .AddDefaultTokenProviders()
                    .AddDefaultUI();
        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 3;

            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
            options.Lockout.AllowedForNewUsers = false;
        });
        // builder.Services.GetType().Assembly()
        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
        var app = builder.Build();
    
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();

        app.UseAuthorization();
        app.UseSession();
        //app.MapControllerRoute(
        //    name: "pagination",
        //    pattern: "{area:exists}/{controller=Sliders}/{action=Index}/{page?}");
        //app.Use(async (context,next) =>
        //{
        //    //Before
        //    byte[] buffer = Encoding.UTF8.GetBytes("Before Middleware - 1 ");
        //    await context.Response.Body.WriteAsync(buffer);
        //    await next();
        //    //After
        //    buffer = Encoding.UTF8.GetBytes("After Middleware - 1 ");
        //    await context.Response.Body.WriteAsync(buffer);
        //});
        //app.Use(async (context, next) =>
        //{
        //    //Before
        //    byte[] buffer = Encoding.UTF8.GetBytes("Before Middleware - 2 ");
        //    await context.Response.Body.WriteAsync(buffer);
        //    await next(context);
        //    //After
        //    buffer = Encoding.UTF8.GetBytes("After Middleware - 2 ");
        //    await context.Response.Body.WriteAsync(buffer);
        //});

        //For testing purpose
        //app.UseMiddleware<MyLogging>();
        //app.UseMyLogging();
        app.MapControllerRoute(

                name: "defualt-register-confirm",
                pattern: "registration-confirm.html",
                defaults: new
                {
                    area = "",
                    controller = "Auth",
                    action = "RegisterConfirm"
                }
            );
app.UseAuditLog();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
            
                name: "defualt-register-confirm",
                pattern:"registration-confirm.html",
                defaults: new
                {
                    area = "",
                    controller = "Auth",
                    action = "RegisterConfirm"
                } 
            );
            endpoints.MapGet("/checkout-coming-soon.html", async (context) =>
            {
                using(var sr = new StreamReader("views/static/checkout-coming-soon.html"))
                {
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync(sr.ReadToEnd());
                }
            });
          endpoints.MapControllerRoute(
            name : "areas",
            pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
          // endpoints.MapControllerRoute(name: "postsByUsername", pattern: "Posts/Index/{username?}");
        });
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");



        app.Run();



