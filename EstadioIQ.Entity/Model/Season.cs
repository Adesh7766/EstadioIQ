using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadioIQ.Entity.Model
{
    public class Season
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public string Winner { get; set; }  // Can be null
    }
}
