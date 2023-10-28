using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject loadingScreen; // Reference to the loading screen or animation

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }

    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        loadingScreen.SetActive(true); // Activate the loading screen or animation

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false; // Prevents the scene from activating immediately

        while (!asyncLoad.isDone)
        {
            // Check if the load progress is nearly complete (0.9 is considered fully loaded)
            if (asyncLoad.progress >= 0.9f)
            {
                // Enable the new scene
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}