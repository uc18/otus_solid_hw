using Microsoft.Extensions.Configuration;
using NumberCheckConsole.Options;

namespace NumberCheckConsole.Extension;

public static class ConfigurationExtension
{
    public static IConfigurationRoot GetConfiguration()
    {
        var env = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        return new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile($"appsettings.{env}.json", true)
            .AddJsonFile("appsettings.json", true)
            .AddUserSecrets<ApplicationRandomNumber>()
            .Build();
    }

    public static T GetOptions<T>(IConfiguration root, string sectionName)
    {
        return root.GetRequiredSection(sectionName).Get<T>();
    }
}