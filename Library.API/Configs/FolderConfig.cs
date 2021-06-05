using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UtilityServices.Settings;

namespace Library.API.Configs
{
    public static class FolderConfig
    {
        public static void RegisterFolders(this IServiceCollection services, IConfiguration configuration)
        {
            var folderSettings = new FolderSettings();
            configuration.Bind(nameof(FolderSettings), folderSettings);
            services.AddSingleton(folderSettings);
        }
    }
}
