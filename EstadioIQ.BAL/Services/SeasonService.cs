using EstadioIQ.BAL.Interface;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Helper.Converter;

namespace EstadioIQ.BAL.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepo _repo;
        private readonly SeasonConverter _converter;

        public SeasonService(ISeasonRepo repo, SeasonConverter converter)
        {
            _repo = repo;
            _converter = converter;
        }

        public ResponseData<List<SeasonDto>> GetSeasons()
        {
            var response = _repo.GetSeasons();

            List<SeasonDto> Seasons = new List<SeasonDto>();

            foreach (var Season in response.Data)
            {
                var data = _converter.ConvertToDto(Season);

                Seasons.Add(data);
            }

            return new ResponseData<List<SeasonDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = Seasons,
                TotalCount = response.TotalCount
            };
        }


        public ResponseData<SeasonDto> GetSeasonById(int id)
        {
            var response = _repo.GetSeasonById(id);

            SeasonDto Season = _converter.ConvertToDto(response.Data);

            return new ResponseData<SeasonDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = Season
            };
        }

        public ResponseData UpdateSeason(SeasonDto Season)
        {
            var model = _converter.ConvertToModel(Season);

            var response = _repo.UpdateSeason(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData AddSeason(SeasonDto Season)
        {
            var model = _converter.ConvertToModel(Season);

            var response = _repo.AddSeason(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }
    }
}
