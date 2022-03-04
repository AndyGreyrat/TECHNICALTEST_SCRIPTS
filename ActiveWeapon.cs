using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public TakeWeapon takeWeapons;
    public int NumberOFWeapons;
    
    // Start is called before the first frame update
    void Start()
    {
        takeWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<TakeWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            takeWeapons.activeWeapons(NumberOFWeapons);
            Destroy(gameObject);
            
        }

    }
}
