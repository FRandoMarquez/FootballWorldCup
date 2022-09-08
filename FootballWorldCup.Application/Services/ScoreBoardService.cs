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
            _scoreBoard = new ScoreBoard()
            {
                Games = new List<Game>()
            };
        }

        public ScoreBoardService(ScoreBoard scoreBoard)
        {
            _scoreBoard = scoreBoard;
        }

        public void StartGame(string HomeTeam, string AwayTeam)
        {
            if (_scoreBoard != null && !string.IsNullOrEmpty(HomeTeam) && !string.IsNullOrEmpty(AwayTeam))
            {
                if (!_scoreBoard.Games.Any(game => game.HomeTeam.Equals(HomeTeam) || game.AwayTeam.Equals(AwayTeam)))
                {
                    _scoreBoard.Games.Add(new Game { HomeTeam = HomeTeam, AwayTeam = AwayTeam });
                }
            }
        }

        public void FinishGame(string HomeTeam, string AwayTeam)
        {
            if (_scoreBoard != null && _scoreBoard.Games != null && _scoreBoard.Games.Count > 0)
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

        public void UpdateScore(Game gameToUpdate)
        {
            if (_scoreBoard != null && _scoreBoard.Games != null && _scoreBoard.Games.Count > 0)
            {
                if (gameToUpdate != null && !string.IsNullOrEmpty(gameToUpdate.HomeTeam) && !string.IsNullOrEmpty(gameToUpdate.AwayTeam))
                {
                    var currentGame = _scoreBoard.Games.Where(game => game.HomeTeam.Equals(gameToUpdate.HomeTeam) && game.AwayTeam.Equals(gameToUpdate.AwayTeam)).FirstOrDefault();
                    if (currentGame != null)
                    {
                        if (gameToUpdate.HomeTeamScore >= currentGame.HomeTeamScore && gameToUpdate.AwayTeamScore >= currentGame.AwayTeamScore)
                        {
                            currentGame.HomeTeamScore = gameToUpdate.HomeTeamScore;
                            currentGame.AwayTeamScore = gameToUpdate.AwayTeamScore;
                        }
                    }
                }
            }
        }

        public ScoreBoard GetScoreBoardSummary()
        {
            if (_scoreBoard == null || _scoreBoard.Games == null)
            {
                return new ScoreBoard()
                {
                    Games = new List<Game>()
                };
            }
            _scoreBoard.Games = _scoreBoard.Games.OrderByDescending(game => game.HomeTeamScore + game.AwayTeamScore)
                .ThenByDescending(game => game.StartDate).ToList();

            return _scoreBoard;
        }

    }
}
