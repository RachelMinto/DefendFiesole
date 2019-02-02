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
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnEnemy();
        }

    }

    private void SpawnEnemy() {
        int attackerIndex = Random.Range(0, attackerPrefabs.Length - 1);
        Attacker attackerPrefab = attackerPrefabs[attackerIndex];
        Spawn(attackerPrefab);
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
