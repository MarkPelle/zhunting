using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using zhunting.BLL;
using zhunting.Data.Models;
using zhunting.DataAccess.Repositories;

namespace zhunting.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _mapper;

        public MediaController(IMediaRepository mediaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _mediaRepository = mediaRepository;
        }

        [HttpGet]
        public async Task<List<GetMediaCollectionDTO>> Get(CancellationToken cancellationToken = default)
        {
            var medias = await _mediaRepository.Get(cancellationToken);

            var mediaDtoList = new List<GetMediaCollectionDTO>();
            foreach (var item in medias)
            {
                mediaDtoList.Add(_mapper.Map<GetMediaCollectionDTO>(item));
            }

            return mediaDtoList;
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
