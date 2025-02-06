using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modmon.Modules.Speakers.Core.DTO;
using Modmon.Modules.Speakers.Core.Services;

namespace Modmon.Modules.Speakers.Api.Controllers
{
    internal class SpeakersController : BaseController
    {
        private const string Policy = "speakers";
        private readonly ISpeakersService _speakerService;

        public SpeakersController(ISpeakersService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SpeakerDetailsDto>> Get(Guid id)
            => OkOrNotFound(await _speakerService.GetAsync(id));

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IReadOnlyList<SpeakerDto>>> BrowseAsync()
            => Ok(await _speakerService.BrowseAsync());

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult> AddAsync(SpeakerDetailsDto dto)
        {
            await _speakerService.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, null);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult> UpdateAsync(Guid id, SpeakerDetailsDto dto)
        {
            dto.Id = id;
            await _speakerService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _speakerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
