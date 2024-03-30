using AutoMapper;
using IndiaMarathon.API.Models.Domain;
using IndiaMarathon.API.Models.DTO;
using IndiaMarathon.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndiaMarathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarathonController : ControllerBase
    {
        private readonly IMarathonRepository marathonRepository;
        private readonly IMapper mapper;

        public MarathonController(IMarathonRepository marathonRepository,IMapper mapper)
        {
            this.marathonRepository = marathonRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> InsertMarathon([FromBody]AddMarathonDto addMarathonDto)
        {
            var MarathonDomain = mapper.Map<Marathon>(addMarathonDto);
            MarathonDomain= await marathonRepository.InsertMarathon(MarathonDomain);
            if (MarathonDomain == null) 
            {
                return BadRequest();
            }
            var MarathonDto = mapper.Map<MarathonDto>(MarathonDomain);
            return CreatedAtAction(nameof(GetMarathonById), new { id = MarathonDto.Id }, MarathonDto);            
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMarathon()
        {
            var MarathonDomain= await marathonRepository.GetAllMarathons();
            if (MarathonDomain == null)
            {
                return BadRequest();
            }
            return Ok(mapper.Map<List<MarathonDto>>(MarathonDomain));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMarathonById([FromRoute]int id)
        {
            var MarathonDomain= await marathonRepository.GerMarathonById(id);
            if (MarathonDomain == null)
            {
                return BadRequest();
            }
            return Ok(mapper.Map<MarathonDto>(MarathonDomain));
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateMarathon([FromRoute]int id ,[FromBody]AddMarathonDto addMarathonDto)
        {
            var MarathanDomain = mapper.Map<Marathon>(addMarathonDto);
            MarathanDomain = await marathonRepository.UpdateMarathon(id, MarathanDomain);
            if (MarathanDomain == null)
            {
                return NotFound ();
            }
            return Ok(mapper.Map<MarathonDto>(MarathanDomain));
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> RemoveMarathon([FromRoute]int id)
        {
            var MarathonDomain= await marathonRepository.RemoveMarathon(id);
            if(MarathonDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<MarathonDto> (MarathonDomain));
        }
    }
}
