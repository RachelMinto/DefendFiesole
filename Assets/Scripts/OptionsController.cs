using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

	void Start () {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();	
        difficultySlider.value = PlayerPrefsController.GetMasterDifficulty();
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
        PlayerPrefsController.SetMasterDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadStartScene();
    }

    public void SetAsDefaultValues() {
        float defaultVolume = PlayerPrefsController.GetDefaultVolume();
        volumeSlider.value = defaultVolume;

        float defaultDifficulty = PlayerPrefsController.GetDefaultDifficulty();
        difficultySlider.value = defaultDifficulty;
    }

    private MusicPlayer GetMusicPlayer() {
        return FindObjectOfType<MusicPlayer>();
    }
}
