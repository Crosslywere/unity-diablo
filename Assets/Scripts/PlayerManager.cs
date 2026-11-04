using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

namespace Xly
{
    [RequireComponent(typeof(PlayerLocomotionManager), typeof(NavMeshAgent))]
    public class PlayerManager : NetworkBehaviour
    {
        private NavMeshAgent navMeshAgent;

        public NavMeshAgent NavMeshAgent => navMeshAgent;

        private PlayerLocomotionManager playerLocomotionManager;

        public PlayerLocomotionManager PlayerLocomotionManager => playerLocomotionManager;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);

            navMeshAgent = GetComponent<NavMeshAgent>();

            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            if (IsOwner)
            {
                InputManager.Singleton.LocalPlayer = this;
            }
        }
    }
}
