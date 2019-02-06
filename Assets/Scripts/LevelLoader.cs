using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added for scene script!
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] int timeToWait = 3;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0) {
            DelayAndLoadNextScene();
        }
	}

    void LoadScene(int sceneIndex) 
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }


    public void ImmediatelyLoadNextScene() 
    {
        LoadScene(currentSceneIndex + 1);
    }


    public void RestartScene()
    {
        Time.timeScale = 1;        
        LoadScene(currentSceneIndex);
    }


    public void LoadStartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void DelayAndLoadNextScene() {
        StartCoroutine(WaitForTimeAndLoadScene(currentSceneIndex + 1));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitForTimeAndLoadScene(int sceneIndex)
    {
        yield return new WaitForSeconds(timeToWait);
        LoadScene(sceneIndex);
    }
}
