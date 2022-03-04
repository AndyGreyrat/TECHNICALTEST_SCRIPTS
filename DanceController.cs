using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    public GameObject animationRing;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            animationRing.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            animationRing.SetActive(false);
        }

    }
}
