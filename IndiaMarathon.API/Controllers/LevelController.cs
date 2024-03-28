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
    public class LevelController : ControllerBase
    {
        private readonly ILevelRepository levelRepository;
        private readonly IMapper mapper;

        public LevelController(ILevelRepository levelRepository,IMapper mapper)
        {
            this.levelRepository = levelRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLevel([FromBody] AddLevelDto addLevelDto)
        {
            var levelDomain = mapper.Map<Level>(addLevelDto);
            levelDomain = await levelRepository.CreateLevel(levelDomain);
            var levelDto=mapper.Map<LevelDto>(levelDomain);
            return CreatedAtAction(nameof(GetLevelById), new {id=levelDto.Id},levelDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLevel()
        {
            var levelDomain=await levelRepository.GetAllLevels();
            if (levelDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<LevelDto>>(levelDomain));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetLevelById([FromRoute]int id)
        {
            var levelDomain = await levelRepository.GetLevelById(id);
            if(levelDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LevelDto>(levelDomain));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteLevel([FromRoute]int id)
        {
            var levelDomain= await levelRepository.DeleteLevel(id);
            if (levelDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<LevelDto>(levelDomain));

        }
    }
}
