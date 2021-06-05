using Library.DAL.Constants;
using Library.DAL.EF;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Stores
{
    public interface IUserStore
    {
        Task<bool> CheckPassword(User user, string password);
        Task<IdentityResult> Create(User newUser, string password);
        Task<User> FindByEmail(string email);
        Task<Guid> GetBasicRoleId();
        Task<User> GetById(Guid id);
        Task<User> Update(User user);
    }

    public class UserStore : IUserStore
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ApplicationContext _context;

        public UserStore(UserManager<User> userManager,
                         RoleManager<IdentityRole<Guid>> roleManager,
                         ApplicationContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<User> FindByEmail(string email) => await _context.Users.AsNoTracking().Include(u => u.Role).SingleOrDefaultAsync(u => u.Email == email);

        public async Task<bool> CheckPassword(User user, string password) => await _userManager.CheckPasswordAsync(user, password);

        public async Task<IdentityResult> Create(User newUser, string password) => await _userManager.CreateAsync(newUser, password);

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Guid> GetBasicRoleId()
        {
            var userRole = await _roleManager.FindByNameAsync(Role.Basic);
            return userRole.Id;
        }
    }
}
