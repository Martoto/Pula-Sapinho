using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExpireTimer : MonoBehaviour
{
    [Range(0, 100f)][SerializeField]public float time = 1;
    private float t = 0;

    public UnityEvent onFinish;

    void Start() {
        onFinish = new UnityEvent();
    }
    

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= time) {
            onFinish.Invoke();
            Destroy(this.gameObject);
        }
    }



}
