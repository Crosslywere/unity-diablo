using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Xly
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager instance;

        public static InputManager Singleton => instance;

        private PlayerControls playerControls;

        private bool leftClick;

        private Vector3 movementPosition;

        private const float SPHERE_GIZMOS_RADIUS = 0.2f;

        public PlayerManager LocalPlayer;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void OnEnable()
        {
            if (playerControls == null)
                playerControls = new();

            playerControls.Enable();
            playerControls.Player.LeftClick.performed += _ => leftClick = true;
        }

        void OnDisable()
        {
            playerControls.Disable();
        }

        void Start()
        {
            DontDestroyOnLoad(gameObject);
            gameObject.SetActive(false);
            SceneManager.activeSceneChanged += OnSceneChange;
        }

        private void OnSceneChange(Scene currentScene, Scene nextScene)
        {
            Scene active = SceneManager.GetActiveScene();

            if (active.buildIndex == WorldSaveGameManager.Singleton.MenuSceneIndex)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }

        void Update()
        {
            HandleInputActions();
        }

        // To handle inputs in the update function each frame.
        private void HandleInputActions()
        {
            HandleLeftClickAction();
            // Handle Right Click Action
            // Handle F Key Action
            // etc
        }

        private void HandleLeftClickAction()
        {
            if (leftClick)
            {
                leftClick = false;

                if (LocalPlayer == null) return;

                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                {
                    movementPosition = hit.point;
                }

                // If monster attack
                // if interactable interact
                // else move to location
                LocalPlayer.PlayerLocomotionManager.MovePlayerToPosition(movementPosition);
            }
        }

        void OnDrawGizmos()
        {
            if (movementPosition == Vector3.zero) return;

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(movementPosition, SPHERE_GIZMOS_RADIUS);
        }
    }
}
