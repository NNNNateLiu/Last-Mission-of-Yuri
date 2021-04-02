using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour
{
    public GameObject radio;
    public string shownNumber;
    public int numberOrder;
    public Text mtext;

    // Update is called once per frame
    void Update()
    {
        mtext.text = RadioController.instance.numbers[numberOrder].ToString();

        if(numberOrder == RadioController.instance.currentContrillingNumber)
        {
            mtext.color = Color.red;
        }
        else
        {
            mtext.color = Color.black;
        }
    }
}
