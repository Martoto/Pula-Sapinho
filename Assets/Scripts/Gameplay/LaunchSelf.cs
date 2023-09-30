using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSelf : MonoBehaviour
{
    //used for projectiles, 0 is perfectly straight
    public float inaccuracy = 0;
    public Vector2 direction;
    public float force;
    void Awake() {
        if (inaccuracy > 0) {
            direction.x = direction.x + Random.Range(0.0f, inaccuracy/10);
            direction.y = direction.y + Random.Range(0.0f, inaccuracy/10);
            direction = direction.normalized;
        }
        GetComponent<Rigidbody2D>().AddRelativeForce(transform.root.localScale.normalized*force*direction);
    }
}
