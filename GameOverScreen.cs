using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text Messsage;
    public GameObject BackGround;

    private void Start()
    {
        BackGround.SetActive(false);
    }
    private void Update()
    {
        if (LIfeAndDamage.Life <= 0 && !BackGround.activeInHierarchy)
        {

            BackGround.SetActive(true);
            
        }
    }   
   
    public void ReStartButton()
    {
        SceneManager.LoadScene("GameDW");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
