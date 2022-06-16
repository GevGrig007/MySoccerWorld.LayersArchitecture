using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class Club : Team
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
