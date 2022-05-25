using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Currant;

public class Currant
{
    public Currant(CommandsNextExtension commands)
    {
        Commands = commands;
    }

    public static DiscordClient Client { get; set; } = null!;
    public static CommandsNextExtension Commands { get; set; }

    private static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }

    private static async Task MainAsync()
    {
        var appConfig = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        
        var discordConfig = new DiscordConfiguration
        {
            Token = appConfig.GetValue<string>("token"),
            TokenType = TokenType.Bot,
            AutoReconnect = true,
            MinimumLogLevel = LogLevel.Debug,
            Intents = DiscordIntents.AllUnprivileged,
        };
        Client = new DiscordClient(discordConfig);

        var commandsConfig = new CommandsNextConfiguration
        {
            StringPrefixes = new []{appConfig.GetValue<string>("commandPrefix")},
            EnableMentionPrefix = true,
            EnableDms = false,
            IgnoreExtraArguments = true,
            DmHelp = true,
        };
        Commands = Client.UseCommandsNext(commandsConfig);
        

        await Client.ConnectAsync();
        await Task.Delay(-1);
    }
}