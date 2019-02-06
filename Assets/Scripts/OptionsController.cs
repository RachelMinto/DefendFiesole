using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    [SerializeField] Slider volumeSlider;

	void Start () {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();	
	}

    private void Update()
    {
        MusicPlayer musicPlayer = GetMusicPlayer();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player. Did you start from Splash Screen?");
        }
    }

    public void SaveAndExit() {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<LevelLoader>().LoadStartScene();
    }

    public void SetToDefaultValues() {
        float defaultVolume = PlayerPrefsController.GetDefaultVolume();
        volumeSlider.value = defaultVolume;
    }

    private MusicPlayer GetMusicPlayer() {
        return FindObjectOfType<MusicPlayer>();
    }
}
