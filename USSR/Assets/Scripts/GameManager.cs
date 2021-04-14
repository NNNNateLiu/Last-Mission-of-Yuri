using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gravitySource;
    public Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = gravitySource.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //gravitySource.transform.localRotation = Quaternion.Euler(temp);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            temp.y += 90;

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            temp.y -= 90;
        }
    }
}
