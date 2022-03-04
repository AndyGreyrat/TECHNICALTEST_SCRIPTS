using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ogre")
        {
            other.GetComponent<LIfeAndDamage>().damageP(damage);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ogre")
        {
            other.GetComponent<LIfeAndDamage>().damageP(damage);
        }
    }
}
