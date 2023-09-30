using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject attackPrefab; 
    public bool separateParent = false;
    [Range(0, 10)] public float attTime = 1;  

    public GameObject item;

    public void Attack() {
        GameObject obj;

        if (separateParent) {
            obj = GameObject.Instantiate(attackPrefab, attackPrefab.transform.position, transform.rotation);
            Vector3 scale = new Vector3(0,0,0);
            scale.x = obj.transform.lossyScale.x*transform.lossyScale.x;
            scale.y = obj.transform.lossyScale.y*transform.lossyScale.y;
            obj.transform.localScale = scale;
        } else {
            obj = GameObject.Instantiate(attackPrefab, attackPrefab.transform.parent);
        }
        obj.SetActive(true);
    }
}
