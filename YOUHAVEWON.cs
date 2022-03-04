using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YOUHAVEWON : MonoBehaviour
{
    
    public GameObject BackGroundWin;
    public GameObject dragonObject;

    private void Start()
    {
        BackGroundWin.SetActive(false);
    }

    public void Update()
    {
        if (dragonObject == null)
        {
            BackGroundWin.SetActive(true);
        }
    }

    
 

    public void NewGameButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGameButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

