using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Is in trigger");
        GameObject otherObject = collision.gameObject;

        if(otherObject.GetComponent<Defender>()) {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
