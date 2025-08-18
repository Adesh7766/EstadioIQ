using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.Helper.Converter
{
    public class ClubConverter
    {
        public Club ConvertToModel(ClubDto data)
        {
            Club model = new Club();

            model.Name = data.Name;
            model.Code = data.Tla;
            model.OfficialSite = data.website;
            model.StadiumName = data.Venue;
            model.Area.Name = data.Area.Name;
            model.Area.Flag = data.Area.Flag;
            model.Area.Code = data.Area.Code;

            return model;
        }

        public ClubDto ConvertToDto(Club model)
        {
            ClubDto data = new ClubDto();

            data.Name = model.Name;
            data.Tla = model.Code;
            data.website = model.OfficialSite;
            data.Venue = model.StadiumName;
            data.Area.Name = model.Area.Name;
            data.Area.Flag = model.Area.Flag;
            data.Area.Code = model.Area.Code;

            return data;
        }
    }   

}
