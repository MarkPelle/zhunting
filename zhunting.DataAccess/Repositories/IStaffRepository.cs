using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface IStaffRepository
    {
        public Task<List<Staff>> GetStaff();
        public Task<Staff> GetStaff(string name);
        public  Task<Staff> GetStaff(Guid id);
        public Task EditStaff(Staff staff);
        public Task RemoveStaff(Guid id);
        public Task AddStaff(Staff staff);
    }
}
