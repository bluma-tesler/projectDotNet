using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tesler.API.Models;
using Tesler.Core;
using Tesler.Core.DTO;
using Tesler.Core.Entities;
using Tesler.Core.Services;
using Tesler.Servise;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tesler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresenceController : ControllerBase
    {
        private readonly IPresenceService _presenceService;
        private readonly IMapper _mapper;
        public PresenceController(IPresenceService presenceService, IMapper mapper)
        {
            _presenceService = presenceService;
            _mapper = mapper;
        }
        // GET: api/<PresenceController>
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Get()
        {
            var presences =await _presenceService.GetListAsync();
            var presencesListDTO = _mapper.Map<IEnumerable<PresenceDTO>>(presences);
            return Ok(presencesListDTO);
        }

        // GET api/<PresenceController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Get(int id)
        {

            var presence =await _presenceService.GetByIdAsync(id);
            var presenceDTO = _mapper.Map<PresenceDTO>(presence);
            return Ok(presenceDTO);
        }

        // POST api/<PresenceController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] PresencePostModel presence)
        {
            var presenceToAdd = new Presence { UserId = presence.UserId, Date = presence.Date, EntryTime = presence.EntryTime, DepartureTime = presence.DepartureTime, Request = presence.Request };
            var newPresence =await _presenceService.AddAsync(presenceToAdd);
            return Ok(newPresence);
        }

        // PUT api/<PresenceController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(int id, [FromBody] Presence presence)
        {
            var updatePresance =await _presenceService.UpdateAsync(presence);
            return Ok(updatePresance);
        }

        // DELETE api/<PresenceController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Delete(int id)
        {
           await _presenceService.DeleteAsync(id);
            return Ok();
        }
    }
}
