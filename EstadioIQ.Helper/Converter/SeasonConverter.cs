using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.Helper.Converter
{
    public class SeasonConverter
    {
        public Season ConvertToModel(SeasonDto data)
        {
            Season model = new Season();

            model.StartDate = DateTime.Parse(data.StartDate);
            model.EndDate = DateTime.Parse(data.EndDate);
            model.CurrentMatchday = data.CurrentMatchday;
            model.Winner = data.Winner;

            return model;
        }

        public SeasonDto ConvertToDto(Season model)
        {
            SeasonDto data = new SeasonDto();

            data.StartDate = model.StartDate.ToShortDateString();
            data.EndDate = model.EndDate.ToShortDateString();
            data.CurrentMatchday = model.CurrentMatchday;
            data.Winner = model.Winner;

            return data;
        }
    }
}
