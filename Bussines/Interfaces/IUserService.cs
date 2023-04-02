using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        User? GetUser(string connectionId);
        User? RemoveUser(string connectionId);
    }
}
