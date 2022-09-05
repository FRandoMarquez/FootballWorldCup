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

        public void FinishGame(string HomeTeam, string AwayTeam)
        {
            if (_scoreBoard.Games != null && _scoreBoard.Games.Count > 0)
            {
                if (!string.IsNullOrEmpty(HomeTeam) && !string.IsNullOrEmpty(AwayTeam))
                {
                    var game = _scoreBoard.Games.Where(game => game.HomeTeam.Equals(HomeTeam) && game.AwayTeam.Equals(AwayTeam)).FirstOrDefault();
                    if (game != null)
                    {
                        _scoreBoard.Games.Remove(game);
                    }
                }
            }
        }

    }
}
