using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.Helper.Converter
{
    public class AreaConverter
    {
        public Area ConvertToModel(AreaDto data)
        {
            Area model = new Area();

            model.Name = data.Name;
            model.Code = data.Code;
            model.Flag = data.Flag;

            return model;
        }

        public AreaDto ConvertToDto(Area model)
        {
            AreaDto data = new AreaDto();

            model.Name = data.Name;
            model.Code = data.Code;
            model.Flag = data.Flag;

            return data;
        }
    }
}
