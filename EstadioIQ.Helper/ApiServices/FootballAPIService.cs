using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Helper.Enum;
using Microsoft.IdentityModel.Tokens;

namespace EstadioIQ.Helper.ApiServices
{
    public class FootballAPIService
    {
        private HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public FootballAPIService(HttpClient httpClient, AppSettings appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
            var apiKey = _appSettings.APIKey;
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", "e0788800f2e54421b021f795c11cda14");
        }

        public async Task<ResponseData<MatchDto>> GetAllUclMatches(int methodId)
        {
            if (methodId == (int)MethodEnum.MethodGet)
            {
                var baseUrl = "https://api.football-data.org/v4/";
                var response = await _httpClient.GetAsync(baseUrl + "competitions/CL/matches");
                return new ResponseData<MatchDto>
                {
                    Message = response,
                    SuccessStatus = true,
                };
            }

            return new ResponseData<MatchDto>
            {
                Message = "message",
                SuccessStatus = false,
            };

        }
    }

    public class AppSettings
    {
        public string APIKey { get; set; }

        public string BaseURL { get; set; }
    }
}
