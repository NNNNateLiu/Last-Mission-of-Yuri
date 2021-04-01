using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour
{
    public GameObject radio;
    public string shownNumber;
    public int number;
    public Text mtext;

    // Update is called once per frame
    void Update()
    {
        mtext.text = shownNumber;
    }

    public void SwitchNumber()
    {

    }
}
