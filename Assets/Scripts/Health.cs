using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] int health = 200;
    [SerializeField] GameObject explosionEffectPrefab;
    [SerializeField] float durationOfExplosion = 1f;

    public int GetHealth() {
        return health;
    }

    public void TakeDamage (int damage) {
        health -= damage;

        if(health <= 0) {
            Die();
        }
	}

    private void Die()
    {
        Destroy(gameObject);
        ExplodingVisualEffect();
    }

    private void ExplodingVisualEffect()
    {
        if (!explosionEffectPrefab) { return; }
        GameObject explosion = Instantiate(
            explosionEffectPrefab,
            transform.position,
            Quaternion.identity
        ) as GameObject;

        Object.Destroy(explosion, durationOfExplosion);
    }
}
