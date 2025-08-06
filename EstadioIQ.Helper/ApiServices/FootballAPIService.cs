using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Helper.Converter;
using EstadioIQ.Helper.Enum;
using Microsoft.Extensions.Options;

namespace EstadioIQ.Helper.ApiServices
{
    public class FootballAPIService
    {
        private HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        private MatchConverter _matchConverter;

        public FootballAPIService(HttpClient httpClient, IOptions<AppSettings> appSettings, MatchConverter matchConverter)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;            
            _matchConverter = matchConverter;
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
    }

    public class AppSettings
    {
        public string APIKey { get; set; }

        public string BaseURL { get; set; }
    }
}
