using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadioIQ.Entity.DTO.APIResponseDTO;
using EstadioIQ.Entity.Model;

namespace EstadioIQ.Helper.Converter
{
    public class RefreeConverter
    {
        public Refree ConvertToModel(RefreeDto data)
        {
            Refree model = new Refree();

            model.Name = data.Name;
            model.Type = data.Type;
            model.Nationality = data.Nationality;

            return model;
        }

        public RefreeDto ConvertToDto(Refree model)
        {
            RefreeDto data = new RefreeDto();

            data.Name = model.Name;
            data.Nationality = model.Nationality;
            data.Type = model.Type;

            return data;
        }
    }
}
