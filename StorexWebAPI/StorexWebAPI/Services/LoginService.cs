using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StorexWebAPI.Data;
using StorexWebAPI.Models;
using StorexWebAPI.Models.Dtos;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StorexWebAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly DataContext _datacontext;

        public LoginService(DataContext datacontext)
        {
            _datacontext = datacontext;

        }

        public async Task<UserDto> Authentication(UserDto request)
        {
            request.Status = false;
            IEnumerable<dynamic>? user_list;

            user_list = await _datacontext.User.Where(obj => obj.Username.Contains(request.Username)).ToListAsync();

            if (user_list.Count() > 0)
            {
                var user = user_list.FirstOrDefault();
               

                if (user.Username != request.Username)
                {
                    return request;
                }


                if (!VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                {

                    return request;
                }

                request.Status = true;
                request.Role = user.Role;

            }
            else
            {
                return request;
            }

            return request;

        }


        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        public User Register(UserDto request)
        {
            User user = new User();

            CreatePasswordHash(request.Password, out byte[] passwordSalt, out byte[] passwordHash);


            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            user.Username = request.Username;


            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

    }
}
