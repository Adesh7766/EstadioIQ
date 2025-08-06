using EstadioIQ.BAL.Interface;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Helper.Converter;

namespace EstadioIQ.BAL.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepo _repo;
        private readonly CompetitionConverter _converter;

        public CompetitionService(ICompetitionRepo repo, CompetitionConverter converter)
        {
            _repo = repo;
            _converter = converter;
        }

        public ResponseData<List<CompetitionDto>> GetCompetitions()
        {
            var response = _repo.GetCompetitions();

            List<CompetitionDto> Competitions = new List<CompetitionDto>();

            foreach (var Competition in response.Data)
            {
                var data = _converter.ConvertToDto(Competition);

                Competitions.Add(data);
            }

            return new ResponseData<List<CompetitionDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = Competitions,
                TotalCount = response.TotalCount
            };
        }


        public ResponseData<CompetitionDto> GetCompetitionById(int id)
        {
            var response = _repo.GetCompetitionById(id);

            CompetitionDto Competition = _converter.ConvertToDto(response.Data);

            return new ResponseData<CompetitionDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = Competition
            };
        }

        public ResponseData UpdateCompetition(CompetitionDto Competition)
        {
            var model = _converter.ConvertToModel(Competition);

            var response = _repo.UpdateCompetition(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData AddCompetition(CompetitionDto Competition)
        {
            var model = _converter.ConvertToModel(Competition);

            var response = _repo.AddCompetition(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }
    }
}
