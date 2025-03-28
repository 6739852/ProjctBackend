﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Intefaces;

namespace Repository.Repositories
{
    public class UserRepository : IGetPurchasigGroups<User>
    {
        private readonly IContext context;
        public UserRepository(IContext context)
        {
            this.context = context;
        }
        public async Task<User> AddItem(User item)
        {
            await context.Users.AddAsync(item);
            await context.Save();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            context.Users.Remove(await GetById(id));   
            await context.Save();
        }

        public async Task<List<User>> GetAll()
        {
            return await context.Users.ToListAsync();

        }

        public async Task<User> GetById(int id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PurchasingGroup>> GetPurchasingGroupsById(int id)
        {
            return await context.PurchasingGroups
                .Include(x => x.Users) // כולל את רשימת המשתמשים
                .Where(x => x.Users.Any(u => u.Id == id)) // מסנן קבוצות שבהן ה- UserId נמצא
                .ToListAsync();
        }

        public async Task<List<WantToOpen>> GetWantToOpenById(int id)
        {
            return await context.WantToOpens
             .Where(x => x.UserId == id)
             .ToListAsync();
        }

        public async Task<User> UpDateItem(int id, User item)
        {
            var user=await GetById(id);
            user.Name = item.Name;
            user.Email = item.Email;
            user.Password = item.Password;
            user.Alerts = item.Alerts;
            await context.Save();
            return user;
        }
    }
}
