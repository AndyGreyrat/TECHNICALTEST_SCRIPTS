using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public int Life = 4000;
    public Image lifebar;
    
    // Update is called once per frame
    void Update()
    {
        lifebar.fillAmount = Life / 100;
    }
}
