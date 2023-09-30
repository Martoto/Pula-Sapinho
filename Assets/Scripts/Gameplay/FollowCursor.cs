using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    private Vector3 lastPos;
    void Update()
    {
        if (lastPos != Camera.main.ScreenToWorldPoint(Input.mousePosition)) {
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 aux = new Vector3(lastPos.x, lastPos.y, 0);
            transform.position = aux;
        }
    }
}
