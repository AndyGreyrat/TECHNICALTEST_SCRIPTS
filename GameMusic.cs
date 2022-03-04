using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameMusic : MonoBehaviour
{
    public float pitchValue = 1.0f;
    public AudioClip mySong1;
    public AudioClip mySong2;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private float low = 0.75f;
    private float high = 1.25f;

    void Awake()
    {
        audioSource1 = GetComponent<AudioSource>();
        audioSource1.clip = mySong1;
        audioSource1.loop = true;

    }
    
    void OnGUI()
    {
        pitchValue = GUI.HorizontalSlider(new Rect(25, 75, 100, 30), pitchValue, low, high);
        audioSource1.pitch = pitchValue;
    }
    
}



    





