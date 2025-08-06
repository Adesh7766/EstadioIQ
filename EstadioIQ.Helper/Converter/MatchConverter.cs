using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;
using Microsoft.AspNetCore.CookiePolicy;


namespace EstadioIQ.Helper.Converter
{
    public class MatchConverter
    {
        public ResponseData<List<MatchDto>> MatchDtoAPIConverter(List<MatchFromApi> matchesFromApi)
        {
            try
            {
                List<MatchDto> matches = new List<MatchDto>();

                foreach (var matchFromApi in matchesFromApi)
                {
                    MatchDto matchDto = new MatchDto();

                    matchDto.HomeTeam = matchFromApi.HomeTeam.Name;
                    matchDto.AwayTeam = matchFromApi.AwayTeam.Name;
                    matchDto.MatchDate = DateTime.Parse(matchFromApi.UtcDate);
                    matchDto.HomeScore = matchFromApi.Score.FullTime.Home;
                    matchDto.AwayScore = matchFromApi.Score.FullTime.Away;
                    matchDto.Competition = matchFromApi.Competition.Name;
                    matchDto.Venue = matchFromApi.Area.Name;

                    if (matchDto != null)
                    {
                        matches.Add(matchDto);
                    }
                }

                if (matches != null)
                {
                    return new ResponseData<List<MatchDto>>
                    {
                        Message = "Api response converted to match dto.",
                        SuccessStatus = true,
                        Data = matches
                    };
                }

                return new ResponseData<List<MatchDto>>
                {
                    Message = "Api response not converted to match dto.",
                    SuccessStatus = false
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Following exception occured: {ex.Message}");

                return new ResponseData<List<MatchDto>>
                {
                    Message = "Api response not converted to match dto.",
                    SuccessStatus = false
                };
            }
        }

        public ResponseData<List<Match>> MatchAPIConverterToSave(List<MatchFromApi> matchesFromApi)
        {
            try
            {
                List<Match> matches = new List<Match>();

                foreach (var matchFromApi in matchesFromApi)
                {
                    Match match = new Match();

                    match.HomeTeam = matchFromApi.HomeTeam.Name;
                    match.AwayTeam = matchFromApi.AwayTeam.Name;
                    match.MatchDate = DateTime.Parse(matchFromApi.UtcDate);
                    match.Competition = matchFromApi.Competition.Name;
                    match.HomeScore = matchFromApi.Score.FullTime.Home;
                    match.AwayScore = matchFromApi.Score.FullTime.Away;
                    match.Venue = matchFromApi.Area.Name;


                    if (match != null)
                    {
                        matches.Add(match);
                    }
                }

                return new ResponseData<List<Match>>
                {
                    SuccessStatus = true,
                    Message = "Converted to model",
                    Data = matches
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Following exception occured: {ex.Message}");

                return new ResponseData<List<Match>>
                {
                    SuccessStatus = false,
                    Message = "Not Converted to model"
                };
            }
        }
    }
}
