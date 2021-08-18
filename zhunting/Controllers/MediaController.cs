﻿using Microsoft.AspNetCore.Authorization;
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
    public class MediaController : ControllerBase
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaController(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        [HttpGet]
        public async Task<List<Media>> Get(CancellationToken cancellationToken = default)
        {
            return await _mediaRepository.Get(cancellationToken);
        }

        [HttpGet("{name}")]
        public async Task<Media> Get(string name, CancellationToken cancellationToken = default)
        {
            return await _mediaRepository.Get(name,cancellationToken);
        }

        [Authorize]
        [HttpPost]
        public async Task Create([FromBody] Media media)
        {
            await _mediaRepository.Add(media);
        }

        [Authorize]
        [HttpDelete]
        public async Task Delete([FromBody] Guid id)
        {
            await _mediaRepository.Remove(id);
        }

        [Authorize]
        [HttpPatch]
        public async Task Uppdate(Guid id, [FromBody] JsonPatchDocument<Media> patchEntity, CancellationToken cancellationToken = default)
        {
            var toBePatched = await _mediaRepository.Get(id, cancellationToken);
            patchEntity.ApplyTo(toBePatched);
            await _mediaRepository.Edit(toBePatched);
        }
    }
}
