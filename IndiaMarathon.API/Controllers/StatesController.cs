using AutoMapper;
using IndiaMarathon.API.Data;
using IndiaMarathon.API.Models.DTO;
using IndiaMarathon.API.Repository;
using IndiaMarathon.API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndiaMarathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly MarathonDbContext marathonDbContext;
        private readonly IStateRepository stateRepository;
        private readonly IMapper mapper;

        public StatesController(MarathonDbContext marathonDbContext ,IStateRepository stateRepository ,IMapper mapper) 
        {
            this.marathonDbContext = marathonDbContext;
            this.stateRepository = stateRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStates() 
        {
            var StatesDomain=await stateRepository.GetStates();
            return Ok(mapper.Map<List<StatesDto>>(StatesDomain));

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetStateByID([FromRoute] int id)
        {
            var StatesDomain= await stateRepository.GetById(id);
            if(StatesDomain == null)
            {
                return NotFound();
            }

            var StateDto=mapper.Map<StatesDto>(StatesDomain);
            return Ok(StateDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateState([FromBody] AddStateDto addStateDto)
        {
            var StatesDomain= mapper.Map<State>(addStateDto);
            StatesDomain = await stateRepository.CreateState(StatesDomain);
            var StatesDto=mapper.Map<StatesDto>(StatesDomain);
            return CreatedAtAction(nameof(GetStateByID), new { id = StatesDto.Id },StatesDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateState([FromRoute]int id, AddStateDto addStateDto)
        {
            var StatesDomain = mapper.Map<State>(addStateDto);
            StatesDomain = await stateRepository.UpdateState(id, StatesDomain);

            if(StatesDomain == null)
            {
                return NotFound();
            }
            var StatesDto = mapper.Map<StatesDto>(StatesDomain);
            return Ok(StatesDto);
        }
        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteState([FromRoute]int id)
        {
            var StatesDomain=await stateRepository.DeleteState(id);
            if(StatesDomain == null)
            {
                return NotFound();
            }
            var StatesDto = mapper.Map<StatesDto>(StatesDomain);
            return Ok(StatesDto);   
        }
    }
}
