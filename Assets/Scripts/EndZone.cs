using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        Attacker attacker = other.gameObject.GetComponent<Attacker>();
        GameLives gameLives = FindObjectOfType<GameLives>();
        if (attacker)
        {
            gameLives.LoseLife();
            StartCoroutine(DelayAndDestroyAttacker(other.gameObject));
        }
    }


    IEnumerator DelayAndDestroyAttacker(GameObject attacker)
    {
        yield return new WaitForSeconds(2);
        attacker.GetComponent<Health>().Die();
    }

}
