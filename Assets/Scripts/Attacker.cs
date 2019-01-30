using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float currentSpeed = 0f;
    GameObject currentTarget;
    Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        if(!currentTarget) {
            GetComponent<Animator>().SetBool("isAttacking", false);      
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            int damage = damageDealer.GetDamage();
            health.TakeDamage(damage);
            damageDealer.Hit();
        }
    }

    private void StrikeTarget(int damage) {
        if (!currentTarget) { return; }
        Health opponentHealth = currentTarget.GetComponent<Health>();

        if (opponentHealth)
        {
            opponentHealth.TakeDamage(damage);
        }
    }
}
