using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interfaces
{
    public interface IGameService
    {
        Task<bool> AddUser(User user);
        void RemoveUser(User user);
        void StartGame(User user);
        void GetConnectedUsers(User user);
    }
}
