using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Text must be less than 50 characters")]
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Region { get; set; }
        public virtual ICollection<Club> Clubs { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Coach> Coaches { get; set; }
    }
}
