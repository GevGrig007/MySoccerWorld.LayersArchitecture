using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class League
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Text must be less than 50 characters")]
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Region { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
