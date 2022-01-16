using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreTheChampions.Enum;

namespace WeAreTheChampions.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public DateTime MatchTime { get; set; }
        public int Team1Id { get; set; }
        public virtual Team Team1Name { get; set; }
        public int Team2Id { get; set; }
        public virtual Team Team2Name { get; set; }

        public int? Team1Score { get; set; }
        public int? Team2Score { get; set; }
        public Result? Result { get; set; }

        public virtual ICollection<Team> Teams { get; set; } 

    }
    
}

