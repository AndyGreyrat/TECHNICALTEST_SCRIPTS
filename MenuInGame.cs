using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    
    public GameObject MenuIngame;
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        MenuIngame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuIngame.SetActive(true);
        }
    }
    public void ContinueButton()
    {
        MenuIngame.SetActive(false);
    }
    public void ExitGameButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ShopButton()
    {
        shop.SetActive(true);
    }
    public void IntructionsButton()
    {
        SceneManager.LoadScene("Instructions");
    }
}

