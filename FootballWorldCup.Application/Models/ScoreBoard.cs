using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCup.Application.Models
{
    public class ScoreBoard
    {
        public List<Game> Games { get; set; }

        public override string ToString()
        {
            string scoreBoardToString = string.Empty;
            for (int i = 0; i < Games.Count; i++)
            {
                scoreBoardToString += string.Format("{0}. {1} {2} - {3} {4}", i, Games[i].HomeTeam, Games[i].HomeTeamScore, Games[i].AwayTeam, Games[i].AwayTeamScore)
                    + Environment.NewLine;
            }
            return scoreBoardToString;
        }
    }
}
