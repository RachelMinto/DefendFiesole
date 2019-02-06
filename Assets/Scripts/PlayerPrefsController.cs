using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {
    const string MASTER_VOLUME_KEY = "master volume"; 
    const float MIN_VOLUME = 0f; 
    const float MAX_VOLUME = 1f; 
    static float defaultVolume = 0.8f;

    const string MASTER_DIFFICULTY_KEY = "difficulty"; 
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 1f;
    static float defaultDifficulty = 0.6f;

    public void Start()
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, defaultVolume);
        PlayerPrefs.SetFloat(MASTER_DIFFICULTY_KEY, defaultDifficulty);
    }

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else 
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    public static void SetMasterDifficulty(float difficultyLevel)
    {
        if (difficultyLevel >= MIN_DIFFICULTY && difficultyLevel <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(MASTER_DIFFICULTY_KEY, difficultyLevel);
        }
        else
        {
            Debug.LogError("Difficulty Level is out of range");
        }
    }

    public static float GetDefaultVolume()
    {
        return defaultVolume;
    }

    public static float GetDefaultDifficulty()
    {
        return defaultDifficulty;
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static float GetMasterDifficulty()
    {
        return PlayerPrefs.GetFloat(MASTER_DIFFICULTY_KEY);
    }
}
