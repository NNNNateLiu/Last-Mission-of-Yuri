using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRotation : MonoBehaviour
{
    public Vector3 temp;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        temp = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(temp);
        temp.x += speed * Time.deltaTime;
    }
}
