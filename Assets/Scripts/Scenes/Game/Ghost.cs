using UnityEngine;
using Zenject;

namespace GhostHunter.Scenes.Game
{
    public class Ghost : MonoBehaviour
    {
        [field: SerializeField] public float MoveSpeed { get; set; }

        private void Update()
        {
            transform.position += GetVelocity() * Time.deltaTime;
        }
        
        private Vector3 GetVelocity()
        {
            return Vector3.up * MoveSpeed;
        }

        private void Reset(float moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }

        public class Pool : MemoryPool<float, Ghost>
        {
            protected override void Reinitialize(float moveSpeed, Ghost ghost)
            {
               ghost.Reset(moveSpeed);
            }
        }
    }
}
