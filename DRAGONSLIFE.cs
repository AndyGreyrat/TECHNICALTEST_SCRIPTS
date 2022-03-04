using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRAGONSLIFE : MonoBehaviour
{
    public int DragonsLife ;
    public int weaponDamage;
    public GameObject backGroundWin;

    public GameObject dragon;
    // Start is called before the first frame update
    void Start()
    {
        DragonsLife = 4000;
        weaponDamage = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (DragonsLife <= 0)
        {
            Destroy(dragon);
        }

       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            DragonsLife -= weaponDamage;
        }
    }
    
}
