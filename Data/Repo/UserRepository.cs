﻿using EmployeeManagementSystem.Interface;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EmployeeManagementSystem.Data.Repo
{
    public class UserRepository:IUserRepository
    {
        private readonly EmployeeDBContext _dbContext;
        private string passwordText;

        public UserRepository(EmployeeDBContext dBContext)
        {
            this._dbContext = dBContext;
        }

        public async Task<User> Authenticate(string userName, string passwordText)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            // && x.Password == password
            if (user == null || user.PasswordKey==null)

                return null;
            if (!MatchPasswordHash(passwordText, user.Password, user.PasswordKey))
                return null;
            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                        return false;
                }

                return true;
            }
        }

        public void Register(string userName, string password)
        {
            byte[] passwordHash, passwordKey;
            using(var hmac=new HMACSHA512())
            {
                passwordKey=hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
            User user = new User();
            user.UserName = userName;
            user.Password = passwordHash;
            user.PasswordKey = passwordKey;
            _dbContext.Users.Add(user);
        }

        public async Task<bool> UserAlreadyExists(string userName)
        {
            return await _dbContext.Users.AnyAsync(x => x.UserName == userName);
        }
    }
}
