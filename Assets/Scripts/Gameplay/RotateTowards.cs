using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public GameObject target;
    public string findByTag;
    public float speed = 10;
    public Vector2 minMaxLimit;
    private Vector3 lastPos;
    private bool facingRight = true;  // For determining which way the player is currently facing.

    void Awake() {
        if (target == null) {
            target = GameObject.Find(findByTag);
        }
        if (minMaxLimit == null) {
            minMaxLimit = new Vector2(0, 359);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastPos = target.transform.position;
        Vector3 relativePos = new Vector3(transform.position.x - lastPos.x, transform.position.y - lastPos.y, 0);
        Quaternion newRotation = Quaternion.LookRotation(relativePos, transform.up);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speed);
        
    }

}
