﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreTheChampions.Models
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
            Colors = new List<Color>();
        }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public virtual List<Color>Colors { get; set; }
        public virtual ICollection<Player>Players { get; set; }
        public virtual ICollection<Match> Team1Matches { get; set; }
        public virtual ICollection<Match> Team2Matches { get; set; }
    }
}
