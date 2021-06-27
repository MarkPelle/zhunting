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

        public Task AddStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        public Task EditStaff(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Staff>> GetStaff()
        {
            return await _dbContext.Staff.AsNoTracking().ToListAsync();
        }

        public async Task<Staff> GetStaff(string name)
        {
            return await _dbContext.Staff.AsNoTracking().SingleAsync(s => s.Name == name);
        }

        public Task RemoveStaff(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
