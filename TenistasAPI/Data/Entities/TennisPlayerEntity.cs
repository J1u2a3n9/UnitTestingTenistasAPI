using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenistasAPI.Data.Entities
{
    public class TennisPlayerEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public int? Ranking { get; set; }
        public int? BestRanking { get; set; }
        public int? GrandSlamTitles { get; set; }
        public int? TotalTitles { get; set; }
        public DateTime? Birthdate { get; set; }
        public IEnumerable<TourneyEntity> Tourneys { get; set; }
    }
}
