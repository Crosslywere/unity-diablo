using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Xly
{
    public class WorldSaveGameManager : MonoBehaviour
    {
        private static WorldSaveGameManager instance;

        public static WorldSaveGameManager Singleton => instance;

        [Header("World Index")]
        [SerializeField]
        private int menuSceneIndex = 0;

        public int MenuSceneIndex => menuSceneIndex;

        [SerializeField]
        private int worldSceneIndex = 1;

        private void Awake()
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

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void StartNewGame()
        {
            SceneManager.LoadScene(worldSceneIndex);
        }

    }
}
