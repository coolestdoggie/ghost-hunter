using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace GhostHunter.Scenes.Game
{
    public class GhostsSpawner : MonoBehaviour
    {
        [SerializeField] private int ghostsNumber;
        
        private Ghost.Factory _ghostsFactory;
        private ScoreCounter _scoreCounter;
        private readonly List<Ghost> _ghosts = new List<Ghost>();
        
        [Inject]
        private void Construct(ScoreCounter scoreCounter, Ghost.Factory ghostsFactory)
        {
            _ghostsFactory = ghostsFactory;
            _scoreCounter = scoreCounter;
        }

        public void Start() => StartCoroutine(SpawnStartWave());
        
        private IEnumerator SpawnStartWave()
        {
            for (int i = 0; i < ghostsNumber; i++)
            {
                yield return new WaitForSeconds(2.0f);
                AddGhost();
            }
        }
        
        public void AddGhost()
        {
            var ghost = _ghostsFactory.Create(_scoreCounter);
            
            ghost.Disposing += AddGhost;
            
            _ghosts.Add(ghost);
        }

        public void RemoveGhost()
        {
            if (_ghosts.Any())
            {
                var ghost = _ghosts[0];
                ghost.Dispose();
                _ghosts.Remove(ghost);
            }
        }
        

        
    }
}
