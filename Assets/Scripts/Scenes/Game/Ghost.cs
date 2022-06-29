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
            Dispose();
        }

        public void OnDespawned()
        {
            _pool = null;
            moveSpeed = 0;
        }

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            moveSpeed = Random.Range(ghostClampMoveSpeed.x, ghostClampMoveSpeed.y);
            
            float randomX = Random.Range(positionXClampOfGhostSpawn.x, positionXClampOfGhostSpawn.y);
            transform.position = new Vector3(randomX, verticalSpawnPoint, 0);
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }
        
        public class Factory : PlaceholderFactory<Ghost>{}
    }
}
