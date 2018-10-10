using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Discord.WebSocket;
using System.Linq;
using System.Threading;

namespace DiscordBotCoockie.Modules
{
    public class RoleStrip : ModuleBase<SocketCommandContext>
    {
        [Command("rolestrip")]
        public async Task PingAsync(SocketGuildUser userName)
        {
            Console.WriteLine("trying to run rolestrip on: " + userName);

            var user = Context.User as SocketGuildUser;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "Coockerlord");


            if(!userName.Roles.Contains(role) || user.GuildPermissions.Administrator)
            {
                if (user.GuildPermissions.Administrator)
                {
                    await ReplyAsync("Running rolestrip on " + userName.Mention);
                    foreach(SocketRole r in userName.Roles)
                    {
                        Console.WriteLine(r);

                        if (r.Name != "@everyone")
                        {
                            await userName.RemoveRoleAsync(r);
                        }
                    }
                }
            }
        }



    }

}
