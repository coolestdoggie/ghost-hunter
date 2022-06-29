using TMPro;
using UnityEngine;
using Zenject;

namespace GhostHunter.Scenes.Game
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_Text counter;

        private ScoreCounter _scoreCounter;
        
        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }

        private void OnEnable() => _scoreCounter.ScoreUpdated += UpdateCounterText;
        private void OnDisable() => _scoreCounter.ScoreUpdated -= UpdateCounterText;

        private void UpdateCounterText()
        {
            counter.text = _scoreCounter.CurrentScore.ToString();
        }
    }
}
