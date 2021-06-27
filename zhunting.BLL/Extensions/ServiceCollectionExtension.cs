using Microsoft.Extensions.DependencyInjection;
using zhunting.BLL.Repositories;
using zhunting.DataAccess.Repositories;

namespace zhunting.BLL.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IHuntableRepository, HuntableRepository>();
            services.AddTransient<IMediaRepository, MediaRepository>();
            services.AddTransient<IStaffRepository, StaffRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
        }
    }
}
