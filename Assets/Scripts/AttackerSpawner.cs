using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    [SerializeField] Attacker[] attackerPrefabs;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));
            SpawnEnemy();
        }

    }

    public void StopSpawning() {
        spawn = false;
    }

    private void SpawnEnemy() {
        int attackerIndex = UnityEngine.Random.Range(0, attackerPrefabs.Length - 1);
        Attacker attackerPrefab = attackerPrefabs[attackerIndex];
        Spawn(attackerPrefab);
        IncrementNumberOfAttackers();
    }

    private void IncrementNumberOfAttackers()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        levelController.IncrementAttackers();
    }

    private void Spawn(Attacker attackerPrefab) {
        Attacker attacker = Instantiate(
            attackerPrefab,
            transform.position,
            Quaternion.identity
        ) as Attacker;

        attacker.transform.parent = transform;
    }

}
