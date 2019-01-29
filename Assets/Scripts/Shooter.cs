using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            // String reference of bool that was originally created on Animator.
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
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
        if (myLaneSpawner && myLaneSpawner.transform.childCount <= 0) {
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
