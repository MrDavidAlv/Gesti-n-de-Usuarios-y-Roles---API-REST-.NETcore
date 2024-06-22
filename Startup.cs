using empleadosFYMtech.Data;
using empleadosFYMtech.Interfaces.Repository;
using empleadosFYMtech.Interfaces.Service;
using empleadosFYMtech.Repositories;
using empleadosFYMtech.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Configurar Entity Framework Core con SQL Server
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "empleadosFYMtech API", Version = "v1" });
        });

        // Registrar el servicio de parámetros
        services.AddScoped<IPaisRepository, PaisRepository>();
        services.AddScoped<ICiudadRepository, CiudadRepository>();
        services.AddScoped<IParametersService, ParametersService>();

        // Registrar el servicio de usuario
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "empleadosFYMtech API v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
