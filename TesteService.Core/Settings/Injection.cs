using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteService.Core.Handlers;
using TesteService.Core.Infrastructure.Context;
using TesteService.Core.Infrastructure.Repositories;
using TesteService.Core.Interfaces;
using TesteService.Core.Profiles;

namespace TesteService.Core.Settings
{
    public class Injection
    {
        public static void Configure(IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<TesteDb>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            service.AddMediatR(typeof(UserHandler).Assembly);

            MapperConfiguration settingsAutoMapper = new MapperConfiguration(settings =>
            {
                settings.AddProfile(new UserProfile());
            });

            IMapper mapper = settingsAutoMapper.CreateMapper();
            service.AddSingleton(mapper);

            service.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
