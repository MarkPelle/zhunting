﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using zhunting.Data.Models;
using zhunting.DataAccess.Repositories;

namespace zhunting.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        [HttpGet]
        public async Task<List<Staff>> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _staffRepository.GetStaff();
            }
            catch (InvalidOperationException)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return null;
            }
        }

        [HttpPost]
        public async Task Create([FromBody] Staff staff)
        {
            await _staffRepository.AddStaff(staff);
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _staffRepository.RemoveStaff(id);
        }

        [HttpPatch]
        public async Task Update(Guid id, JsonPatchDocument<Staff> patchDocument)
        {
            var toBePatched = await _staffRepository.GetStaff(id);
            patchDocument.ApplyTo(toBePatched);
            await _staffRepository.EditStaff(toBePatched);
        }
    }
}
