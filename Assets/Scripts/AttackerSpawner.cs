using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    bool spawn = true;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    [SerializeField] Attacker attackerPrefab;

	void Start () {
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies() {
        while (spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnEnemy();
        }

    }

    void SpawnEnemy() {
        Attacker attacker = Instantiate(
            attackerPrefab,
            transform.position,
            Quaternion.identity
        ) as Attacker;

        attacker.transform.parent = transform;
    }

}
