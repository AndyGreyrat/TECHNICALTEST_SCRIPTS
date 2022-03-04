using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchMonster: MonoBehaviour
{
    
    public static int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<LIfeAndDamage>().damageP(damage);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<LIfeAndDamage>().damageP(damage);
        }
    }
}
