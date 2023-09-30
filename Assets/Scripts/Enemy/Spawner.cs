using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //general purpose enemy spawner
    //simply instantiates the selected prefab
    public GameObject prefab;
    [Range(0, 100.0f)] [SerializeField] public float spawnRate;
    public int maxN;
    public int maxD;
    private int n;
    void FixedUpdate() {
        if (n < maxN) {
            if (Random.Range(0, 100.0f) < spawnRate) {
                n++;
                spawn(prefab.transform);
            }
        }
    }
    GameObject spawn(Transform transform) {
        return GameObject.Instantiate(prefab, transform.position + new Vector3(Random.Range(0, maxD), 0, 0), transform.rotation);
    }
}
