using lesson2.Interfaces;
using lesson2.Services;

using Microsoft.Extensions.DependencyInjection;

namespace lesson2.Utilities
{
    public static class Utilities
    {
        public static void AddTask(this IServiceCollection services)
        {
            services.AddSingleton<ItaskService, TaskService>();
        }
    }
}