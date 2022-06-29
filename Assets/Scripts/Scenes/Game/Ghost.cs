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
        
        public class Pool: MemoryPool<Ghost>{}
    }
}
