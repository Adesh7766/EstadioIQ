using EstadioIQ.BAL.Interface;
using EstadioIQ.DAL.Interface;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Helper.ApiServices;
using EstadioIQ.Helper.Converter;

namespace EstadioIQ.BAL.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepo _repo;
        private readonly ClubConverter _converter;
        private readonly FootballAPIService _apiService;

        public ClubService(IClubRepo repo, ClubConverter converter, FootballAPIService apiService)
        {
            _repo = repo;
            _converter = converter;
            _apiService = apiService;
        }

        public ResponseData<List<ClubDto>> GetClubs()
        {
            var response = _repo.GetClubs();

            List<ClubDto> Clubs = new List<ClubDto>();

            foreach (var Club in response.Data)
            {
                var data = _converter.ConvertToDto(Club);

                Clubs.Add(data);
            }

            return new ResponseData<List<ClubDto>>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = Clubs,
                TotalCount = response.TotalCount
            };
        }


        public ResponseData<ClubDto> GetClubById(int id)
        {
            var response = _repo.GetClubById(id);

            ClubDto Club = _converter.ConvertToDto(response.Data);

            return new ResponseData<ClubDto>
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message,
                Data = Club
            };
        }

        public ResponseData UpdateClub(ClubDto Club)
        {
            var model = _converter.ConvertToModel(Club);

            var response = _repo.UpdateClub(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData AddClub(ClubDto Club)
        {
            var model = _converter.ConvertToModel(Club);

            var response = _repo.AddClub(model);

            return new ResponseData
            {
                SuccessStatus = response.SuccessStatus,
                Message = response.Message
            };
        }

        public ResponseData<List<ClubDto>> GetClubsFromAPI(int methodId)
        {          

            var response = _apiService.GetAllUclTeams(methodId);

            return new ResponseData<List<ClubDto>>
            {
                Message = response.Result.Message,
                SuccessStatus = response.Result.SuccessStatus,
                Data = response.Result.Data
            };
        }
    }
}
