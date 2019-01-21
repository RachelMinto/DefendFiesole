using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    bool spawn = true;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 5f;
    [SerializeField] Attacker attackerPrefab;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator SpawnEnemies() {
        while (spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            SpawnEnemy();
        }

    }

    void SpawnEnemy() {
        var newEnemy = Instantiate(
            attackerPrefab,
            transform.position,
            Quaternion.identity
        );
    }

}
