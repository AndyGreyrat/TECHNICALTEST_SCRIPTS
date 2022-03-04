using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShop : MonoBehaviour
{
    public GameObject Shop;

    // Start is called before the first frame update
    void Start()
    {
        Shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Shop.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Shop.SetActive(false);
        }
    }
}
