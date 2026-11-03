using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using System.Collections;

// Strongly encoraged by Sebastian to use namespaces in my code
namespace Xly
{
    // Title Screen Manager is meant to handle all the title screen functionalities.
    public class TitleScreenManager : MonoBehaviour
    {
        [Header("Press Start Menu")]
        [SerializeField]
        private CanvasGroup pressStartMenuCanvasGroup;

        [SerializeField]
        private float fadeTime = 1f;

        private Coroutine fadeOutPressStartMenuCorutine;

        [Header("Character Menu")]
        [SerializeField]
        private CanvasGroup characterMenuCanvasGroup;

        [SerializeField]
        private GameObject[] characterMenuButtons;

        [SerializeField]
        private GameObject pressStartButton;

        private Coroutine fadeInCharacterMenuCoroutine;

        public void StartGame()
        {
            NetworkManager.Singleton.StartHost();
            FadeOutPressStartMenu();
            FadeInCharaterMenu();
        }

        // Press Start Menu
        private void FadeOutPressStartMenu()
        {
            if (fadeOutPressStartMenuCorutine != null) // Prevents the coroutine from starting multiple instances of itself.
                StopCoroutine(fadeOutPressStartMenuCorutine);
            
            fadeOutPressStartMenuCorutine = StartCoroutine(FadeOutPressStartMenuCoroutine());
        }

        private IEnumerator FadeOutPressStartMenuCoroutine()
        {
            float timeElapsed = 0;
            float startingAlpha = pressStartMenuCanvasGroup.alpha;
            while (timeElapsed < fadeTime)
            {
                pressStartMenuCanvasGroup.alpha = Mathf.Lerp(startingAlpha, 0, timeElapsed / fadeTime);
                timeElapsed += Time.deltaTime;
                yield return null; // Wait till the next frame to resume the coroutine
            }
            pressStartMenuCanvasGroup.alpha = 0; // Fixing the alpha to 0 after the loop in-case it isn't
        }

        // Charater Menu
        public void StartNewGame()
        {
            WorldSaveGameManager.Singleton.StartNewGame();
        }

        private void FadeInCharaterMenu()
        {
            if (fadeInCharacterMenuCoroutine != null)
                StopCoroutine(fadeInCharacterMenuCoroutine);
            
            fadeInCharacterMenuCoroutine = StartCoroutine(FadeInCharaterMenuCoroutine());

            for (int i = 0; i < characterMenuButtons.Length; ++i)
            {
                if (characterMenuButtons[i] == null) continue;

                characterMenuButtons[i].SetActive(true);
            }
        }

        private IEnumerator FadeInCharaterMenuCoroutine()
        {
            float timeElapsed = 0;
            while (timeElapsed < fadeTime)
            {
                characterMenuCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            characterMenuCanvasGroup.alpha = 1f; // Fixing the alpha to 1 after the loop in-case it isn't
            pressStartButton.SetActive(false); // Disabling the pressStartButton to prevent hidden interactions
        }
    }
}
