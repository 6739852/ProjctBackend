using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Entities;
using Repository.Intefaces;
using Service.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Services
{
    public class UserService : IUserService<User>
    { 
        private readonly IRepository<User> repository;
        private readonly IConfiguration config;

        public UserService(IRepository<User> repository, IConfiguration config)
        {
            this.repository = repository;
            this.config = config;
        }
        public async Task<User> AddItem(User item)
        {
           return await repository.AddItem(item);
        }

        public async Task DeleteItem(int id)
        {
           await repository.DeleteItem(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
           return await repository.GetById(id);
        }

        public async Task<User?> UpDateItem(int id, User item)
        {
            return await repository.UpDateItem(id, item);
        }
        public async Task<User> GetByPasswordAndEmail(string Pssword, string Email)
        {
            var users = await repository.GetAll();
            var user=users.FirstOrDefault(u => u.Password == Pssword && u.Email == Email);
            if (user == null)
            {
                throw new Exception("User not found"); // או אפשר להחזיר null ולתת לקריאה החיצונית לטפל בזה
            }
            return user;
        }
        //public string Generate(User user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {

        //        new Claim(ClaimTypes.NameIdentifier,user.Name),
        //        new Claim(ClaimTypes.Email,user.Email),
        //        new Claim("Password", user.Password),

        //    };
        //    var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(60),
        //        signingCredentials: credentials);
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        //public string Generate(User user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var purchasingGroupsJson = JsonSerializer.Serialize(user.PurchasingGroups);
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // מזהה ייחודי
        //        new Claim(ClaimTypes.Name, user.Name), // שם המשתמש **אמיתי**
        //        new Claim(ClaimTypes.Email, user.Email), // אימייל
        //        new Claim("PurchasingGroups", purchasingGroupsJson) // קבוצות רכישה תחת Claim מותאם אישית
        //};
        //    var token = new JwtSecurityToken(
        //        config["Jwt:Issuer"], // מנפיק הטוקן (Issuer)
        //        config["Jwt:Audience"], // מי יכול להשתמש בטוקן (Audience)
        //        claims, // המידע בתוך הטוקן
        //        expires: DateTime.Now.AddMinutes(60), // זמן תפוגה - שעה אחת
        //        signingCredentials: credentials // החתימה הדיגיטלית של הטוקן
        //    );
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var purchasingGroupsJson = JsonSerializer.Serialize(user.PurchasingGroups);

            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // מזהה ייחודי
               new Claim(ClaimTypes.Name, user.Name), // שם המשתמש **אמיתי**
               new Claim(ClaimTypes.Email, user.Email), // אימייל
               new Claim(ClaimTypes.Actor, purchasingGroupsJson) // קבוצות רכישה תחת Claim מותאם אישית
            };

            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
