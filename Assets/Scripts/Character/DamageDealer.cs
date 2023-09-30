using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DamageDealer : MonoBehaviour
{
    [Range(0, 100)][SerializeField] int damage = 1;

    [SerializeField] public string ignore;

    public bool damagesPlayer = true;
    public bool enabled = true;
    [SerializeField][Range(0, 100)] int knockback = 1;

    public void enable(bool inp) {
        enabled = inp;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!ignore.Contains(other.tag) && enabled) {
            if (other.gameObject.GetComponent<CharacterStats>() != null) {
                if (damagesPlayer || other.gameObject.layer != 8){
                    Debug.Log(other.gameObject.layer);
                    other.gameObject.GetComponent<CharacterStats>().damage(damage, knockback*(new Vector2(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y)));
                }
            }
        }
    }
}
