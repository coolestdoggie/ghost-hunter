using UnityEngine;
using Zenject;

namespace GhostHunter.Scenes.Game
{
    public class Ghost : MonoBehaviour
    {
        [SerializeField] private Vector2 ghostClampMoveSpeed;
        [SerializeField] private Vector2 positionXClampOfGhostSpawn;
        [SerializeField] private float verticalSpawnPoint;
        private float moveSpeed;
        
        private void Update()
        {
            transform.position += GetVelocity() * Time.deltaTime;
        }
        
        private Vector3 GetVelocity()
        {
            return Vector3.up * moveSpeed;
        }

        private void Reset()
        {
            moveSpeed = Random.Range(ghostClampMoveSpeed.x, ghostClampMoveSpeed.y);

            float randomX = Random.Range(positionXClampOfGhostSpawn.x, positionXClampOfGhostSpawn.y);
            transform.position = new Vector3(randomX, verticalSpawnPoint, 0);
        }

        public class Pool : MemoryPool<Ghost>
        {
            protected override void Reinitialize(Ghost ghost)
            {
               ghost.Reset();
            }
        }
    }
}
