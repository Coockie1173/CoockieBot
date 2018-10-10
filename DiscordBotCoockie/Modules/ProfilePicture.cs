using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace DiscordBotCoockie.Modules
{
    public class ProfilePicture : ModuleBase<SocketCommandContext>
    {
        [Command("grabprofilepicture")]
        public async Task PingAsync(SocketGuildUser i)
        {
            var picture = i.GetAvatarUrl(ImageFormat.Auto);

            await ReplyAsync(picture);

        }
    }
}
