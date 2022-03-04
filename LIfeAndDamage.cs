using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LIfeAndDamage : MonoBehaviour
{
    public  static float Life = 4000;
    public bool invencible = false;
    public float invencibleTime = 0;
    public float timeBreak = 0.2f;
    public Image lifebar;

    //private Animator animaciondamage;
   
   
    public void damageP(int damage)
    {
        if (!invencible && Life > 0)
        {
            Life -= damage;
            //animaciondamage.Play("damage");
            StartCoroutine(undamage());
           // StartCoroutine(reduccionSpeed());
            lifebar.fillAmount = Life/4000;
            if (Life == 0)
            {
                GameOver();
            }
        }
    }
 
    void GameOver()
    {
      
       Debug.Log("Game Over");
       //Time.timeScale = 0;
          
    }
    IEnumerator undamage()
    {
        invencible = true;
        yield return new WaitForSeconds(invencibleTime);
        invencible = false;

    }
    //IEnumerator reduccionSpeed()
    //{
        //var currentSpeed = GetComponent<PlayerController>().Speed;
       // GetComponent<PlayerController>().Speed = 0;
       // yield return new WaitForSeconds(timeBreak);
        //GetComponent<PlayerController>().Speed = currentSpeed;
   // }
   

}
