using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBotCoockie
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();



        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            string BotToken = "NDk5MjY5NDAyMDYwMTI4MjU4.Dp52CQ.ZsuCtQ__6R0Ro7T1qcvOYo-ufgw";

            //event subscriptions

            _client.Log += Log;

            await RegisterCommandsAsync();

            await _client.LoginAsync(TokenType.Bot, BotToken);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var Message = arg as SocketUserMessage;

            if (Message is null || Message.Author.IsBot)
            {
                return;
            }

            int ArgPos = 0;


            if (Message.HasStringPrefix("&&", ref ArgPos) || Message.HasMentionPrefix(_client.CurrentUser, ref ArgPos))
            {
                var context = new SocketCommandContext(_client, Message);


                var result = await _commands.ExecuteAsync(context, ArgPos, _services);

                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
