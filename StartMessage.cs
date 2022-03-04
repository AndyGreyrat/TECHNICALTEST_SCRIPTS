using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour
{
    public static StartMessage singleton;
    public Text Welcome;
    public GameObject StartMess;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    private void Start()
    {
        StartMess.SetActive(true);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartMess.SetActive(false);
        }
    }
   

}
