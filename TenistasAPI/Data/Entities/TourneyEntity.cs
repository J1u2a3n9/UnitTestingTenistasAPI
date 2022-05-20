using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenistasAPI.Data.Entities
{
    public class TourneyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int? playerId { get; set; }
    }
}
