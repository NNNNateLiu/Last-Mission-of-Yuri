using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour

{
    public Animator TurnPage;
    public GameObject theButton1;
    public GameObject theButton2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotateleft(){
    
        TurnPage.SetBool("Left",true);
        TurnPage.SetBool("Right",false);
        theButton1.SetActive(false);
        theButton2.SetActive(true);
    }
    public void rotateright(){
        TurnPage.SetBool("Right",true);
        TurnPage.SetBool("Left",false);
        theButton1.SetActive(false);
        theButton2.SetActive(true);
    }
}


