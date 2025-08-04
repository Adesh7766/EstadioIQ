using EstadioIQ.Entity.Common;
using EstadioIQ.Entity.DTO;
using EstadioIQ.Entity.DTO.APIResponseDTO;


namespace EstadioIQ.Helper.Converter
{
    public class MatchConverter
    {
        public ResponseData<List<MatchDto>> MatchAPIConverter(List<MatchFromApi> matchesFromApi)
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

                    if (matchDto != null)
                    {
                        matches.Add(matchDto);
                    }
                }

                if(matches != null)
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
    }
}
