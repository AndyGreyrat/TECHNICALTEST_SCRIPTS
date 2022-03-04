using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapon : MonoBehaviour
{
    public GameObject [] Weapons;
    public bool ActiveSword;
    public void Update()
    {
       if(Input.GetKeyDown(KeyCode.J))
       {
            DisableWeapons();
            if (Input.GetKeyDown(KeyCode.I))
            {
                ActiveSword = true;
            
            }
       }
       
    }

    public void activeWeapons(int NumberofWeapons)
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);
        }
        Weapons[NumberofWeapons].SetActive(true);
        ActiveSword = true;
    }
    public void DisableWeapons()
    {
        for (int i = 0; i < Weapons.Length; i++)
        {
            Weapons[i].SetActive(false);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Weapons[i].SetActive(true);
            }
        }
        
    }
}
