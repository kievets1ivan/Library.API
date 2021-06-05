using Library.DAL.EF;
using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Stores
{
    public interface IUdkStore
    {
        Task<Udk> Add(Udk udk);
        IQueryable<Udk> GetByUserId(Guid userId);
        Task<Udk> GetById(int udkId, bool asNoTracking = true);
        Task<Udk> Update(Udk udk);
        IQueryable<Udk> GetAll();
    }

    public class UdkStore : IUdkStore
    {
        private readonly ApplicationContext _context;

        public UdkStore(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Udk> Add(Udk udk)
        {
            await _context.Udks.AddAsync(udk);
            await _context.SaveChangesAsync();
            return udk;
        }

        public IQueryable<Udk> GetAll()
        {
            return _context.Udks.AsNoTracking().OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<Udk> GetByUserId(Guid userId)
        {
            return _context.Udks.AsNoTracking().Where(x => x.UserId == userId).OrderByDescending(x => x.ModifiedOn);
        }

        public async Task<Udk> GetById(int udkId, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return await _context.Udks.AsNoTracking().SingleOrDefaultAsync(u => u.Id == udkId);
            }

            return await _context.Udks.SingleOrDefaultAsync(u => u.Id == udkId);
        }

        public async Task<Udk> Update(Udk udk)
        {
            _context.Update(udk);
            await _context.SaveChangesAsync();
            return await GetById(udk.Id);
        }
    }
}
