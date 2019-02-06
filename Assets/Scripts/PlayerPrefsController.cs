using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master volume"; 
    const float MIN_VOLUME = 0f; 
    const float MAX_VOLUME = 1f; 
    const string DIFFICULTY_KEY = "difficulty"; 
    static float defaultVolume = 0.8f;

    public void Start()
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, defaultVolume);
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

    public static float GetDefaultVolume() 
    {
        return defaultVolume;
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
}
