﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface IStaffRepository
    {
        public Task<List<Staff>> GetStaff();
        public Task<Staff> GetStaff(string name);
        public Task EditStaff(Guid id);
        public Task RemoveStaff(Guid id);
        public Task AddStaff(Staff staff);
    }
}
