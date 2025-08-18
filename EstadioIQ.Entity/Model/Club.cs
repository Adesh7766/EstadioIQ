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
        public string Code { get; set; }
        public string OfficialSite { get; set; }
        public bool IsActive { get; set; }
        public string LogoUrl { get; set; }
        public string StadiumUrl { get; set; }
        public Area Area { get; set; }
        public string StadiumName { get; set; }
    }
}
