﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float degreesRotation = -360f;

	void Update () {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, degreesRotation * Time.deltaTime);
	}
}
