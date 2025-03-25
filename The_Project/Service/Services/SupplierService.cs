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

namespace Service.Services
{
    public class SupplierService : ISupplierService<Supplier>
    {   
        private readonly IRepository<Supplier> repository;
        private readonly IConfiguration config;

        public SupplierService(IRepository<Supplier> repository, IConfiguration config)
        {
            this.repository = repository;
            this.config = config;
        }
        public async Task<Supplier> AddItem(Supplier item)
        {
            return await repository.AddItem(item);
        }

        public async Task DeleteItem(int id)
        {
           await repository.DeleteItem(id);
        }

        public async Task<List<Supplier>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public Task<Supplier> UpDateItem(int id, Supplier item)
        {
            throw new NotImplementedException();
        }
        public async Task<Supplier> GetByPasswordAndEmail(string Pssword, string Email)
        {
            var suppliers = await repository.GetAll();
            var supplier = suppliers.FirstOrDefault(u => u.Password == Pssword && u.Email == Email);
            if (supplier == null)
            {
                throw new Exception("User not found"); // או אפשר להחזיר null ולתת לקריאה החיצונית לטפל בזה
            }
            return supplier;
        }
        public string Generate(Supplier supplier)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var purchasingGroupsJson = JsonSerializer.Serialize(supplier.PurchasingGroups);

            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, supplier.Id.ToString()), // מזהה ייחודי
               new Claim(ClaimTypes.Name, supplier.Name), // שם המשתמש **אמיתי**
               new Claim(ClaimTypes.Email, supplier.Email), // אימייל
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
