using UnityEngine;

namespace Xly
{
    public class PlayerManager : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
