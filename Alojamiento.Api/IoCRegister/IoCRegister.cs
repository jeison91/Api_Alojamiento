using Alojamiento.Domain.IRepository;
using Alojamiento.Domain.IServices;
using Alojamiento.Domain.UseCase;
using Alojamiento.Infrastructure;
using Alojamiento.Infrastructure.Repository;
using Alojamiento.Services.Services;
using Alojamiento.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Alojamiento.Api.IoCRegister
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services, string? conectionString = "")
        {
            AddRegisterDBContext(services, conectionString);
            AddRegisterRepositories(services);
            AddRegisterServices(services);
            return services;
        }

        private static void AddRegisterDBContext(this IServiceCollection services, string? conectionString)
        {
            services.AddDbContext<AlojamientoDbContext>(cfg =>
            {
                cfg.UseSqlServer(conectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IHotelServices, HotelServices>();
            services.AddTransient<IHotelServicesPort, HotelUseCase>();

            services.AddTransient<IHabitacionServices, HabitacionServices>();
            services.AddTransient<IHabitacionServicesPort, HabitacionUseCase>();

            services.AddTransient<IReservaServices, ReservaServices>();
            services.AddTransient<IReservasServicesPort, ReservasUseCase>();

            services.AddTransient<IClienteServicesPort, ClienteUseCase>();
            services.AddTransient<IEnviarCorreoServices, EnviarCorreoServices>();

            return services;
        }

        private static void AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHabitacionRepository, HabitacionRepository>();
            services.AddScoped<IReservasRepository, ReservasRepository>();
            services.AddScoped<IHuespedRepository, HuespedRepository>();
            services.AddScoped<IReservaHuespedRepository, ReservaHuespedRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
