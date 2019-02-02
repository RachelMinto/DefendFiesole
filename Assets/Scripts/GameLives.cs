using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLives : MonoBehaviour {

    [SerializeField] int numberOfLives = 5;
    Text livesDisplayText;

    void Start()
    {
        livesDisplayText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesDisplayText.text = numberOfLives.ToString() + " Lives";
    }

    public bool IsGameOver()
    {
        return numberOfLives <= 0;
    }

    public void LoseLife()
    {
        numberOfLives -= 1;
        UpdateDisplay();

        if(IsGameOver()) {
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            levelLoader.DelayAndLoadNextScene();
        }
    }
}
