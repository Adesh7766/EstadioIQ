using EstadioIQ.BAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstadioIQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _service;

        public CompetitionController(ICompetitionService service)
        {
            _service = service;
            _env = env;
        }

        [HttpGet("GetAllCompetition")]
        public ResponseData<List<CompetitionDto>> GetCompetition()
        {
            var response = _service.GetCompetitions();

            return new ResponseData<List<CompetitionDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data,
                TotalCount = response.TotalCount
            };
        }


        [HttpGet("GetCompetitionById")]
        public ResponseData<CompetitionDto> GetCompetitionById(int id)
        {
            var response = _service.GetCompetitionById(id);

            return new ResponseData<CompetitionDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("UpdateCompetition")]
        public ResponseData UpdateCompetition([FromForm] CompetitionDto Competition)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.UpdateCompetition(Competition);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }

        [HttpPost("AddCompetition")]
        public ResponseData AddCompetition([FromForm] CompetitionDto Competition)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Please provide valid data."
                };
            }

            var response = _service.AddCompetition(Competition);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = response.Data
            };
        }
    }
}
