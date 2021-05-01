using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIAnimation : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Menu;
    public Animator GameStart;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Camera>().fieldOfView<=75.01f&&gameObject.GetComponent<Camera>().fieldOfView>=74.99f){
            Canvas.SetActive(true);
            gameObject.GetComponent<LookCamera>().enabled=true;
            if(gameObject.GetComponent<Camera>().fieldOfView==75f){
                Menu.SetActive(true);
                
            }
            else{
                Menu.SetActive(false);
                
            }
        }
        else{
            Canvas.SetActive(false);
            gameObject.GetComponent<LookCamera>().enabled=false;
        }

        if(gameObject.GetComponent<Camera>().fieldOfView<=10f){
        int i=SceneManager.GetActiveScene().buildIndex;
        i=i+1;
        SceneManager.LoadScene(i,LoadSceneMode.Single);
        }
        
    }

    public void startgame(){

        GameStart.SetBool("gamestart",true);
        gameObject.GetComponent<AudioSource>().Play();
        Panel.GetComponent<Shade>().enabled=true;
    }
}
