using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Exitbutton()
   {
        Application.Quit();
        Debug.Log("Game Closed");
   }
   public void STARTGAME()
   {
        SceneManager.LoadScene("Game");
   }
   public void Instructions()
   {
       SceneManager.LoadScene("Instructions");
   }
}
