using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    
    public GameObject weapon; 
    private Attacks att;
    private float cd = 0;     //attack cooldown
    private int cb = 0;     //combo counter

    void Awake()
    {
        if (weapon != null) {
            att = weapon.GetComponent<Attacks>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (att != null) {

            if (cd < att.attTime) {
                cd += Time.deltaTime;
            } else if (cd >= att.attTime && Input.GetButton("Fire1")) {
                cd = 0;
                Attack();
            }

        }


    }
    void Attack() {
       att.Attack();
    }

    void OnEnable() {
        if (weapon != null) {
            att = weapon.GetComponent<Attacks>();
        }
    }
}
