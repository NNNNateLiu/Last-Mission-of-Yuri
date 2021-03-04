using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public float rotateSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime);
;    }
}
