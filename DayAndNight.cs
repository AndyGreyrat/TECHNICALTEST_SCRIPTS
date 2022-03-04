using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    public int RotacionScale = 10;

   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotacionScale * Time.deltaTime, 0, 0);
    }
}
