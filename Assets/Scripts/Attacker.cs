﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float currentSpeed = 0f;
    [SerializeField] int health = 200;
    [SerializeField] GameObject explosionEffectPrefab;
    [SerializeField] float durationOfExplosion = 1f;
    

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die() {
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
