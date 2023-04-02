using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Services
{
    internal class LoginService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LoginService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<User> Register(string username, string password)
        {
            var user = new User { Username = username, Password = password };
            _applicationDbContext.Users.Add(user);
            await _applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }
            //if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //{
            //    return null;
            //}
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
