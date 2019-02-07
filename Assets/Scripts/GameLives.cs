using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLives : MonoBehaviour {
    Text livesDisplayText;
    int numberOfLives;

    void Start()
    {
        livesDisplayText = GetComponent<Text>();
        numberOfLives = NumberOfStartingLives();
        UpdateDisplay();
    }

    private int NumberOfStartingLives() {
        PlayerPrefsController playerPrefsController = FindObjectOfType<PlayerPrefsController>();
        float difficulty = PlayerPrefsController.GetMasterDifficulty();
        float roughLives = (1f - difficulty) * 10;
        int lives = (int)System.Math.Round(roughLives);
        return Mathf.Clamp(lives, 1, 10);
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
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
