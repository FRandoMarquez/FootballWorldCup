using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCup.Application.Models
{
    public class Game : IComparable<Game>, IEquatable<Game?>
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;

        public int CompareTo(Game? other)
        {
            if (other == null) return 1;

            var currentTotalScore = HomeTeamScore + AwayTeamScore;

            var otherTotalScore = other.HomeTeamScore + other.AwayTeamScore;

            var compareToResult = 0;

            if (currentTotalScore > otherTotalScore)
            {
                compareToResult = -1; 
            }
            else if (currentTotalScore < otherTotalScore || (currentTotalScore == otherTotalScore && StartDate.CompareTo(other.StartDate) < 0))
            {
                compareToResult = 1;
            }

            return compareToResult; 
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Game);
        }

        public bool Equals(Game? other)
        {
            return other != null &&
                   HomeTeam == other.HomeTeam &&
                   AwayTeam == other.AwayTeam &&
                   HomeTeamScore == other.HomeTeamScore &&
                   AwayTeamScore == other.AwayTeamScore &&
                   StartDate == other.StartDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(HomeTeam, AwayTeam, HomeTeamScore, AwayTeamScore, StartDate);
        }
    }
}
