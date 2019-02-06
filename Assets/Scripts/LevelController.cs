using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    int numberOfAttackers;
    bool timerIsFinished = false;
    [SerializeField] AudioSource winSFX;
    [SerializeField] int secondsDelayNextLevel = 3;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    private void Start()
    {
        numberOfAttackers = FindObjectsOfType<Attacker>().Length;
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
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

    public void HandleLoseCondition() {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator WinLevel() {
        winLabel.SetActive(true);
        winSFX.Play();
        yield return new WaitForSeconds(secondsDelayNextLevel);
        FindObjectOfType<LevelLoader>().LoadStartScene();
    }
}
