using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseManage : MonoBehaviour
{
    public GameObject PauseMenu;

    // Use this for initialization
    public void doPasue()
    {
        //if (PauseMenu.activeInHierarchy == false)
        //{
            Time.timeScale = 0;
            //PauseMenu.SetActive(true);
        //}
    }
    public void Resume()
    {
            //if(PauseMenu.activeInHierarchy == true)
            //{
                Time.timeScale = 1;
                //PauseMenu.SetActive(false);
            //}
    }
}