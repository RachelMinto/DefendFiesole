using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    int numberOfAttackers;
    bool timerIsFinished = false;
    [SerializeField] AudioSource winSFX;
    [SerializeField] int secondsDelayNextLevel = 3;
    [SerializeField] GameObject winLabel;

    private void Start()
    {
        numberOfAttackers = FindObjectsOfType<Attacker>().Length;
        winLabel.SetActive(false);
    }

    public void IncrementAttackers() {
        numberOfAttackers++;
    }

    public void DeccrementAttackers()
    {
        numberOfAttackers--;
        CheckForWinCondition();
    }

    public void SetTimerIsFinished(bool isFinished) {
        timerIsFinished = isFinished;
        StopSpawners();
        CheckForWinCondition();
    }

    private void StopSpawners() {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner attackerSpawner in spawnerArray) {
            attackerSpawner.StopSpawning();
        }
    }

    public void CheckForWinCondition() {
        if(timerIsFinished && numberOfAttackers <= 0) {
            StartCoroutine(WinLevel());
        }
    }

    IEnumerator WinLevel() {
        winLabel.SetActive(true);
        AudioSource audioSource = winSFX;
        audioSource.Play();
        yield return new WaitForSeconds(secondsDelayNextLevel);
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        levelLoader.ImmediatelyLoadNextScene();
    }
}
