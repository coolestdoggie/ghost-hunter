using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace GhostHunter.Scenes.Game
{
    public class Ghost : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        [SerializeField] private Vector2 ghostClampMoveSpeed;
        [SerializeField] private Vector2 positionXClampOfGhostSpawn;
        [SerializeField] private float verticalSpawnPoint;
        
        private float moveSpeed;
        private IMemoryPool _pool;

        public event Action Destroyed;

        private void Update()
        {
            transform.position += GetVelocity() * Time.deltaTime;
        }
        private Vector3 GetVelocity()
        {
            return Vector3.up * moveSpeed;
        }
        
        private void OnMouseDown() 
        {
            OnDestroyed();
            Dispose();
        }
        
        public void Dispose()
        {
            _pool.Despawn(this);
            Destroyed = delegate {  };
        }
        
        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            moveSpeed = Random.Range(ghostClampMoveSpeed.x, ghostClampMoveSpeed.y);
            
            float randomX = Random.Range(positionXClampOfGhostSpawn.x, positionXClampOfGhostSpawn.y);
            transform.position = new Vector3(randomX, verticalSpawnPoint, 0);
        }

        public void OnDespawned()
        {
            _pool = null;
            moveSpeed = 0;
        }
        
        public class Factory : PlaceholderFactory<Ghost>{}

        protected virtual void OnDestroyed()
        {
            Destroyed?.Invoke();
        }
    }
}
