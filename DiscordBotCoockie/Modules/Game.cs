using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotCoockie.Modules
{
    public class Game : ModuleBase<SocketCommandContext>
    {
        [Command("game")]
        public async Task PingAsync(SocketGuildUser p)
        {
            if (p.Game != null)
            { 
                await ReplyAsync((p.Nickname + " is playing " + p.Game));
            }
            else
            {
                await ReplyAsync(p.Nickname + " is not playing anything.");
            }

        }
    }
}
