using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// yuanfan's code for something

public class SelfRotate : MonoBehaviour
{
    public float rotateSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime);
;    }
}
