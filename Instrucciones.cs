using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instrucciones : MonoBehaviour
{
    public void STARTGAMEIns()
    {
        SceneManager.LoadScene("Game");
    }
    public void Menubutton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
