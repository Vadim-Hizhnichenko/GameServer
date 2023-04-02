using Data.Models;
using GameServer.Configure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using System.Threading.Tasks;

namespace GameServer.Hubs
{
    public class GameHub : Hub
    {
        private readonly List<Player> _players = new List<Player>();
        private readonly UserManager<User> _userManager;
        public async Task JoinGame(string playerName)
        {
            // Добавляем пользователя в игру
            await Clients.All.SendAsync("PlayerJoined", playerName);
            Logging.LogEvent($"Player {playerName} logged in");
        }

        public async Task LeaveGame(string playerName)
        {
            // Удаляем пользователя из игры
            await Clients.All.SendAsync("PlayerLeft", playerName);
            Logging.LogEvent($"Player {playerName} logged out");
        }

        public async Task SendMessage(string message)
        {
            var user = await _userManager.GetUserAsync(Context.User);
            await Clients.All.SendAsync("ReceiveMessage", user.Username, message);
        }

        public async Task SendNotificationToPlayer(string playerId, string notification)
        {
            await Clients.User(playerId).SendAsync("ReceiveNotification", notification);

            // Логирование отправки оповещения
            Log.Information("Notification sent to player {PlayerId}: {Notification}", playerId, notification);
        }


        public async Task UpdatePlayer(Player player)
        {
            var existingPlayer = _players.FirstOrDefault(p => p.UserId == player.UserId);
            if (existingPlayer == null)
            {
                _players.Add(player);
            }
            else
            {
                // Update player data
                existingPlayer.Level = player.Level;
                existingPlayer.BambooCount = player.BambooCount;
                existingPlayer.GoldCount = player.GoldCount;
                existingPlayer.Buildings = player.Buildings;
                existingPlayer.Pandas = player.Pandas;
            }

        }

    }
}
