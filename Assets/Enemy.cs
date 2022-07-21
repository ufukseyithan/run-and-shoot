using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Transform playerTransform;

    void Awake() {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update() {
        var point = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, point, 5 * Time.deltaTime);
        transform.LookAt(point);
    }
}
