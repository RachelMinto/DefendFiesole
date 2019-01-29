using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] int health = 200;

    public int GetHealth() {
        return health;
    }

    public void DealDamage (int damage) {
        health -= damage;
	}
}
