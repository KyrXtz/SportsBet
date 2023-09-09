namespace SportsBet.Infrastructure.Configuration;

public static class ConsulVaultConfiguration
{
    public static IHostBuilder AddConsulVaultConfiguration(this IHostBuilder hostBuilder, Logger logger)
    {
        var consulVersion = GetOrSetEnvironmentVariable("CONSULVERSION", "V1", logger);
        var mainKeyPath = GetOrSetEnvironmentVariable("MAINKEYPATH", $"sportsbook/services.SportsBet/{consulVersion}/applications/configuration", logger);
        var consulAppSettingsKey = GetOrSetEnvironmentVariable("CONSULKEYAPI", "appsettings/api", logger);
        var vaultRoleId = GetOrSetEnvironmentVariable("VAULTROLEID", "e8cf74f6-e6d6-28b9-e2df-35e6de3530f5", logger);
        var vaultSecretId = GetOrSetEnvironmentVariable("VAULTSECRETID", "3f6f4674-6cd7-8344-b02e-02ff63385e99", logger);
        var vaultUrl = GetOrSetEnvironmentVariable("VAULTURL", "http://vault-lb.devgr-novibet.systems/", logger);
        var consulUrl = GetOrSetEnvironmentVariable("CONSULURL", "http://consul-lb.devgr-novibet.systems/", logger);
        var consulToken = GetOrSetEnvironmentVariable("CONSULTOKEN", "19f81e35-07f2-5b0a-4845-dbd11a28abcf", logger);

        VaultConfigSecretEvaluator.roleId = vaultRoleId;
        VaultConfigSecretEvaluator.secretId = vaultSecretId;
        VaultConfigSecretEvaluator.vaultServerUriWithPort = vaultUrl;

        return hostBuilder.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
        {
            configurationBuilder.AddConsulForConfiguration(
                    mainKeyPath,
                    consulAppSettingsKey,
                    options =>
                    {
                        options.ConsulConfigurationOptions = a =>
                        {
                            a.Address = new Uri(consulUrl);
                            a.Token = consulToken;
                        };
                        options.Optional = true;
                        options.ReloadOnChange = true;
                    },
                    VaultConfigSecretEvaluator.EvaluateSecretsWithVault);
        });
    }
    
    private static string GetOrSetEnvironmentVariable(string name, string defaultValue, Logger logger)
    {
        var envVar = Environment.GetEnvironmentVariable(name);

        if(envVar == null)
        {
            logger.Warn($"No value set for {name}. Defaulting to value: {defaultValue}");
            Environment.SetEnvironmentVariable(name,defaultValue);
            return defaultValue;
        }

        return envVar;
    }
}
