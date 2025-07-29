using AWC.CQRS;
using AWC.Infra.Data;
using AWC.Infra.Interfaces;
using AWC.UI.Components;
using AWC.UI.Middlewares;
using AWC.UI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning);

    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
    builder.Services.AddScoped<ITokenService, TokenService>();
    builder.Services.AddScoped<INavigationService, NavigationService>();

builder.Services.AddScoped<ICsvExporterService, CsvExporterService>();
builder.Services.AddScoped<ICsvImporterService, CsvImporterService>();

builder.Services.AddScoped<IFileUploadService, FileUploadService>();
    builder.Services.AddScoped<IPermissionStylingService, PermissionStylingService>();

    builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

    builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer();

    builder.Services.Configure<RouteOptions>(options =>
    {
        options.ConstraintMap.Add("string", typeof(string));
    });

    builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();

    #region Dependency Injection
    builder.Services.AddApplication();
    #endregion

    // Register DataAccessLayer (use your connection string here)
    builder.Services.AddSingleton(_ =>
    {
#nullable disable
        return new CollegeContext(builder.Configuration.GetConnectionString("DefaultConnection")
                                 ?? throw new InvalidOperationException());
    });

    builder.Services.AddAuthorization();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        app.UseHsts();
    }

    // Middleware to show the "Under Construction" page on 404 errors
    app.Use(async (context, next) =>
    {
        await next();

        if (context.Response.StatusCode == 404)
        {
            context.Response.Redirect("/underconstruction");
        }
    });

    //app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseAntiforgery();

    app.UseMiddleware<AppendHostMiddleware>();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();

    app.Run();

