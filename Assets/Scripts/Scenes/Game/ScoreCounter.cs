using System;

namespace GhostHunter.Scenes.Game
{
    public class ScoreCounter
    {
        private int currentScore;

        public int CurrentScore
        {
            get => currentScore;
            set
            {
                currentScore = value;
                OnScoreUpdated(); 
            }
        }
        
        public event Action ScoreUpdated;

        protected virtual void OnScoreUpdated()
        {
            ScoreUpdated?.Invoke();
        }
    }
}