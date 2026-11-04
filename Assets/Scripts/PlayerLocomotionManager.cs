using UnityEngine;

namespace Xly
{
    [RequireComponent(typeof(PlayerManager))]
    public class PlayerLocomotionManager : MonoBehaviour
    {
        private PlayerManager playerManager;

        void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
        }
        
        public void MovePlayerToPosition(Vector3 newPosition)
        {
            playerManager.NavMeshAgent.SetDestination(newPosition);
        }
    }
}
