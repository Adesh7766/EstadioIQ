using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.Model
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tla { get; set; }
        public string website { get; set; }
        public bool IsActive { get; set; } = true;
        public string Crest { get; set; }
        public string StadiumUrl { get; set; }
        public Area Area { get; set; }
        public string Venue { get; set; }
    }
}
