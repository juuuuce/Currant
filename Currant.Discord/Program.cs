using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;

namespace Currant;

public class Currant
{
    public Currant(CommandsNextExtension commands)
    {
        Commands = commands;
    }

    public static DiscordClient Client { get; set; } = null!;
    public CommandsNextExtension Commands { get; set; }

    private static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }

    private static async Task MainAsync()
    {
        var discordConfig = new DiscordConfiguration()
        {
            Token = "",
            TokenType = TokenType.Bot,
            AutoReconnect = true,
            MinimumLogLevel = LogLevel.Debug,
            Intents = DiscordIntents.AllUnprivileged,
        };
        
        await Client.ConnectAsync();
        await Task.Delay(-1);
    }
}