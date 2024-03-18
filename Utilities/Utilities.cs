using lesson1.Interfaces;
using lesson1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace lesson1.Utilities
{
    public static class Utilities
    {
        public static void AddTask(this IServiceCollection services)
        {
            services.AddSingleton<ITaskService, TaskService>();
        }
    }
}