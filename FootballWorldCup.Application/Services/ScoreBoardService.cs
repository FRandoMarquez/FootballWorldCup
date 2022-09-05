using FootballWorldCup.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCup.Application.Services
{
    public class ScoreBoardService
    {

        private ScoreBoard _scoreBoard;

        public ScoreBoardService()
        {
            _scoreBoard = new ScoreBoard();
        }

        public ScoreBoardService(ScoreBoard scoreBoard)
        {
            _scoreBoard = scoreBoard;
        }

        public void StartGame(string HomeTeam, string AwayTeam)
        {
            if (!string.IsNullOrEmpty(HomeTeam) && !string.IsNullOrEmpty(AwayTeam))
            {
                if (!_scoreBoard.Games.Any(game => game.HomeTeam.Equals(HomeTeam) || game.AwayTeam.Equals(AwayTeam)))
                {
                    _scoreBoard.Games.Add(new Game { HomeTeam = HomeTeam, AwayTeam = AwayTeam });
                }
            }
        }

    }
}
