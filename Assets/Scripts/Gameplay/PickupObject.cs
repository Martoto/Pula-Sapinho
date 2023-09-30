using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public float radius = 1.0f;
    public bool pickable = false; 
    private GameObject target;
    public GameObject item;

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && pickable) {
            if (target.GetComponent<Items>().pick(item)) {
                Destroy(this.gameObject);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            pickable = true;
            target = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            pickable = false;
        }
    }
}
