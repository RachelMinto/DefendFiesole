using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("Is In Lane. Pew Pew.");
        } else {
            Debug.Log("Just sit tight.");
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners) {
            // Mathf.Epsilon acknowledges that we might not always get 0 here.
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough) {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }

        return true;
    }

    public void Fire () {
        Instantiate(
            projectile,
            gun.transform.position,
            Quaternion.identity
        );
	}
	
}
