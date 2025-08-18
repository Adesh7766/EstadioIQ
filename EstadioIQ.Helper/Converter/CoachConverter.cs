using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.Helper.Converter
{
    public class CoachConverter
    {
        public Coach ConvertToModel(CoachFromApiDto data)
        {
            Coach model = new Coach();

            model.Name = data.FirstName + data.LastName;
            model.DateOfBirth = DateTime.Parse(data.DateOfBirth);
            model.Nationality = data.Nationality;
            model.Club.Name = data.Club.Name;
            model.Club.Code = data.Club.Tla;
            model.ContractStartDate = data.Contract.Start;
            model.ContractEndDate = data.Contract.Until;

            return model;
        }

        public CoachFromApiDto ConvertToDto(Coach model)
        {
            CoachFromApiDto data = new CoachFromApiDto();

            data.FirstName = model.Name.Split(" ")[0];
            data.LastName = model.Name.Split(" ")[1];            
            data.DateOfBirth = model.DateOfBirth.ToShortDateString();
            data.Nationality = model.Nationality;
            data.Club.Name = model.Club.Name;
            data.Club.Tla = model.Club.Code;
            data.Contract.Start = model.ContractStartDate;
            data.Contract.Until = model.ContractEndDate;

            return data;
        }
    }
}
