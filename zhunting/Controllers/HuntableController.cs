using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<Huntable>> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                return await _huntableRepository.GetHuntable();
            }
            catch(OperationCanceledException)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return null;
            }
        }

        [HttpPost]
        public async Task Create([FromBody] Huntable huntable)
        {
            await _huntableRepository.AddHuntable(huntable);
        }

        [HttpDelete]
        public async Task Delete([FromBody] Guid id)
        {
            await _huntableRepository.RemoveHuntable(id);
        }

        [HttpPatch]
        public async Task Uppdate(Guid id, [FromBody] JsonPatchDocument<Huntable> patchEntity)
        {
            var toBePatched = await _huntableRepository.GetHuntable(id);
            patchEntity.ApplyTo(toBePatched);
            await _huntableRepository.EditHuntable(toBePatched);
        }
    }
}
