using System.Text.Json;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Helper.Converter;
using EstadioIQ.Helper.Enum;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EstadioIQ.Helper.ApiServices
{
    public class FootballAPIService
    {
        private HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        private readonly MatchConverter _matchConverter;
        private readonly ClubConverter _clubConverter;

        public FootballAPIService(HttpClient httpClient, IOptions<AppSettings> appSettings, MatchConverter matchConverter, ClubConverter clubConverter)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;            
            _matchConverter = matchConverter;
            _clubConverter = clubConverter;
        }

        public async Task<ResponseData<List<MatchDto>>> GetAllUclMatches(int methodId)
        {
            if (methodId == (int)MethodEnum.MethodGet)
            {
                _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", _appSettings.APIKey);
                var response = await _httpClient.GetAsync(_appSettings.BaseURL + "competitions/CL/matches");

                string content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                UclApiResponseDTO matchFromApi = JsonSerializer.Deserialize<UclApiResponseDTO>(content, options);

                var converterResponse = _matchConverter.MatchDtoAPIConverter(matchFromApi.Matches);

                return new ResponseData<List<MatchDto>>
                {
                    Message = converterResponse.Message,
                    SuccessStatus = converterResponse.SuccessStatus,
                    Data = converterResponse.Data
                };
            }

            return new ResponseData<List<MatchDto>>
            {
                Message = "Mehotd type incorrect",
                SuccessStatus = false
            };
        }

        public async Task<ResponseData<List<ClubDto>>> GetAllUclTeams(int methodId)
        {
            if (methodId == (int)MethodEnum.MethodGet)
            {
                _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", _appSettings.APIKey);
                var response = await _httpClient.GetAsync(_appSettings.BaseURL + "competitions/CL/teams");

                string content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                UclApiResponseDTO teamsFromApi = JsonSerializer.Deserialize<UclApiResponseDTO>(content, options);

                if(teamsFromApi == null)
                {
                    return new ResponseData<List<ClubDto>>
                    {
                        Message = "Error from the api.",
                        SuccessStatus = false
                    };                    
                }

                var data = new List<ClubDto>();

                foreach(var team in teamsFromApi.Teams )
                {
                    var converterResponse = _clubConverter.ConvertToDto(team);

                    data.Add(converterResponse);
                }

                return new ResponseData<List<ClubDto>>
                {
                    Message = "Fetched data from the api.",
                    SuccessStatus = true,
                    Data = data
                };
            }

            return new ResponseData<List<ClubDto>>
            {
                Message = "Method type incorrect",
                SuccessStatus = false
            };
        }
    }

    public class AppSettings
    {
        public string APIKey { get; set; }

        public string BaseURL { get; set; }
    }
}
