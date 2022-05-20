using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TenistasAPI.Models
{
    public class TennisPlayerModel
    {
        [Required]
        public int Id{get;set;}
        [Required]
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int? CurrentRanking { get; set; }
        public int? BestRanking { get; set; }
        public int? GrandSlamTitles { get; set; }

        public int? CareerTitles { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }
        public IEnumerable<TourneyModel> Tourneys { get; set; }
    }
}
