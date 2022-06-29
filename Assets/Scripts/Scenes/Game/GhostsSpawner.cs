using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GhostHunter.Scenes.Game
{
    public class GhostsSpawner : MonoBehaviour
    {
        [SerializeField] private int possibleNumberOfEnemies;
        
        private Ghost.Pool _ghostsPool;
        private readonly List<Ghost> _ghosts = new List<Ghost>();
        
        [Inject]
        private void Construct(Ghost.Pool ghostsPool)
        {
            _ghostsPool = ghostsPool;
        }

        public void AddGhost()
        {
            _ghosts.Add(_ghostsPool.Spawn());
        }

        public void RemoveGhost()
        {
            var ghost = _ghosts[0];
            _ghostsPool.Despawn(ghost);
            _ghosts.Remove(ghost);
        }
        
        public void Start()
        {
            AddGhost();
        }
    }
}
