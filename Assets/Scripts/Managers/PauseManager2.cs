using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class PauseManager2 : MonoBehaviour
{
    public GameObject canvas;
    Animator anim;

    bool isPaused = false;

    void Start()
    {
        anim = canvas.GetComponent<Animator>();
    }

    public void PauseOn()
    {
        isPaused = true;
        anim.SetBool("isPause", isPaused);
        Invoke("TimeStop", 0.5f);
    }
    public void PauseOff()
    {
        Time.timeScale = 1f;
        isPaused = false;
        anim.SetBool("isPause", isPaused); 
    }
    void TimeStop()
    {
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        //EditorApplication.Exit(0);
        Application.Quit();
    }
   

}
  
  //if (Input.GetKeyDown(KeyCode.Escape))
       

