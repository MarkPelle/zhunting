using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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
    public class HuntableController : ControllerBase
    {
        private readonly IHuntableRepository _huntableRepository;

        public HuntableController(IHuntableRepository huntableRepository)
        {
            _huntableRepository = huntableRepository;
        }

        [HttpGet]
        public async Task<List<Huntable>> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _huntableRepository.Get();
            }
            catch(OperationCanceledException)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return null;
            }
        }

        [Authorize]
        [HttpPost]
        public async Task Create([FromBody] Huntable huntable)
        {
            await _huntableRepository.Add(huntable);
        }

        [Authorize]
        [HttpDelete]
        public async Task Delete([FromBody] Guid id)
        {
            await _huntableRepository.Remove(id);
        }

        [Authorize]
        [HttpPatch]
        public async Task Uppdate(Guid id, [FromBody] JsonPatchDocument<Huntable> patchEntity)
        {

                var toBePatched = await _huntableRepository.Get(id);
                patchEntity.ApplyTo(toBePatched);
                await _huntableRepository.Edit(toBePatched);
        }
    }
}
