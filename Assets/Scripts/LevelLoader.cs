using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added for scene script!
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] int timeToWait = 3;
    int currentSceneIndex;

    // Use this for initialization
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0) {
            StartCoroutine(WaitForTimeAndLoadNextScene());
        }
	}

    IEnumerator WaitForTimeAndLoadNextScene() {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    void LoadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
