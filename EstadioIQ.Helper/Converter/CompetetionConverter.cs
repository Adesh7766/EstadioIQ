using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.Helper.Converter
{
    public class CompetitionConverter
    {
        public Competition ConvertToModel(CompetitionDto data)
        {
            Competition model = new Competition();

            model.Name = data.Name;
            model.Code = data.Code;
            model.Type = data.Type;
            model.Emblem = data.Emblem;

            return model;
        }

        public CompetitionDto ConvertToDto(Competition model)
        {
            CompetitionDto data = new CompetitionDto();

            data.Name = model.Name;
            data.Code = model.Code;
            data.Type = model.Type;
            data.Emblem = model.Emblem;

            return data;
        }
    }
}
