using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public string ignore;
    // Update is called once per frame
   private void OnCollisionEnter2D(Collision2D other) {
       if (other.gameObject.tag != ignore) {
            Destroy(this.gameObject);
       }
   }
}
