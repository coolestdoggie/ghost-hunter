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
        private readonly List<Ghost> _ghosts = new List<Ghost>();
        
        [Inject]
        private void Construct(Ghost.Factory ghostsFactory)
        {
            _ghostsFactory = ghostsFactory;
        }

        public void AddGhost()
        {
            var ghost = _ghostsFactory.Create();
            ghost.Destroyed += AddGhost;
            ghost.transform.SetParent(null);
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
        
        public IEnumerator Start()
        {
            for (int i = 0; i < ghostsNumber; i++)
            {
                yield return new WaitForSeconds(2.0f);
                AddGhost();
            }
        }
    }
}
