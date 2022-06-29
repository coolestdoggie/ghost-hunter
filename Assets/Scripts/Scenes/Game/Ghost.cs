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
        
        private IMemoryPool _pool;
        private float _currentMoveSpeed;

        public event Action Disposed;

        private void Update()
        {
            transform.position += GetVelocity() * Time.deltaTime;
        }
        
        private Vector3 GetVelocity() => Vector3.up * _currentMoveSpeed;
        
        private void OnMouseDown() 
        {
            OnDisposed();
            Dispose();
        }
        
        public void Dispose()
        {
            _pool.Despawn(this);
            Disposed = delegate {  };
        }
        
        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            _currentMoveSpeed = Random.Range(ghostClampMoveSpeed.x, ghostClampMoveSpeed.y);
            
            float randomX = Random.Range(positionXClampOfGhostSpawn.x, positionXClampOfGhostSpawn.y);
            transform.position = new Vector3(randomX, verticalSpawnPoint, 0);
        }

        public void OnDespawned()
        {
            _pool = null;
            _currentMoveSpeed = 0;
        }
        
        protected virtual void OnDisposed()
        {
            Disposed?.Invoke();
        }
        
        public class Factory : PlaceholderFactory<Ghost>{}
    }
}
