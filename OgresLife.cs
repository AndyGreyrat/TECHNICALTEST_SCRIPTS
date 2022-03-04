using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgresLife : MonoBehaviour
{
    public int ogresLife;
    public GameObject ogre;
    public int weapondamage;
    void Start()
    {
        ogresLife = 200;
        weapondamage = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ogresLife == 0)
        {
            Destroy(ogre);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            ogresLife -= weapondamage;
        }
    }
}
