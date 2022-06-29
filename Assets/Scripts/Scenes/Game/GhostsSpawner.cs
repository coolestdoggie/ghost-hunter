using System.Collections;
using System.Collections.Generic;
using GhostHunter.Scenes.Game;
using UnityEngine;
using Zenject;

namespace GhostHunter
{
    public class GhostsSpawner : MonoBehaviour
    {
        private Ghost.Factory _ghostFactory;

        [Inject]
        private void Construct(Ghost.Factory ghostFactory)
        {
            _ghostFactory = ghostFactory;
        }
        
        void Start()
        {
            _ghostFactory.Create(3);
        }

    }
}
