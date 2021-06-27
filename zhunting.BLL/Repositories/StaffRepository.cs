using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.Data.Models;
using zhunting.DataAccess;
using zhunting.DataAccess.Repositories;

namespace zhunting.BLL.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ZhuntingDbContext _dbContext;

        public StaffRepository(ZhuntingDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task AddStaff(Staff staff)
        {
            await _dbContext.Staff.AddAsync(staff);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditStaff(Staff staff)
        {
            _dbContext.Update(staff);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Staff>> GetStaff()
        {
            return await _dbContext.Staff.AsNoTracking().ToListAsync();
        }

        public async Task<Staff> GetStaff(string name)
        {
            return await _dbContext.Staff.AsNoTracking().SingleAsync(s => s.Name == name);
        }

        public async Task<Staff> GetStaff(Guid id)
        {
            return await _dbContext.Staff.AsNoTracking().SingleAsync(s => s.ID == id);
        }

        public async Task RemoveStaff(Guid id)
        {
            var getStaff = GetStaff(id);
            _dbContext.Remove(getStaff);
            await _dbContext.SaveChangesAsync();
        }
    }
}
