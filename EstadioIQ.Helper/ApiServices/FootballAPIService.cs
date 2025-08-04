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

namespace EstadioIQ.Helper.ApiServices
{
    public class FootballAPIService
    {
        private HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        private MatchConverter _matchConverter;

        public FootballAPIService(HttpClient httpClient, AppSettings appSettings, MatchConverter matchConverter)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
            var apiKey = _appSettings.APIKey;
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", "e0788800f2e54421b021f795c11cda14");
            _matchConverter = matchConverter;
        }

        public async Task<ResponseData<List<MatchDto>>> GetAllUclMatches(int methodId)
        {
            if (methodId == (int)MethodEnum.MethodGet)
            {
                var baseUrl = "https://api.football-data.org/v4/";
                var response = await _httpClient.GetAsync(baseUrl + "competitions/CL/matches");

                string content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                UclApiResponseDTO matchFromApi = JsonSerializer.Deserialize<UclApiResponseDTO>(content, options);

                var converterResponse = _matchConverter.MatchAPIConverter(matchFromApi.Matches);

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
