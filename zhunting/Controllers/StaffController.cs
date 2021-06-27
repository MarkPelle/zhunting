using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}
