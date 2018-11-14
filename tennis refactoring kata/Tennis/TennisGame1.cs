using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            if (player1Name==player2Name)
                throw  new ArgumentException("players names must be different");
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
            {
                m_score1 += 1;
                return;
            }

            if (playerName == player2Name)
            {
                m_score2 += 1;
                return;
            }
                
            throw new ArgumentException("unknown player: " + playerName);            
        }

        public string GetScore()
        {
            string scoreStr;            
            if (m_score1 == m_score2)
            {                
                scoreStr = EqualScore(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                string winPlayer = (m_score1 > m_score2) ? player1Name : player2Name;

                var diff = Math.Abs(m_score1 - m_score2);
                
                string winStatus = diff == 1 ? "Advantage" : "Win for";                
                
                scoreStr = String.Format("{0} {1}", winStatus, winPlayer);
            }
            else
            {
                scoreStr = String.Format("{0}-{1}",
                    GetScoreDisplay(m_score1),
                    GetScoreDisplay(m_score2));               
            }
            return scoreStr;
        }

        private string EqualScore(int score)
        {
            string scoreStr;
            if (score >= 3)
            {
                scoreStr="Deuce";
            }
            else
            {
                scoreStr = GetScoreDisplay(score);
                scoreStr += "-All";                
            }
            return scoreStr;
        }

        private static string GetScoreDisplay(int score)
        {
            string scoreStr;
            switch (score)
            {
                case 0:
                    scoreStr = "Love";
                    break;
                case 1:
                    scoreStr = "Fifteen";
                    break;
                case 2:
                    scoreStr = "Thirty";
                    break;
                case 3:
                    scoreStr = "Forty";
                    break;
                default:
                    throw new ArgumentException();
            }
            return scoreStr;
        }
    }
}

